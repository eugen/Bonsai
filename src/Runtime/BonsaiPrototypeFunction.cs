using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Scripting;

namespace Bonsai.Runtime {
    public class BonsaiPrototypeFunction : DictionaryBonsaiFunction {
        public SymbolId Name { get; private set; }

        public BonsaiPrototypeFunction(SymbolId? name = null, BonsaiPrototypeFunction prototype = null) : base(null) {
            if (name.HasValue)
                this.Name = name.Value;
            else
                this.Name = "«unnamed»".ToSymbol();

            if (prototype == null) {
                foreach (MethodInfo method in this.GetType().GetMethods(
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static   )) {
                    var attrs = method.GetCustomAttributes(typeof(MapsToSymbolAttribute), false);
                    foreach (MapsToSymbolAttribute mapper in attrs) {
                        this.Dict.Add(
                            mapper.Symbol,
                            new DelegateBonsaiFunction((Func<object[], object>)Delegate.CreateDelegate(
                                typeof(Func<object[], object>),
                                method.IsStatic ? null : this,
                                method)));
                    }
                }
            } else {
                this.Dict = new SortedList<SymbolId, object>(prototype.Dict);
            }
        }

        public override object Call(object[] arguments) {
            var newArgs = new object[arguments.Length];
            Array.Copy(arguments, newArgs, arguments.Length);
            var newScope = new DictionaryBonsaiFunction((BonsaiFunction)arguments[0]);
            newScope["self"] = this;
            newArgs[0] = newScope;
            return base.Call(newArgs);
        }

        [MapsToSymbol("clone")]
        public static object Clone(object[] args) {
            Debug.Assert(args.Length == 1 || (args.Length == 2 && args[1] is SymbolId));
            var scope = (DictionaryBonsaiFunction)args[0];
            SymbolId? name;
            if (args.Length == 2)
                name = (SymbolId)args[1];
            else
                name = null;

            var self = (BonsaiPrototypeFunction)scope["self"];
            return new BonsaiPrototypeFunction(name, self);
        }

        [MapsToSymbol("field")]
        public static object Set(object[] args) {
            Debug.Assert(args.Length == 3);
            var scope = (DictionaryBonsaiFunction)args[0];
            var name = (SymbolId)args[1];
            var value = args[2];
            var self = (BonsaiPrototypeFunction)scope["self"];

            self.Dict[name] = new DelegateBonsaiFunction(callArgs => {
                Debug.Assert(callArgs.Length == 1);
                return value;
            });
            return value;
        }

        [MapsToSymbol("method")]
        public static object Method(object[] args) {
            Debug.Assert(args.Length >= 3, "A call to «method» should have at least two parameters: the name of the method and its block");
            Debug.Assert(args[0] is DictionaryBonsaiFunction);
            for (int i = 1; i < args.Length - 1; i++)
                Debug.Assert(args[i] is SymbolId, "Argument " + i + " should be a SymbolId");
            Debug.Assert(args[args.Length - 1] is BlockBonsaiFunction, "The last arguments should be a block");

            var scope = (DictionaryBonsaiFunction)args[0];
            var name = (SymbolId)args[1];
            var block = (BlockBonsaiFunction)args[args.Length - 1];
            var self = (BonsaiPrototypeFunction)scope["self"];

            var parameters = new SymbolId[args.Length - 3];
            for (int i = 2; i < args.Length - 1; i++)
                parameters[i - 2] = (SymbolId)args[i];

            self[name] = new DelegateBonsaiFunction(callArgs => {
                Debug.Assert(callArgs.Length - 1 == parameters.Length, "The number of arguments should equal the number of parameters");
                                
                var blockLocalVariables = new DictionaryBonsaiFunction();
                for (int i = 0; i < parameters.Length; i++) {
                    blockLocalVariables[parameters[i]] = callArgs[i + 1];
                }
                var callSelf = ((DictionaryBonsaiFunction)callArgs[0])["self"];
                blockLocalVariables["self"] = callSelf;
                return block.Invoke(blockLocalVariables);
            });

            return self[name];
        }
    }
}
