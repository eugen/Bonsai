using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bonsai.Runtime {
    public class BlockBonsaiFunction : BonsaiFunction {
        public Func<object> Function { get; private set; }
        public BlockBonsaiFunction(Func<object> function) {
            this.Function = function;
        }
        public override object Call(object[] arguments) {
            return Function();
        }
    }
}
