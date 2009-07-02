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
    }
}