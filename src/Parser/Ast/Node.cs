using System;
using System.Linq.Expressions;
using SLE=System.Linq.Expressions;

namespace Bonsai.Ast {
    public abstract class Node {
        public abstract SLE.Expression Generate();
			
    }
}