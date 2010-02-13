using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Scripting;
using System.Reflection;

namespace Bonsai.Runtime {
    public partial class PreludeFunction : DictionaryBonsaiFunction {
        public PreludeFunction()
            : base(null) {
            foreach(MethodInfo method in this.GetType().GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)) {
                var attrs = method.GetCustomAttributes(typeof(MapsToSymbolAttribute), false);
                foreach(MapsToSymbolAttribute mapper in attrs) {
                    this.Dict.Add(
                        mapper.Symbol, 
                        new DelegateBonsaiFunction(
                            (Func<object[], object>)Delegate.CreateDelegate(
                                typeof(Func<object[], object>), 
                                method.IsStatic ? null : this, 
                                method)));
                }
            }
            this.Dict.Add(SymbolTable.StringToId("null"), null);
            this.Dict.Add(SymbolTable.StringToId("true"), true);
            this.Dict.Add(SymbolTable.StringToId("false"), false);
            this.Dict.Add(SymbolTable.StringToId("object"), new BonsaiPrototypeFunction("MasterPrototype".ToSymbol(), null));

            InitDataHandlers();
        }

        [MapsToSymbol("defun")]
        public static object Defun(object[] args) {
            Debug.Assert(args.Length >= 3, "A call to defun should have at least two parameters: the name of the function and its block");
            Debug.Assert(args[0] is DictionaryBonsaiFunction);
            for (int i = 1; i < args.Length - 1; i++)
                Debug.Assert(args[i] is SymbolId, "Argument " + i + " should be a SymbolId");
            Debug.Assert(args[args.Length - 1] is BlockBonsaiFunction, "The last arguments should be a block");

            var scope = (DictionaryBonsaiFunction)args[0];
            var name = (SymbolId)args[1];
            var newArgs = new object[args.Length - 1];
            newArgs[0] = scope;
            Array.Copy(args, 2, newArgs, 1, args.Length - 2);
            scope[name] = Fun(newArgs);
            return scope[name];
        }

        [MapsToSymbol("fun")]
        public static object Fun(object[] args) {
            Debug.Assert(args.Length >= 2, "A call to defun should have at least one parameter: its block");
            Debug.Assert(args[0] is DictionaryBonsaiFunction);
            Debug.Assert(args[args.Length - 1] is BlockBonsaiFunction, "The last arguments should be a block");
            
            var parameters = new SymbolId[args.Length - 2];
            for (int i = 1; i < args.Length - 1; i++)
                parameters[i - 1] = (SymbolId)args[i];
            var block = (BlockBonsaiFunction)args[args.Length - 1];

            return new DelegateBonsaiFunction(callArgs => {
                Debug.Assert(callArgs.Length - 1 == parameters.Length, "The number of arguments should equal the number of parameters");

                var blockLocalVariables = new DictionaryBonsaiFunction();
                for (int i = 0; i < parameters.Length; i++) {
                    blockLocalVariables[parameters[i]] = callArgs[i + 1];
                }

                return block.Invoke(blockLocalVariables);
            });
        }

        [MapsToSymbol("print")]
        public object Print(object[] args) {
            args = args.Subarray(1, args.Length - 1);
            var str = args.Aggregate("", (s, arg) => s + arg);
            Console.WriteLine(str);
            return str;
        }

        [MapsToSymbol("=")]
        public object AssignOrUpdate(object[] args) {
            Debug.Assert(args.Length == 3);
            Debug.Assert(args[0] is DictionaryBonsaiFunction);
            var scope = (DictionaryBonsaiFunction)args[0];
            scope.UpdateOrAdd((SymbolId)args[1], args[2]);
            return args[2];
        }
        
        [MapsToSymbol("=:")]
        public object Assign(object[] args) {
            Debug.Assert(args.Length == 3);
            Debug.Assert(args[0] is DictionaryBonsaiFunction);
            var scope = (DictionaryBonsaiFunction)args[0];
            scope[(SymbolId)args[1]] = args[2];
            return args[2];
        }

        [MapsToSymbol("==")]
        public object _Equals(object[] args) {
            Debug.Assert(args.Length >= 3);
            Debug.Assert(args[0] is DictionaryBonsaiFunction);
            for (int i = 1; i < args.Length - 1; i++) {
                var a1 = args[i];
                var a2 = args[i + 1];
                if (!((a1 == null && a2 == null) || a1.Equals(a2)))
                    return false;
            }
            return true;
        }

        [MapsToSymbol("<")]
        public object Smaller(object[] args) {
            Debug.Assert(args.Length >= 3);
            Debug.Assert(args[0] is DictionaryBonsaiFunction);

            for (int i = 1; i < args.Length - 1; i++) {
                Debug.Assert(args[i] is IComparable);
                var a1 = (IComparable)args[i];
                var a2 = args[i + 1];
                if (!(a1.CompareTo(a2) < 0))
                    return false;
            }
            return true;
        }
        [MapsToSymbol("<=")]
        public object SmallerOrEquals(object[] args) {
            Debug.Assert(args.Length >= 3);
            Debug.Assert(args[0] is DictionaryBonsaiFunction);

            for (int i = 1; i < args.Length - 1; i++) {
                Debug.Assert(args[i] is IComparable);
                var a1 = (IComparable)args[i];
                var a2 = args[i + 1];
                if (!(a1.CompareTo(a2) <= 0))
                    return false;
            }
            return true;
        }
        [MapsToSymbol(">")]
        public object Greater(object[] args) {
            Debug.Assert(args.Length >= 3);
            Debug.Assert(args[0] is DictionaryBonsaiFunction);

