using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bonsai.Runtime.Primitives {
    public class CatchAllPrimitiveAttribute : Attribute {
        public Type Type { get; set; }
        
        public CatchAllPrimitiveAttribute(Type type) {
            this.Type = type;
        }
    }
}
