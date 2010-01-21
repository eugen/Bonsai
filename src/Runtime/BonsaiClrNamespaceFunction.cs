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
            return new BonsaiClrClassFunction(Type.GetType(Namespace + "." + ((SymbolId)arguments[1])));
        }
    }
}
