using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Scripting;

namespace Bonsai.Runtime {
    public class BonsaiClrNamespaceFunction : BonsaiFunction {
        public string Namespace { get; private set; }

        public BonsaiClrNamespaceFunction(string nameSpace) {
            this.Namespace = nameSpace;
        }

        public override object Call(object[] arguments) {
            Debug.Assert(arguments.Length == 2);
            var clazzStr = Namespace + "." + ((SymbolId)arguments[1]);
            var clazz = Type.GetType(clazzStr);
            if (clazz == null)
                throw new ArgumentException(String.Format("Could not find class named '{0}' in namespace '{1}'", clazzStr, Namespace));
            return new BonsaiClrClassFunction(clazz);
        }
    }
}
