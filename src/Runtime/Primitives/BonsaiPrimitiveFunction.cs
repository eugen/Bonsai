using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting;
using System.Reflection;

namespace Bonsai.Runtime.Primitives {
    public class BonsaiPrimitive {
        public override object Call(object[] arguments) {
            var method = ResolveCall(arguments);
            if(method != null) {
                object[] callArgs = new object[3];
                callArgs[0] = arguments[0];
                callArgs[1] = arguments[1];
                callArgs[2] = arguments.Subarray(3, arguments.Length - 3);
                return method.Invoke(this, callArgs);
            } ele
        }

        internal static bool ResolveCall(object[] arguments, out MethodInfo result) {
            if (arguments.Length >= 3 && arguments[2] is SymbolId) {
                var method = typeof(T).GetMethodsWith<MapsToSymbolAttribute>(
                    (mi, attr) => attr.Symbol == (SymbolId)arguments[2]).FirstOrDefault();
                if(method != null) {
                    result = method;
                    return true;
                }
            }

            result = null;
            return false;
        }
    }
}
