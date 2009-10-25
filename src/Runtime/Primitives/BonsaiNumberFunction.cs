using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Diagnostics;

namespace Bonsai.Runtime.Primitives {
    public class BonsaiNumberFunction : BonsaiPrimitiveFunction {
        [MapsToSymbol("+")]
        public decimal Add(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            decimal result = target;
            foreach (IConvertible o in args) {
                result += o.ToDecimal(CultureInfo.InvariantCulture);
            }

            return result;
        }

        [MapsToSymbol("-")]
        public decimal Substract(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            decimal result = target;
            foreach (IConvertible o in args) {
                result -= o.ToDecimal(CultureInfo.InvariantCulture);
            }

            return result;
        }

        [MapsToSymbol("*")]
        public decimal Multiply(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            decimal result = target;
            foreach (IConvertible o in args) {
                result *= o.ToDecimal(CultureInfo.InvariantCulture);
            }

            return result;
        }

        [MapsToSymbol("/")]
        public decimal Divide(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            decimal result = target;
            foreach (IConvertible o in args) {
                result /= o.ToDecimal(CultureInfo.InvariantCulture);
            }

            return result;
        }

        [MapsToSymbol("^")]
        public decimal Power(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 1 && args[0] is decimal);
            return (decimal)Math.Pow((double)target, (double)(decimal)args[0]);
        }
    }
}
