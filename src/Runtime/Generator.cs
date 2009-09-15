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
        public static Expression Walk(Expression currentScopeVar, Expression nextScopeVar, Ast.Call call) {
            var newScopeInitializationExpression = 
                Expression.Assign(
                nextScopeVar, 
                Expression.New(
                    typeof(DictionaryBonsaiFunction).GetConstructor(new Type[] { typeof(BonsaiFunction) }),
                    currentScopeVar));

            var arguments = new List<Expression>(call.Arguments.Count);
            arguments.Add(Walk(currentScopeVar, nextScopeVar, call.Target));
            arguments.Add(currentScopeVar);
            foreach (var arg in call.Arguments) {
                arguments.Add(
                    Expression.Dynamic(
                        new BonsaiBinder(new CallInfo(2)),
                        typeof(object),
                        Walk(currentScopeVar, nextScopeVar, arg),
                        currentScopeVar));
            }

            return Expression.Block(
                newScopeInitializationExpression,
                Expression.Dynamic(
                    new BonsaiBinder(new CallInfo(arguments.Count)),
                    typeof(object),
                    arguments));
        }

        public static Expression Walk(Expression currentScopeVar, Expression nextScopeVar, Ast.Number number) {
            return Expression.Constant(number.Value);
        }

        public static Expression Walk(Expression currentScopeVar, Expression nextScopeVar, Ast.String str) {
            return Expression.Constant(str.Value);
        }

        public static Expression Walk(Expression currentScopeVar, Expression nextScopeVar, Ast.Symbol symbol) {
            return Expression.Constant(
                Microsoft.Scripting.SymbolTable.StringToId(symbol.Name));
        }

        public static Expression Walk(Expression currentScopeVar, Expression nextScopeVar, Ast.Block block) {
            var innerCurrentScopeVar = Expression.Variable(typeof(DictionaryBonsaiFunction));
            var innerNewScopeVariable = Expression.Variable(typeof(DictionaryBonsaiFunction));

            var expressions = new Expression[block.Statements.Count + 1];
            expressions[0] = Expression.Assign(innerCurrentScopeVar, nextScopeVar);
            for (int i = 0; i < block.Statements.Count; i++) {
                expressions[i + 1] = Walk(currentScopeVar, nextScopeVar, block.Statements[i]);
            }

            return Expression.New(
                typeof(BlockBonsaiFunction).GetConstructor(new Type[] { typeof(Func<object>) }),
                Expression.Lambda(Expression.Block(
                    new ParameterExpression[] { innerCurrentScopeVar, innerNewScopeVariable },
                    expressions)));
        }

        public static Expression Walk(Expression currentScopeVar, Expression nextScopeVar, Ast.Reference reference) {
            return Expression.MakeIndex(
                currentScopeVar,
                typeof(DictionaryBonsaiFunction).GetProperty("Item", 
                    typeof(BonsaiFunction), new Type[] { typeof(SymbolId) }), 
                new Expression[] { Expression.Constant(SymbolTable.StringToId(reference.Name)) });
        }

        public static Expression Walk(Expression currentScopeVar, Expression nextScopeVar, Ast.Sequence sequence) {
            return Expression.Block(
                sequence.Statements.Select(c => Walk(currentScopeVar, nextScopeVar, c)));
        }

        public static Expression Walk(Expression currentScopeVar, Expression nextScopeVar, Ast.Node node) {
            Assert.NotNull(node);
            var method = typeof(BonsaiExpressionGenerator).GetMethod("Walk", new Type[] { typeof(Expression), typeof(Expression), node.GetType() });
            Assert.NotNull(method);
            try {
                return (Expression)method.Invoke(null, new object[] { currentScopeVar, nextScopeVar, node });
            } catch (TargetInvocationException ex) {
                throw ex.InnerException;
            }
        }
    }
}
