using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Scripting;
using System.Reflection;

namespace Bonsai.Runtime {
    public class BonsaiClrClassFunction : BonsaiFunction {
        private Type importedType;

        public Type Class { get; private set; }

        public BonsaiClrClassFunction(Type clazz) {
            this.Class = clazz;
        }

        public override object Call(object[] arguments) {
            if (arguments.Length == 1) {
                return this;
            } else {
                Debug.Assert(arguments[1] is SymbolId);
                var memberName = ((SymbolId)arguments[1]).ToString();
                switch (memberName) {
                    case "new":
                        return InvokeStaticMember(arguments.Subarray(2, arguments.Length - 2), MemberTypes.Constructor);
                    default:
                        return InvokeStaticMember(arguments.Subarray(2, arguments.Length - 2), MemberTypes.Property | MemberTypes.Method, memberName);
                }
            }
        }

        private object InvokeStaticMember(object[] arguments, MemberTypes memberTypes, string memberName = null) {
            var clazz = this.Class;

            var candidates = new List<MethodBase>();

            if ((memberTypes & MemberTypes.Constructor) != 0) {
                candidates.AddRange(clazz.GetConstructors(BindingFlags.Public | BindingFlags.Instance));
            }
            if ((memberTypes & MemberTypes.Method) != 0) {
                candidates.AddRange(
                    clazz.GetMethods(BindingFlags.Static | BindingFlags.Public)
                    .Where(mi => mi.Name == memberName));
            }
            if ((memberTypes & MemberTypes.Property) != 0) {
                candidates.AddRange(
                    clazz.GetProperties(BindingFlags.Static | BindingFlags.Public)
                    .Where(pi => pi.Name == memberName)
                    .SelectMany(pi => new MethodInfo[] { pi.GetGetMethod(), pi.GetSetMethod() })
                    .Where(mi => mi != null));
            }
            
            candidates = candidates.FindAll(mi => mi.GetParameters().Length == arguments.Length);

            foreach (var mi in candidates) {
                var pis = mi.GetParameters();
                bool accepted = true;
                for(int i = 0; i < pis.Length; i++) {
                    var pi = pis[i];
                    var arg = arguments[i];
                    if (!pi.ParameterType.IsAssignableFrom(arg.GetType())) {
                        accepted = false;
                        break;
                    }   
                }
                if (accepted) { // we found a good candidate
                    if (mi is ConstructorInfo)
                        return ((ConstructorInfo)mi).Invoke(arguments);
                    else
                        return mi.Invoke(null, arguments);
                }
            }
            throw new MissingMemberException(String.Format("Could not find a compatible member named '{0}' in class '{1}'", memberName, this.Class));
        }
    }
}
