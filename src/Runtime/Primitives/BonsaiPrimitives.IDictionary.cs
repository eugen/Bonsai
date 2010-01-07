using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bonsai.Runtime.Primitives {
    public partial class BonsaiPrimitives {
        [CatchAllPrimitive(typeof(IDictionary<,>))]
        public static object IDictionaryGetItem<TKey, TValue>(IDictionary<TKey, TValue> target, DictionaryBonsaiFunction scope, object[] args) {
            if (args.Length == 1 && args[0] is TKey && target.ContainsKey((TKey)args[0]))
                return target[(TKey)args[0]];
            else
                throw new MissingMethodException("Binding failed (on an IDictionary<TKey, TValue>)");
        }
    }
}
