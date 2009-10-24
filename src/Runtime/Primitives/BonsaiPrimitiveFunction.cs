using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting;
using System.Reflection;

namespace Bonsai.Runtime.Primitives {
    public class BonsaiPrimitiveFunction : BonsaiFunction {
        public override object Call(object[] arguments) {
            if (arguments.Length >= 3 && arguments[2] is SymbolId) {
                var method = GetType().GetMethodsWith<MapsToSymbolAttribute>(
                    (mi, attr) => attr.Symbol == (SymbolId)arguments[2]).FirstOrDefault();
                if(method != null) {
                    object[] callArgs = new object[3];
                    callArgs[0] = arguments[0];
                    callArgs[1] = arguments[1];
                    callArgs[2] = arguments.Subarray(3, arguments.Length - 3);
                    return method.Invoke(this, callArgs);
                }
            }
            throw new Exception("Could not resolve call to type " + this.GetType().Name);
        }
    }
}
