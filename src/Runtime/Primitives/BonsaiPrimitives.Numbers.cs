﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Diagnostics;

namespace Bonsai.Runtime.Primitives {
    public static partial class BonsaiPrimitives {
        // TODO: Find a better way for this... 
   
        [Primitive(typeof(decimal), "+")]
        public static decimal Add(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            decimal result = target;
            foreach (IConvertible o in args) {
                result += o.ToDecimal(CultureInfo.InvariantCulture);
            }

            return result;
        }

        [Primitive(typeof(decimal), "-")]
        public static decimal Substract(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            decimal result = target;
            foreach (IConvertible o in args) {
                result -= o.ToDecimal(CultureInfo.InvariantCulture);
            }

            return result;
        }

        [Primitive(typeof(decimal), "*")]
        public static decimal Multiply(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            decimal result = target;
            foreach (IConvertible o in args) {
                result *= o.ToDecimal(CultureInfo.InvariantCulture);
            }

            return result;
        }

        [Primitive(typeof(decimal), "/")]
        public static decimal Divide(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            decimal result = target;
            foreach (IConvertible o in args) {
                result /= o.ToDecimal(CultureInfo.InvariantCulture);
            }

            return result;
        }

        [Primitive(typeof(decimal), "^")]
        public static decimal Power(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 1 && args[0] is decimal);
            return (decimal)Math.Pow((double)target, (double)(decimal)args[0]);
        }

        [Primitive(typeof(decimal), "%")]
        public static decimal Modulo(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 1 && args[0] is decimal);
            return (decimal)(target % (decimal)args[0]);
        }

        [Primitive(typeof(decimal), "round")]
        public static decimal Round(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 0);
            return Math.Round(target);
        }

        [Primitive(typeof(decimal), "ceiling")]
        public static decimal Ceiling(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 1 && args[0] is decimal);
            return Math.Ceiling(target);
        }

        [Primitive(typeof(decimal), "floor")]
        public static decimal Floor(decimal target, DictionaryBonsaiFunction scope, object[] args) {
            Debug.Assert(args.Length == 1 && args[0] is decimal);
            return Math.Floor(target);
        }
    }
}
