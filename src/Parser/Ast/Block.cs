using System.Collections.Generic;
using SLE=System.Linq.Expressions;

namespace Bonsai.Ast {
    public class Block : Expression {
        public IList<Call> Statements { get; private set; }
        public Block() {
            this.Statements = new List<Call>();
        }
    }
}