using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Bonsai.Runtime.Primitives;
using Microsoft.Scripting;

namespace Bonsai.Runtime {
    public class PreludeFunction : DictionaryBonsaiFunction {
        public PreludeFunction()
            : base(null) {
            this["print"] = new DelegateBonsaiFunction(
               args => {
                   args = args.Subarray(1, args.Length - 1);
                   var str = args.Aggregate("", (s, arg) => s + arg);
                   Console.WriteLine(str);
                   return str;
               });
            this["defun"] = new DelegateBonsaiFunction(
                args => {
                    return BonsaiGlobalFunctions.Defun(args);
                });

            this["="] = new DelegateBonsaiFunction(
                args => {
                    Debug.Assert(args.Length == 3);
                    Debug.Assert(args[0] is DictionaryBonsaiFunction);
                    var callScope = (DictionaryBonsaiFunction)args[0];
                    callScope[(SymbolId)args[1]] = args[2];
                    return args[2];
                });

        }
    }
}
