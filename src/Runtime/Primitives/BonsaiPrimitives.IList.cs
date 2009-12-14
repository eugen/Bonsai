using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Diagnostics;

namespace Bonsai.Runtime.Primitives {
    public partial class BonsaiPrimitives {
        [Primitive(typeof(IList<>), "contains")]
        public static bool IListContains<T>(IList<T> target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 1 && args[0] is T);
            return target.Contains((T)args[0]);
        }
       
    }
}