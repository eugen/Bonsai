using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SLE=System.Linq.Expressions;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

using Microsoft.Scripting.Runtime;
using Microsoft.Scripting;
using Bonsai.Ast;
using System.Text;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Bonsai.Runtime
{
	public class BonsaiContext : LanguageContext
	{
        public BonsaiContext(ScriptDomainManager manager, IDictionary<string, object> options)
			: base( manager ) {
        }

        private static Guid bonsaiGuid = new Guid("5B2C1B50-2148-11DE-B8BC-AF7356D89593");
        public override Guid LanguageGuid {
            get {
                return bonsaiGuid;
            }
        }

		public override ScriptCode CompileSourceCode(
            SourceUnit sourceUnit, 
            CompilerOptions options, 
            ErrorSink errorSink ) 
        {
            string text = sourceUnit.GetCode();
            var sequence = BonsaiParser.ParseString(text);
           
            var scope = SLE.Expression.Variable(typeof(DictionaryBonsaiFunction), "Prelude"); 

            LambdaExpression expr = SLE.Expression.Lambda(
                SLE.Expression.Block(
                    new ParameterExpression[] { scope },
                    SLE.Expression.Assign(scope, SLE.Expression.New(typeof(PreludeFunction))),
                    BonsaiExpressionGenerator.Walk(
                        scope,
                        sequence)));

            var function = (Func<object>)expr.Compile();
            return new BonsaiScriptCode(sourceUnit, function);
        }
    }
}
