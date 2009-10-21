using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Bonsai.Runtime.Primitives {
    public class BonsaiStringFunction : BonsaiPrimitiveFunction {
        [MapsToSymbol("upcase")]
        public string Upcase(string target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 0);
            return target.ToUpperInvariant();
        }
        [MapsToSymbol("downcase")]
        public string Downcase(string target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 0);
            return target.ToLowerInvariant();
        }
        [MapsToSymbol("capitalize")]
        public string Capitalize(string target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 0);
            return Regex.Replace(target, @"\b\w", new MatchEvaluator(m => m.Value.ToUpperInvariant()));
        }
        [MapsToSymbol("contains")]
        public bool Contains(string target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 1 && args[0] is IConvertible);
            return target.Contains(((IConvertible)args[0]).ToString());
        }
        [MapsToSymbol("+")]
        public string Concatenate(string target, DictionaryBonsaiFunction scope, object[] args) {
            StringBuilder sb = new StringBuilder(target, target.Length + 10);
            foreach (var arg in args)
                if (arg != null)
                    sb.Append(arg.ToString());
            return sb.ToString();
        }
    }
}
