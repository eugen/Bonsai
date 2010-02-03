using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Bonsai.Runtime.Primitives {
    public partial class BonsaiPrimitives {
        [CatchAllPrimitive(typeof(IDictionary<,>))]
        public static object IDictionaryGetItem<TKey, TValue>(IDictionary<TKey, TValue> target, DictionaryBonsaiFunction scope, object[] args) {
            if (args.Length == 1 && args[0] is TKey && target.ContainsKey((TKey)args[0]))
                return target[(TKey)args[0]];
            else
                throw new MissingMethodException("Binding failed (on an IDictionary<TKey, TValue>)");
        }

        [Primitive(typeof(IDictionary<,>), "toList")]
        public static List<Tuple<T1, T2>> ToList<T1, T2>(IDictionary<T1, T2> target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 0);
            return target.Select(pair => Tuple.Create(pair.Key, pair.Value)).ToList();
        }
    }
}
