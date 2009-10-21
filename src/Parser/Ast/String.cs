using System.Collections.Generic;
using SLE=System.Linq.Expressions;

namespace Bonsai.Ast {
    public class String : Atom {
        public string Value { get; internal set; }
    }
}