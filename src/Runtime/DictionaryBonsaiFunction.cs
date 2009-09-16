using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting;
using System.Dynamic;

namespace Bonsai.Runtime {
    public class DictionaryBonsaiFunction : BonsaiFunction {
        public BonsaiFunction Parent { get; private set; }
        public SortedList<SymbolId, object> Dict { get; private set; } 

        public DictionaryBonsaiFunction(BonsaiFunction parent = null) {
            this.Parent = parent;
            this.Dict = new SortedList<SymbolId, object>();
        }

        public object this[SymbolId symbol] {
            get {
                if (Dict.ContainsKey(symbol))
                    return Dict[symbol];
                else if (Parent != null && Parent is DictionaryBonsaiFunction)
                    return ((DictionaryBonsaiFunction)Parent)[symbol];
                else
                    throw new KeyNotFoundException("The key " + symbol + " was not found in the bonsai dictionary function");
            }
            set { Dict[symbol] = value; }
        }

        public object this[string symbolName] {
            get { return this[SymbolTable.StringToId(symbolName)]; }
            set { this[SymbolTable.StringToId(symbolName)] = value; }
        }

        public override object Call(object[] arguments) {
            if (arguments.Length > 1 &&
                arguments[1] is SymbolId &&
                Dict.ContainsKey((SymbolId)arguments[1])) {
                var symbol = (SymbolId)arguments[1];
                var newArguments = new object[arguments.Length - 1];
                // pass the scope along
                newArguments[0] = arguments[0];
                Array.Copy(arguments, 2, newArguments, 1, arguments.Length - 2);
                object callee = Dict[symbol];
                if(callee is BonsaiFunction) {
                    return ((BonsaiFunction)callee).Call(newArguments);
                } else {
                    throw new Exception(GetType().Name + ": Cannot pass call an object of type " + callee.GetType().Name);
                }
            } else if (Parent != null) {
                return Parent.Call(arguments);
            } else
                throw new MissingMethodException();
        }

        public int Depth {
            get {
                if (Parent == null || !(Parent is DictionaryBonsaiFunction))
                    return 0;
                else
                    return ((DictionaryBonsaiFunction)Parent).Depth + 1;
            }
        }

        public void UpdateOrAdd(SymbolId key, object value) {
            var dict = this;
            while (dict != null) {
                if (dict.Dict.ContainsKey(key)) {
                    dict[key] = value;
                    return;
                } else {
                    dict = dict.Parent as DictionaryBonsaiFunction;
                }
            }

            this.Dict.Add(key, value);
        }
    }
}
