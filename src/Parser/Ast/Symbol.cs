using System.Collections.Generic;
using SLE=System.Linq.Expressions;

namespace Bonsai.Ast {
    public class Symbol : Atom {
        public string Name { get; internal set; }
    }
}