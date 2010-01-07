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

        [CatchAllPrimitive(typeof(IList<>))]
        public static object IListGetItem<T>(IList<T> target, DictionaryBonsaiFunction scope, object[] args) {
            if (args.Length == 1 && args[0] is decimal)
                return target[(int)(decimal)args[0]];
            else
                throw new MissingMethodException("Binding failed (on an IList<T>)");
        }
    }
}