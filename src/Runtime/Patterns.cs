using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting;

namespace Bonsai.Runtime {
    public interface IPattern {
        SymbolId ParameterName { get; }
        bool Test(object value);
    }

    public class SymbolPattern : IPattern {
        public SymbolId ParameterName { get; private set; }
        public SymbolPattern(SymbolId symbol) {
            this.ParameterName = symbol;
        }
        public bool Test(object value) {
            return true;
        }
    }

    public class EqPattern : IPattern {
        public SymbolId ParameterName { get; private set; }
        public object TestedValue { get; private set; }
        public EqPattern(SymbolId symbol, object testedValue) {
            this.ParameterName = symbol;
            this.TestedValue = testedValue;
        }

        public bool Test(object value) {
            return (
                TestedValue == null && value == null ||
                TestedValue.Equals(value));
        }
    }
    
    public class IsPattern : IPattern {
        public SymbolId ParameterName { get; private set; }
        public Type TestedType { get; private set; }

        public IsPattern(SymbolId symbol, object testedType) {
            this.ParameterName = symbol;
            this.TestedType = Type.GetType(testedType.ToString());
        }

        public bool Test(object value) {
            return value != null && value.GetType() == TestedType;
        }
    }

    public abstract class ComparisonPattern : IPattern {
        public SymbolId ParameterName { get; private set; }
        public object TestedValue { get; private set; }
        public ComparisonPattern(SymbolId symbol, object testedValue) {
                        if (!(testedValue is IComparable))
                throw new ArgumentException("testedValue must be IComparable", "testedValue");
            this.ParameterName = symbol;
            this.TestedValue = testedValue;
        }

        public abstract bool Test(object value);
    }

    public class LessPattern : ComparisonPattern {
        public LessPattern(SymbolId symbol, object testedValue)
            : base(symbol, testedValue) { }
        public override bool Test(object value) {
            return (
                value is IComparable &&
                ((IComparable)value).CompareTo(TestedValue) < 0);
        }
    }
    public class LessEqPattern : ComparisonPattern {
        public LessEqPattern(SymbolId symbol, object testedValue)
            : base(symbol, testedValue) { } 
        public override bool Test(object value) {
            return (
                value is IComparable &&
                ((IComparable)value).CompareTo(TestedValue) <= 0);
        }
    }
    public class GreaterPattern : ComparisonPattern {
        public GreaterPattern(SymbolId symbol, object testedValue)
            : base(symbol, testedValue) { }
        public override bool Test(object value) {
            return (
                value is IComparable &&
                ((IComparable)value).CompareTo(TestedValue) > 0);
        }
    }
    public class GreaterEqPattern : ComparisonPattern {
        public GreaterEqPattern(SymbolId symbol, object testedValue)
            : base(symbol, testedValue) { }
        public override bool Test(object value) {
            return (
                value is IComparable &&
                ((IComparable)value).CompareTo(TestedValue) >= 0);
        }
    }
}
