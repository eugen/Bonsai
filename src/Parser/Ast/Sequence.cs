using System;
using System.Collections.Generic;
using SLE=System.Linq.Expressions;

namespace Bonsai.Ast {
    public class Sequence : Expression {
        public List<Call> Statements { get; private set; }
        public Sequence() {
            this.Statements = new List<Call>();
        }

        public Sequence(IList<Call> calls) {
            this.Statements = new List<Call>(calls);
        }

        public override SLE.Expression Generate() {
            return SLE.Expression.Block(
                Statements.ConvertAll(call => call.Generate()));
        }
    }
}