using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting;
using System.Reflection;
using System.Dynamic;
using System.Linq.Expressions;

namespace Bonsai.Runtime.Primitives {
    public static partial class BonsaiPrimitives {
        public static bool TryBind(
            DynamicMetaObject target,
            DynamicMetaObject[] arguments,
            Type returnType,
            out DynamicMetaObject result)
        {
            result = null;
            if (target.Value == null)
                return false;
            var value = target.Value;

            if (arguments.Length >= 2 &&
                arguments[1].HasValue &&
                arguments[1].Value is SymbolId) {
                var methodName = (SymbolId)arguments[1].Value;

                var method = typeof(BonsaiPrimitives).GetMethodsWith<PrimitiveAttribute>(
                    (mi, pi) =>
                        pi.Method == methodName && (
                        pi.Type == null || (
                            target.LimitType.IsAssignableFrom(pi.Type) || (
                                pi.Type.IsGenericTypeDefinition &&
                                target.LimitType.IsGenericType &&
                                pi.Type.MakeGenericType(target.LimitType.GetGenericArguments()).IsAssignableFrom(target.LimitType))))).FirstOrDefault();

                // assume that if the method is generic than the matched type is also generic and it gets the same parameters
                if (method != null && method.IsGenericMethodDefinition)
                    method = method.MakeGenericMethod(target.LimitType.GetGenericArguments());

                if (method != null) {
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

            return false;
        }

        public static DynamicMetaObject BindCatchAllPrimitive(DynamicMetaObject target, DynamicMetaObject[] args, Type returnType) {
            var method = typeof(BonsaiPrimitives).GetMethodsWith<CatchAllPrimitiveAttribute>(
                (mi, capi) => 
                       capi.Type == null || (
                           target.LimitType.IsAssignableFrom(capi.Type) || (
                               capi.Type.IsGenericTypeDefinition &&
                               target.LimitType.IsGenericType &&
                               capi.Type.GetGenericArguments().Length == target.LimitType.GetGenericArguments().Length &&
                               capi.Type.MakeGenericType(target.LimitType.GetGenericArguments()).IsAssignableFrom(target.LimitType))))
                .FirstOrDefault();

            // assume that if the method is generic than the matched type is also generic and it gets the same parameters
            if (method != null && method.IsGenericMethodDefinition)
                method = method.MakeGenericMethod(target.LimitType.GetGenericArguments()); 
            
            if (method != null) {
                return new DynamicMetaObject(
                       Expression.Convert(
                           Expression.Call(
                               null,
                               method,
                               new Expression[] {
                                    Expression.Convert(target.Expression, method.GetParameters()[0].ParameterType),
                                    args[0].Expression,
                                    Expression.NewArrayInit(
                                        typeof(object),
                                        args.Subarray(1).Select(a => Expression.Convert(a.Expression, typeof(object))))
                                }),
                           returnType),
                       BindingRestrictions.GetTypeRestriction(target.Expression, target.Value.GetType()));
            } else {
                throw new Exception("Binding failed");
            }
        }
    }
}
