using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Bonsai.Runtime.Primitives;
using Microsoft.Scripting;
using System.Reflection;

namespace Bonsai.Runtime {
    public partial class PreludeFunction : DictionaryBonsaiFunction {
        public PreludeFunction()
            : base(null) {
            foreach(MethodInfo method in this.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance)) {
                var attrs = method.GetCustomAttributes(typeof(MapsToSymbolAttribute), false);
                foreach(MapsToSymbolAttribute mapper in attrs) {
                    this.Dict.Add(
                        mapper.Symbol, 
                        new DelegateBonsaiFunction((Func<object[], object>)Delegate.CreateDelegate(typeof(Func<object[], object>), this, method)));
                }
            }
            this.Dict.Add(SymbolTable.StringToId("null"), null);
        }

        [MapsToSymbol("defun")]
        public object Defun(object[] args) {
            Debug.Assert(args.Length >= 3, "A call to defun should have at least two parameters: the name of the function and its block");
            Debug.Assert(args[0] is DictionaryBonsaiFunction);
            for (int i = 1; i < args.Length - 1; i++)
                Debug.Assert(args[i] is SymbolId, "Argument " + i + " should be a SymbolId");
            Debug.Assert(args[args.Length - 1] is BlockBonsaiFunction, "The last arguments should be a block");

            var scope = (DictionaryBonsaiFunction)args[0];
            var name = (SymbolId)args[1];
            var parameters = new SymbolId[args.Length - 3];
            for (int i = 2; i < args.Length - 1; i++)
                parameters[i - 2] = (SymbolId)args[i];
            var block = (BlockBonsaiFunction)args[args.Length - 1];

            scope[name] = new DelegateBonsaiFunction(callArgs => {
                Debug.Assert(callArgs.Length - 1 == parameters.Length, "The number of arguments should equal the number of parameters");

                var blockLocalVariables = new DictionaryBonsaiFunction();
                for (int i = 0; i < parameters.Length; i++) {
                    blockLocalVariables[parameters[i]] = callArgs[i + 1];
                }

                return block.Invoke(blockLocalVariables);
            });

            return scope[name];
        }

        [MapsToSymbol("print")]
        public object Print(object[] args) {
            args = args.Subarray(1, args.Length - 1);
            var str = args.Aggregate("", (s, arg) => s + arg);
            Console.WriteLine(str);
            return str;
        }

        [MapsToSymbol("=")]
        public object Assign(object[] args) {
            Debug.Assert(args.Length == 3);
            Debug.Assert(args[0] is DictionaryBonsaiFunction);
            var scope = (DictionaryBonsaiFunction)args[0];
            scope.UpdateOrAdd((SymbolId)args[1], args[2]);
            return args[2];
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
            Debug.Assert(args.Length == 3);
            Debug.Assert(args[1] is SymbolId);
            Debug.Assert(args[2] is SymbolId);

            var scope = (DictionaryBonsaiFunction)args[0];
            var alias = (SymbolId)args[1];
            var importedTypeStr = ((SymbolId)args[2]).ToString();
            var importedType = Type.GetType(importedTypeStr, false);
            if (importedType != null) {
                scope[alias] = new BonsaiClrClassFunction(importedType);
                return importedType;
            } else { // we'll assume it's a namespace and not a class
                var nameSpace = new BonsaiClrNamespaceFunction(importedTypeStr);
                scope[alias] = nameSpace;
                return nameSpace;
            }
        }
    }
}
