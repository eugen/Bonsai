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
        public static Expression Walk(ConstantExpression scope, Ast.Call call) {
            Debug.Assert(scope.Value is DictionaryBonsaiFunction);
            var arguments = new List<Expression>(call.Arguments.Count);
            arguments.Add(Walk(scope, call.Target));
            arguments.Add(scope);
            foreach (var arg in call.Arguments)
                arguments.Add(
                    Expression.Dynamic(
                    new BonsaiBinder(new CallInfo(2)), typeof(object), Walk(scope, arg), scope));
            return Expression.Dynamic(
                new BonsaiBinder(new CallInfo(arguments.Count)),
                typeof(object),
                arguments);
        }

        public static Expression Walk(ConstantExpression scope, Ast.Number number) {
            return Expression.Constant(number.Value);
        }

        public static Expression Walk(ConstantExpression scope, Ast.String str) {
            return Expression.Constant(str.Value);
        }

        public static Expression Walk(ConstantExpression scope, Ast.Symbol symbol) {
            return Expression.Constant(
                Microsoft.Scripting.SymbolTable.StringToId(symbol.Name));
        }

        public static Expression Walk(ConstantExpression scope, Ast.Block block) {
            Debug.Assert(scope.Value is DictionaryBonsaiFunction);
            var oldScope = (DictionaryBonsaiFunction)scope.Value;
            var newScope = new DictionaryBonsaiFunction(oldScope);
            var newScopeExpression = Expression.Constant(newScope);
            return Expression.New(
                typeof(BlockBonsaiFunction).GetConstructor(new Type[] { typeof(Func<object>) }),
                Expression.Lambda(Expression.Block(block.Statements.Select(st => Walk(newScopeExpression, st)))));
        }

        public static Expression Walk(ConstantExpression scope, Ast.Reference reference) {
            Debug.Assert(scope.Value is DictionaryBonsaiFunction);
            return Expression.MakeIndex(
                scope,
                typeof(DictionaryBonsaiFunction).GetProperty("Item", 
                    typeof(BonsaiFunction), new Type[] { typeof(SymbolId) }), 
                new Expression[] { Expression.Constant(SymbolTable.StringToId(reference.Name)) });
        }

        public static Expression Walk(ConstantExpression scope, Ast.Sequence sequence) {
            return Expression.Block(
                sequence.Statements.Select(c => Walk(scope, c)));
        }

        public static Expression Walk(ConstantExpression scope, Ast.Node node) {
            Assert.NotNull(node);
            var method = typeof(BonsaiExpressionGenerator).GetMethod("Walk", new Type[] { typeof(ConstantExpression), node.GetType() });
            Assert.NotNull(method);
            try {
                return (Expression)method.Invoke(null, new object[] { scope, node });
            } catch (TargetInvocationException ex) {
                throw ex.InnerException;
            }
        }
    }
}
