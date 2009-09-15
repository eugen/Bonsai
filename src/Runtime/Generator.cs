using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Ast=Bonsai.Ast;
using Microsoft.Scripting.Utils;
using System.Dynamic;
using System.Reflection;
using Microsoft.Scripting.Runtime;
using System.Diagnostics;
using Microsoft.Scripting;

namespace Bonsai.Runtime {
    public static class BonsaiExpressionGenerator {
        public static Expression Walk(Expression currentScopeVar, Ast.Call call) {
            var arguments = new List<Expression>(call.Arguments.Count + 2);
            arguments.Add(Walk(currentScopeVar, call.Target));
            arguments.Add(currentScopeVar);
            foreach (var arg in call.Arguments) {
                arguments.Add(
                    Expression.Dynamic(
                        new BonsaiBinder(new CallInfo(2)),
                        typeof(object),
                        Walk(currentScopeVar, arg),
                        currentScopeVar));
            }

            return Expression.Dynamic(
                new BonsaiBinder(new CallInfo(arguments.Count)),
                typeof(object),
                arguments);
        }

        public static Expression Walk(Expression currentScopeVar, Ast.Number number) {
            return Expression.Constant(number.Value);
        }

        public static Expression Walk(Expression currentScopeVar, Ast.String str) {
            return Expression.Constant(str.Value);
        }

        public static Expression Walk(Expression currentScopeVar, Ast.Symbol symbol) {
            return Expression.Constant(
                Microsoft.Scripting.SymbolTable.StringToId(symbol.Name));
        }

        public static Expression Walk(Expression currentScopeVar, Ast.Block block) {
            var innerScopeVar = Expression.Variable(typeof(DictionaryBonsaiFunction));

            var expressions = new Expression[block.Statements.Count];
            for (int i = 0; i < block.Statements.Count; i++) {
                expressions[i] = Walk(innerScopeVar, block.Statements[i]);
            }

            return Expression.Block(
                new ParameterExpression[] { innerScopeVar },
                Expression.Assign(
                    innerScopeVar,
                    Expression.New(
                        typeof(DictionaryBonsaiFunction).GetConstructor(new Type[] { typeof(BonsaiFunction) }),
                        currentScopeVar)),
                Expression.New(
                    typeof(BlockBonsaiFunction).GetConstructor(new Type[] { typeof(Func<object>), typeof(DictionaryBonsaiFunction) }),
                    Expression.Lambda(Expression.Block(expressions)),
                    innerScopeVar));
        }

        public static Expression Walk(Expression currentScopeVar, Ast.Reference reference) {
            return Expression.MakeIndex(
                currentScopeVar,
                typeof(DictionaryBonsaiFunction).GetProperty("Item", 
                    typeof(BonsaiFunction), new Type[] { typeof(SymbolId) }), 
                new Expression[] { Expression.Constant(SymbolTable.StringToId(reference.Name)) });
        }

        public static Expression Walk(Expression currentScopeVar, Ast.Sequence sequence) {
            return Expression.Block(
                sequence.Statements.Select(c => Walk(currentScopeVar, c)));
        }

        public static Expression Walk(Expression currentScopeVar, Ast.Node node) {
            Assert.NotNull(node);
            var method = typeof(BonsaiExpressionGenerator).GetMethod("Walk", new Type[] { typeof(Expression), node.GetType() });
            Assert.NotNull(method);
            try {
                return (Expression)method.Invoke(null, new object[] { currentScopeVar, node });
            } catch (TargetInvocationException ex) {
                throw ex.InnerException;
            }
        }
    }
}
