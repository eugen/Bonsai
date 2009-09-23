using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting;
using System.Diagnostics;

namespace Bonsai.Runtime.Primitives {
    public static class BonsaiGlobalFunctions {
        public static object Defun(object[] args) {
            Debug.Assert(args.Length >= 3, "A call to defun should have at two parameters: the name of the function and its block");
            Debug.Assert(args[0] is DictionaryBonsaiFunction);
            for(int i = 1; i < args.Length - 1; i++)
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
                Console.WriteLine(callArgs[0]);
                for(int i = 0; i < parameters.Length; i++) {
                    blockLocalVariables[parameters[i]] = callArgs[i + 1];
                }

                return block.Invoke(blockLocalVariables);
            });

            return null;
        }
    }
}
