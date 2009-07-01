using System;
using System.Collections.Generic;
using SLE=System.Linq.Expressions;
using System.Linq;
using System.Dynamic;
using Microsoft.Scripting.Actions;

namespace Bonsai.Ast {
    public class Call : Node {
        public Expression Target { get; internal set; }
        public IList<Expression> Arguments { get; private set; }

        public Call() {
            this.Arguments = new List<Expression>();
        }

        public override SLE.Expression Generate()
		{
            var argList = new List<SLE.Expression>(Arguments.Count + 1);
            argList.Add(Target.Generate());
            argList.AddRange(Arguments.Select(a => a.Generate()));

            throw new NotImplementedException();
            //return SLE.Expression.Dynamic(
            //    new BonsaiCallBinder(),
            //    typeof(Object),
            //    argList);
		}
    }
}