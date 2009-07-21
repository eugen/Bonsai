using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting;

namespace Bonsai.Runtime {
    public class BlockBonsaiFunction : BonsaiFunction {
        public Func<object> Function { get; private set; }
        static readonly SymbolId InvokeSymbol = SymbolTable.StringToId("Invoke");

        public BlockBonsaiFunction(Func<object> function) {
            this.Function = function;
        }

        public override object Call(object[] arguments) {
            if (arguments.Length == 0)
                return Function;
            else if (
                arguments.Length == 1 &&
                arguments[0] is SymbolId &&
                (SymbolId)arguments[0] == InvokeSymbol)
                return Function();
            else
                throw new MissingMethodException();
        }
    }
}
