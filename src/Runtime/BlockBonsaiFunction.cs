using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting;
using System.Diagnostics;

namespace Bonsai.Runtime {
    public class BlockBonsaiFunction : BonsaiFunction {
        static readonly SymbolId InvokeSymbol = SymbolTable.StringToId("Invoke");
        static readonly SymbolId ToStringSymbol = SymbolTable.StringToId("ToString");

        public Func<DictionaryBonsaiFunction, object> Function { get; private set; }
        public DictionaryBonsaiFunction Scope { get; private set; }
        
        public BlockBonsaiFunction(Func<DictionaryBonsaiFunction, object> function, DictionaryBonsaiFunction scope) {
            this.Function = function;
            this.Scope = scope;
        }

        public override object Call(object[] arguments) {
            Debug.Assert(arguments.Length > 0 && arguments[0] is DictionaryBonsaiFunction);
            if (arguments.Length == 1)
                return this;
            else if (arguments.Length == 2 && arguments[1] is SymbolId) {
                var symbol = (SymbolId)arguments[1];
                if (symbol == InvokeSymbol) {
                    return Function(new DictionaryBonsaiFunction(Scope)); ;
                } else if (symbol == ToStringSymbol) {
                    return Function.ToString();
                } else {
                    throw new MissingMethodException();
                }
            } else {
                throw new MissingMethodException();
            }
         }
    }
}
