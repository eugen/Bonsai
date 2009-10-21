
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using Microsoft.Scripting;
using System.Linq.Expressions;
using Microsoft.Scripting.Runtime;

namespace Bonsai.Runtime
{
    public sealed class BonsaiScriptCode : ScriptCode
    {
        Func<object> function;

        public BonsaiScriptCode(SourceUnit sourceUnit, Func<object> function)
            : base(sourceUnit)
        {
            this.function = function;
        }

        public override object Run()
        {
            return Run(new Scope());
        }

        public override object Run(Scope scope)
        {
            return function();
        }
    }
}
