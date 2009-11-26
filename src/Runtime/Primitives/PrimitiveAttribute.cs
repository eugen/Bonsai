using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting;
using System.Reflection;

namespace Bonsai.Runtime.Primitives {
    public class PrimitiveAttribute : Attribute {
        public Type Type { get; set; }
        public SymbolId Method { get; set; }

        public PrimitiveAttribute(Type type) {
            this.Type = type;
        }

        public PrimitiveAttribute(Type type, string method) {
            this.Type = type;
            this.Method = SymbolTable.StringToId(method);
        }
    }
}