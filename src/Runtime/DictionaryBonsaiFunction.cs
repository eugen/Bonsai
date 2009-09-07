using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting;

namespace Bonsai.Runtime {
    public class DictionaryBonsaiFunction : BonsaiFunction {
        public BonsaiFunction Parent { get; private set; }
        public SortedList<SymbolId, BonsaiFunction> Dict { get; private set; } 

        public DictionaryBonsaiFunction(BonsaiFunction parent = null) {
            this.Parent = parent;
            this.Dict = new SortedList<SymbolId, BonsaiFunction>();
        }

        public BonsaiFunction this[SymbolId symbol] {
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

        public BonsaiFunction this[string symbolName] {
            get { return this[SymbolTable.StringToId(symbolName)]; }
            set { this[SymbolTable.StringToId(symbolName)] = value; }
        }

        public override object Call(object[] arguments) {
            if (arguments.Length > 1 &&
                arguments[1] is SymbolId &&
                Dict.ContainsKey((SymbolId)arguments[0])) {
                var symbol = (SymbolId)arguments[1];
                var newArguments = new object[arguments.Length - 1];
                // pass the scope along
                newArguments[0] = arguments[0];
                Array.Copy(arguments, 2, newArguments, 1, arguments.Length - 2);
                return Dict[symbol].Call(newArguments);
            } else if (Parent != null) {
                return Parent.Call(arguments);
            } else
                throw new MissingMethodException();
        }
    }
}
