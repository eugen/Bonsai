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
}
