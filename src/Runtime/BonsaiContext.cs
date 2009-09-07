using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SLE=System.Linq.Expressions;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

using Microsoft.Scripting.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Ast;
using Microsoft.Scripting.Interpretation;
using Bonsai.Ast;
using System.Text;
using System.Diagnostics;

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

		protected override ScriptCode CompileSourceCode( SourceUnit sourceUnit, CompilerOptions options, ErrorSink errorSink ) {
            string text = sourceUnit.GetCode();
            var sequence = BonsaiParser.ParseString(text);
            var scope = new DictionaryBonsaiFunction();
            scope["print"] = new DelegateBonsaiFunction(
                args => {
                    args = args.Subarray(1, args.Length - 1);
                    var str = args.Aggregate("", (s, arg) => s + (s.Length > 0 ? ", " : "") + arg);
                    Console.WriteLine(str);
                    return str;
                });
            scope["="] = new DelegateBonsaiFunction(
                args => {
                    Debug.Assert(args.Length == 3);
                    Debug.Assert(args[0] is DictionaryBonsaiFunction);
                    var callScope = (DictionaryBonsaiFunction)args[0];
                    if (args[2] is BonsaiFunction)
                        callScope[(SymbolId)args[1]] = (BonsaiFunction)args[2];
                    else
                        callScope[(SymbolId)args[1]] = new DelegateBonsaiFunction(_ => args[2]);
                    return args[2];
                });

            SLE.Expression expr = BonsaiExpressionGenerator.Walk(
                SLE.Expression.Constant(scope),
                sequence);

            var lambda = Utils.Lambda(typeof(object), "Root");
            lambda.Parameters.Add(SLE.Expression.Parameter(typeof(BonsaiContext))); 
            lambda.Parameters.Add(SLE.Expression.Parameter(typeof(Scope)));
            lambda.Body = Utils.Convert(expr, typeof(object));

            return new InterpretedScriptCode(lambda.MakeLambda(), sourceUnit);
        }
    }
}
