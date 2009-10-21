using System.Collections.Generic;
using SLE=System.Linq.Expressions;
using System;

namespace Bonsai.Ast {
    public class Reference : Atom {
        public string Name { get; internal set; }
	}
}