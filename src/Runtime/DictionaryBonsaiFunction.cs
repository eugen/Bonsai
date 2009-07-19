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
            get { return Dict[symbol]; }
            set { Dict[symbol] = value; }
        }

        public BonsaiFunction this[string symbolName] {
            get { return Dict[SymbolTable.StringToId(symbolName)]; }
            set { Dict[SymbolTable.StringToId(symbolName)] = value; }
        }

        public override object Call(object[] arguments) {
            if (arguments.Length > 0 &&
                arguments[0] is SymbolId &&
                Dict.ContainsKey((SymbolId)arguments[0])) {
                var symbol = (SymbolId)arguments[0];
                return Dict[symbol].Call(arguments.Subarray(1, arguments.Length - 1));
            } else if (Parent != null) {
                return Parent.Call(arguments);
            } else
                throw new MissingMethodException();
        }
    }
}
