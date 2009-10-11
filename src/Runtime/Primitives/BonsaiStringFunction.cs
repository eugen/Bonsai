using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Bonsai.Runtime.Primitives {
    public class BonsaiStringFunction : BonsaiPrimitiveFunction {
        [MapsToSymbol("upcase")]
        public string Upcase(string target, DictionaryBonsaiFunction scope, object[] args) {
            return target.ToUpperInvariant();
        }
        [MapsToSymbol("downcase")]
        public string Downcase(string target, DictionaryBonsaiFunction scope, object[] args) {
            return target.ToLowerInvariant();
        }
        [MapsToSymbol("capitalize")]
        public string Capitalize(string target, DictionaryBonsaiFunction scope, object[] args) {
            return Regex.Replace(target, @"\b\w", new MatchEvaluator(m => m.Value.ToUpperInvariant()));
        }
        [MapsToSymbol("contains")]
        public bool Contains(string target, DictionaryBonsaiFunction scope, object[] args) {
            return target.Contains(((IConvertible)args[0]).ToString());
        }
    }
}