            for (int i = 1; i < args.Length - 1; i++) {
                Debug.Assert(args[i] is IComparable);
                var a1 = (IComparable)args[i];
                var a2 = args[i + 1];
                if (!(a1.CompareTo(a2) > 0))
                    return false;
            }
            return true;
        }
        [MapsToSymbol(">=")]
        public object GreaterOrEquals(object[] args) {
            Debug.Assert(args.Length >= 3);
            Debug.Assert(args[0] is DictionaryBonsaiFunction);

            for (int i = 1; i < args.Length - 1; i++) {
                Debug.Assert(args[i] is IComparable);
                var a1 = (IComparable)args[i];
                var a2 = args[i + 1];
                if (!(a1.CompareTo(a2) >= 0))
                    return false;
            }
            return true;
        }

        // Fetches an object from the scope without evaluating it. Used to return functions.
        [MapsToSymbol("ref")]
        public object Reference(object[] args) {
            Debug.Assert(args.Length == 2);
            Debug.Assert(args[1] is SymbolId);
            var scope = (DictionaryBonsaiFunction)args[0];
            return scope[(SymbolId)args[1]];
        }

        [MapsToSymbol("import")]
        public object Import(object[] args) {
            Debug.Assert(args.Length >= 3);
            Debug.Assert(args[1] is SymbolId);
            Debug.Assert(args[2] is SymbolId || args[2] is string);
            for (int i = 3; i < args.Length; i++)
                Debug.Assert(args[i] is SymbolId || args[i] is string || args[i] is BonsaiClrClassFunction);
            
            var scope = (DictionaryBonsaiFunction)args[0];
            var alias = (SymbolId)args[1];
            var importedTypeStr = args[2].ToString();
            if (args.Length > 3)
                importedTypeStr += "`" + (args.Length - 3);
            Func<string, Type> loadType = typeStr => {
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                    var type = assembly.GetType(typeStr, false);
                    if (type != null)
                        return type;
                }
                return null;
            };

            Type importedType = loadType(importedTypeStr);
            if (importedType != null) {
                if (args.Length > 3) {
                    Type[] genericArgs = new Type[args.Length - 3];
                    for (int i = 3; i < args.Length; i++) {
                        var par = args[i];
                        Type genArg = null;
                        if(par is SymbolId || par is string) {
                            genArg = loadType(par.ToString());
                            if(genArg == null) 
                                throw new ArgumentException("Cound not find a generic type argument for the type " + genArg);
                        } else
                            genArg = ((BonsaiClrClassFunction)par).Class;
                        genericArgs[i-3] = genArg;
                    }
                    importedType = importedType.MakeGenericType(genericArgs);
                }
                scope[alias] = new BonsaiClrClassFunction(importedType);
                return importedType;
            } else { // we'll assume it's a namespace and not a class
                if (args.Length > 3)
                    throw new ArgumentException("Generic parameters specified, but generic class was not found");
                var nameSpace = new BonsaiClrNamespaceFunction(importedTypeStr);
                scope[alias] = nameSpace;
                return nameSpace;
            }
        }

        [MapsToSymbol("loadAssembly")]
        public object LoadAssembly(object[] args) {
            Debug.Assert(args.Length == 2);
            Debug.Assert(args[1] is string);

            return Assembly.Load((string)args[1]);
        }

        [MapsToSymbol("loadAssemblyFile")]
        public object LoadAssemblyFile(object[] args) {
            Debug.Assert(args.Length == 2);
            Debug.Assert(args[1] is string);

            return Assembly.LoadFile((string)args[1]);
        }

        [MapsToSymbol("if")]
        public object If(object[] args) {
            Debug.Assert(args.Length == 4);
            var scope = (DictionaryBonsaiFunction)args[0];
            bool condition = args[1] != null && !args[1].Equals(false);
            var thenAction = args[2];
            var elseAction = args[3];

            object result = null;
            if (condition) {
                result = thenAction;
            } else {
                result = elseAction;
            }
            if (result != null && result is BlockBonsaiFunction) {
                result = ((BlockBonsaiFunction)result).Invoke();
            }
            return result;
        }

        [MapsToSymbol("foreach")]
        public object Foreach(object[] args) {
            Debug.Assert(args.Length == 4);
            Debug.Assert(args[1] is SymbolId);
            Debug.Assert(args[2] is System.Collections.IEnumerable);
            Debug.Assert(args[3] is BlockBonsaiFunction);

            var scope = (DictionaryBonsaiFunction)args[0];
            var varName = (SymbolId)args[1];
            var enumerable = (System.Collections.IEnumerable)args[2];
            var block = (BlockBonsaiFunction)args[3];
            object result = null;
            foreach (var e in enumerable) {
                var locals = new DictionaryBonsaiFunction();
                locals[varName] = e;
                result = block.Invoke(locals);
            }
            return result;
        }

        [MapsToSymbol("when")]
        public object When(object[] args) {
            Debug.Assert(args.Length == 3);
            var scope = (DictionaryBonsaiFunction)args[0];
            bool condition = args[1] != null && !args[1].Equals(false);
            Debug.Assert(args[2] is BlockBonsaiFunction);
            var action = (BlockBonsaiFunction)args[2];
            
            object result = null;
            if (condition) {
                result = action.Invoke();
            }
            return result;
        }

        [MapsToSymbol("unless")]
        public object Unless(object[] args) {
            Debug.Assert(args.Length == 3);
            var scope = (DictionaryBonsaiFunction)args[0];
            bool condition = args[1] != null && !args[1].Equals(false);
            Debug.Assert(args[2] is BlockBonsaiFunction);
            var action = (BlockBonsaiFunction)args[2];

            object result = null;
            if (!condition) {
                result = action.Invoke();
            }
            return result;
        }
    }
}
