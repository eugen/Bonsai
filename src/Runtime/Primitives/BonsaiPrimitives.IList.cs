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

        [Primitive(typeof(IList<>), "shuffle")]
        public static IList<T> IListShuffle<T>(IList<T> target, DictionaryBonsaiFunction scope, object[] args) {
            // create copy
            var copy = new List<T>(target);
            var rng = new Random();
            var n = target.Count;
            // Knuth's shuffle
            for(int i = n - 1; i > 0; i--) {
                int j = rng.Next(0, n);
                var tmp = copy[j];
                copy[j] = copy[i];
                copy[i] = tmp;
            }
            return copy;
        }

        [Primitive(typeof(IList<>), "join")]
        public static string IListJoin<T>(IList<T> target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 1 && args[0] is string);
            var separator = (string)args[0];
            StringBuilder sb = new StringBuilder();
            foreach(var e in target) {
                sb.Append(e.ToString());
                sb.Append(separator);
            }
            if(sb.Length > 0)
                sb.Remove(sb.Length - separator.Length, separator.Length);
            return sb.ToString();
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