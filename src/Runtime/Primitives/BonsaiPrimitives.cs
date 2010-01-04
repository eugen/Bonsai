using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting;
using System.Reflection;
using System.Dynamic;
using System.Linq.Expressions;

namespace Bonsai.Runtime.Primitives {
    public static partial class BonsaiPrimitives  {
        public static bool TryBind(
            DynamicMetaObject target,
            DynamicMetaObject[] arguments,
            Type returnType,
            out DynamicMetaObject result)
        {
            result = null;
            if(target.Value == null)
                return false;
            var value = target.Value;

            // try to search for a "method call" type of handler
            if (arguments.Length >= 2 && 
                arguments[1].HasValue &&
                arguments[1].Value is SymbolId) 
            {
                var methodName = (SymbolId)arguments[1].Value;
                var method = typeof(BonsaiPrimitives).GetMethodsWith<PrimitiveAttribute>(
                    (mi, pi) => 
                        pi.Method == methodName && (
                            pi.Type.IsAssignableFrom(target.LimitType) || (
                                pi.Type.IsGenericTypeDefinition &&
                                target.LimitType.IsGenericType && 
                                target.LimitType.GetGenericTypeDefinition() == pi.Type))).FirstOrDefault();
                if(method != null) {
                    result = new DynamicMetaObject(
                        Expression.Convert(
                            Expression.Call(
                                null,
                                method,
                                new Expression[] {
                                    Expression.Convert(target.Expression, method.GetParameters()[0].ParameterType),
                                    arguments[0].Expression,
                                    Expression.NewArrayInit(
                                        typeof(object),
                                        arguments.Subarray(2).Select(a => Expression.Convert(a.Expression, typeof(object))))
                                }),
                            returnType),
                        BindingRestrictions.GetTypeRestriction(target.Expression, value.GetType()));
                    return true;
                }
            }

            // try to search for a "catch-all" binder
            // TODO 

            return false;
        }
    }
}
