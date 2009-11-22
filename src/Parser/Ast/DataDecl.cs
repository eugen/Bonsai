using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bonsai.Ast;

namespace Bonsai.Ast
{
    public class DataDecl : Expression
    {
        public string DataTypeId { get; set; }
        public List<Expression> Expressions { get; private set; }

        public DataDecl() {
            this.Expressions = new List<Expression>();
        }
    }
}
