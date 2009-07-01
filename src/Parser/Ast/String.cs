using System.Collections.Generic;
using SLE=System.Linq.Expressions;
using MSA = Microsoft.Scripting.Ast;

namespace Bonsai.Ast {
    public class String : Atom {
        public string Value { get; internal set; }

        public override SLE.Expression Generate()
		{
			return MSA.Utils.Constant(Value);
		}
    }
}