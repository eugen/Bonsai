using System.Collections.Generic;
using SLE=System.Linq.Expressions;
using Microsoft.Scripting;
using MSA = Microsoft.Scripting.Ast;
using System;

namespace Bonsai.Ast {
    public class Reference : Atom {
        public string Name { get; internal set; }
	}
}