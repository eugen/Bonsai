using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using Microsoft.Scripting;

namespace Bonsai.Runtime {
    public class MapsToSymbolAttribute : Attribute {
        public SymbolId Symbol { get; set; }

        public MapsToSymbolAttribute(SymbolId symbol) {
            this.Symbol = symbol;
        }

        public MapsToSymbolAttribute(string symbolName) {
            this.Symbol = SymbolTable.StringToId(symbolName);
        }
    }
}
