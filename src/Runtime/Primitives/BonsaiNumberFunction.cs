using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Bonsai.Runtime.Primitives {
    public class BonsaiNumberFunction : BonsaiPrimitiveFunction {
        public decimal Value {
            get;
            set; 
        }

        public BonsaiNumberFunction(decimal value) {
            this.Value = value;
        }

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
    }
}
