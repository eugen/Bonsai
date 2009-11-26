using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Bonsai.Runtime.Primitives {
    public static partial class BonsaiPrimitives  {
        [Primitive(typeof(string), "upcase")]
        public static string Upcase(string target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 0);
            return target.ToUpperInvariant();
        }
        [Primitive(typeof(string), "downcase")]
        public static string Downcase(string target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 0);
            return target.ToLowerInvariant();
        }
        [Primitive(typeof(string), "capitalize")]
        public static string Capitalize(string target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 0);
            return Regex.Replace(target, @"\b\w", new MatchEvaluator(m => m.Value.ToUpperInvariant()));
        }
        [Primitive(typeof(string), "contains")]
        public static bool Contains(string target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 1 && args[0] is IConvertible);
            return target.Contains(((IConvertible)args[0]).ToString());
        }
        [Primitive(typeof(string), "+")]
        public static string Concatenate(string target, DictionaryBonsaiFunction scope, object[] args) {
            StringBuilder sb = new StringBuilder(target, target.Length + 10);
            foreach (var arg in args)
                if (arg != null)
                    sb.Append(arg.ToString());
            return sb.ToString();
        }
    }
}
