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
                var symbol = (SymbolId)arguments[2];
                foreach(MethodInfo mi in this.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)) {
                    var attributes = mi.GetCustomAttributes(typeof(MapsToSymbolAttribute), false);
                    if (attributes.Length > 0) {
                        var mapper = (MapsToSymbolAttribute)attributes[0];
                        if (mapper.Symbol == symbol) {
                            object[] callArgs = new object[3];
                            callArgs[0] = arguments[0];
                            callArgs[1] = arguments[1];
                            callArgs[2] = arguments.Subarray(3, arguments.Length - 3);
                            return mi.Invoke(this, callArgs);
                        }
                    }
                }
            }
            throw new Exception("Could not resolve call to type " + this.GetType().Name);
        }
    }
}
