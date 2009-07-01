using System.Collections.Generic;
using SLE=System.Linq.Expressions;

namespace Bonsai.Ast {
    public class Number : Atom {
        public decimal Value { get; internal set; }

        public override SLE.Expression Generate()
		{
			return SLE.Expression.Constant(Value, typeof(decimal));
		}
    }
}