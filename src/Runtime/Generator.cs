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
                arguments.Add(Walk(currentScopeVar, arg));
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
            var innerScopeParam = Expression.Parameter(typeof(DictionaryBonsaiFunction));

            var expressions = new List<Expression>();
            foreach(var statement in block.Statements) {
                expressions.Add(Walk(innerScopeParam, statement));
            }

            return Expression.New(
                typeof(BlockBonsaiFunction).GetConstructor(new Type[] { typeof(Func<DictionaryBonsaiFunction, object>), typeof(DictionaryBonsaiFunction) }),
                Expression.Lambda(
                    Expression.Block(expressions),
                    innerScopeParam),
                currentScopeVar);
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

        public static Expression Walk(Expression currentScopeVar, Ast.DataDecl decl) {
            Expression handlerDict = 
                Expression.MakeIndex(
                    currentScopeVar,
                    typeof(DictionaryBonsaiFunction).GetProperty("Item",
                        typeof(BonsaiFunction), new Type[] { typeof(SymbolId) }),
                        new Expression[] { Expression.Constant("dataHandlers".ToSymbol()).ConvertTo<SymbolId>() });

            Expression handler = 
                Expression.MakeIndex(
                    handlerDict.ConvertTo<Dictionary<SymbolId, Func<IEnumerable<object>, object>>>(),
                    typeof(Dictionary<SymbolId, Func<IEnumerable<object>, object>>).GetProperty("Item"),
                    new Expression[] { Expression.Constant(decl.DataTypeId.ToSymbol()).ConvertTo<SymbolId>() });
              
            return Expression.Invoke(
                handler,
                new Expression[] { 
                    Expression.NewArrayInit(typeof(object), 
                    decl.Expressions.Select(
                        ex => Expression.Convert(Walk(currentScopeVar, ex), typeof(object)))) });
        }
        
        public static Expression Walk(Expression currentScopeVar, Ast.Node node) {
            Debug.Assert(node != null);
            var method = typeof(BonsaiExpressionGenerator).GetMethod("Walk", new Type[] { typeof(Expression), node.GetType() });
            Debug.Assert(method != null);
            try {
                return (Expression)method.Invoke(null, new object[] { currentScopeVar, node });
            } catch (TargetInvocationException ex) {
                throw ex.InnerException;
            }
        }
    }
}
