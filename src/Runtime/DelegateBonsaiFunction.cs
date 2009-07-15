using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bonsai.Runtime {
    public class DelegateBonsaiFunction : BonsaiFunction {
        private Func<object[], object> wrappedDelegate;
        public DelegateBonsaiFunction(Func<object[], object> wrappedDelegate) {
            this.wrappedDelegate = wrappedDelegate;
        }

        public override object Call(object[] arguments) {
            return wrappedDelegate.Invoke(arguments);    
        }
    }
}
