using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Ast=Bonsai.Ast;
using Microsoft.Scripting.Utils;
using System.Dynamic;

namespace Bonsai.Runtime {
    public static class BonsaiExpressionGenerator {
        public static Expression Walk(Ast.Call call) {
            var arguments = new List<Expression>(call.Arguments.Count);
            arguments.Add(Walk(call.Target));
            foreach (var arg in call.Arguments)
                arguments.Add(Walk(arg));
            return Expression.Dynamic(
                new BonsaiBinder(new CallInfo(arguments.Count)),
                typeof(object),
                arguments);
        }

        public static Expression Walk(Ast.Number number) {
            return Expression.Constant(number.Value);
        }

        public static Expression Walk(Ast.String str) {
            return Expression.Constant(str.Value);
        }

        public static Expression Walk(Ast.Symbol symbol) {
            return Expression.Constant(
                Microsoft.Scripting.SymbolTable.StringToId(symbol.Name));
        }

        public static Expression Walk(Ast.Block block) {
            throw new NotImplementedException();
        }

        public static Expression Walk(Ast.Reference reference) {
            throw new NotImplementedException();
        }

        public static Expression Walk(Ast.Sequence sequence) {
            return Expression.Block(
                sequence.Statements.Select(c => Walk(c)));
        }

        public static Expression Walk(Ast.Node node) {
            Assert.NotNull(node);
            var method = typeof(BonsaiExpressionGenerator).GetMethod("Walk", new Type[] { node.GetType() });
            Assert.NotNull(method);
            return (Expression)method.Invoke(null, new object[] {node});
        }
    }
}
