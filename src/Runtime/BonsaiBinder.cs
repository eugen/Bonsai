using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.Dynamic;
using Microsoft.Scripting;
using System.Reflection;
using Bonsai.Runtime.Primitives;
using System.Diagnostics;

namespace Bonsai.Runtime {
    public class BonsaiBinder : InvokeBinder {
        public BonsaiBinder(CallInfo callInfo)
            : base(callInfo) {
        }

        public override DynamicMetaObject FallbackInvoke(
            DynamicMetaObject target,
            DynamicMetaObject[] args,
            DynamicMetaObject errorSuggestion) 
        {
            var value = target.Value;

            // TODO: handle null value
            if (value == null) {
                throw new NotImplementedException("target.Value is null.");
            }

            // if target is a delegate, call it immediately
            if (target.LimitType.IsSubclassOf(typeof(Delegate))) {
                var parms = target.LimitType.GetMethod("Invoke").GetParameters();
                Expression[] callArgs = new Expression[args.Length];
                // convert the parameters, but skip the 1st parameter, which is the scope
                for (int i = 1; i < args.Length; i++) {
                    Expression argExpr = args[i].Expression;
                    argExpr = Expression.Convert(argExpr, parms[i-1].ParameterType);
                    callArgs[i-1] = argExpr;
                }

                var expression = Expression.Invoke(
                    Expression.Convert(target.Expression, target.LimitType),
                    callArgs);

                return new DynamicMetaObject(
                    expression,
                    BindingRestrictions.Empty);
            }

            // "normal" objects (i.e. non-dynamic instances) evaluate to themselves when called with no arguments
            if (args.Length == 1) {
                if (value != null && value.GetType() == ReturnType)
                    return target;
                else
                    return new DynamicMetaObject(Expression.Convert(target.Expression, ReturnType), BindingRestrictions.Empty);
            }

            // try calling a primitive            
            DynamicMetaObject result = null;
            if (BonsaiPrimitives.TryBind(target, args, this.ReturnType, out result))
                return result;

            // if the second argument is a symbol, fallback to invoking a
            // static (as-in "non-dynamic") member named like the symbol
            if (args[1].Value is SymbolId) {
                string name = ((SymbolId)args[1].Value).ToString();
                bool isSetter = false;
                // setters end with =, so remove that when searching for members
                if (name.EndsWith("=")) {
                    name = name.Substring(0, name.Length - 1);
                    isSetter = true;
                }

                var members = target.LimitType.GetMember(
                    name,
                    MemberTypes.Property | MemberTypes.Method,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);

                // method call
                if (!isSetter && members.Length > 0 && members[0] is MethodInfo) {
                    var method = (MethodInfo)members[0];
                    if (method.IsGenericMethod) {
                        var genericArgs = new Type[method.GetGenericArguments().Length];
                        for (int i = 0; i < genericArgs.Length; i++)
                            genericArgs[i] = typeof(object);
                        method = method.MakeGenericMethod(genericArgs);
                    }
                    var parms = method.GetParameters();
                    Expression[] callArgs = new Expression[args.Length-2];
                    // skip the target and the scope
                    for (int i = 2; i < args.Length; i++) {
                        Expression argExpr = args[i].Expression;
                        argExpr = Expression.Convert(argExpr, parms[i-2].ParameterType);
                        callArgs[i-2] = argExpr;
                    }
                        
                    Expression callExpr = Expression.Call(
                        target.Expression.ConvertTo(target.LimitType), 
                        (MethodInfo)method, 
                        callArgs);
                    if (method.ReturnType == typeof(void)) {
                        callExpr = Expression.Block(
                            callExpr,
                            Expression.Constant(null));
                    }
                    return new DynamicMetaObject(
                        callExpr.ConvertTo(this.ReturnType), 
                        BindingRestrictions.Empty);
                }
                // getter
                if (!isSetter && members.Length == 1 && members[0] is PropertyInfo) {
                    var property = (PropertyInfo)members[0];
                    var propParams = property.GetIndexParameters();
                    if (propParams.Length == args.Length - 2) {
                        return new DynamicMetaObject(
                            Expression.Convert(
                                Expression.Property(
                                    Expression.Convert(target.Expression, target.LimitType),
                                    (PropertyInfo)members[0],
                                    args.Subarray(2).Select((a, i) => Expression.Convert(a.Expression, propParams[i].ParameterType))),
                                this.ReturnType),
                            BindingRestrictions.Empty);
                    }
                }
                // setter
                if (isSetter && members.Length == 1 && members[0] is PropertyInfo) {
                    var method = ((PropertyInfo)members[0]).GetSetMethod();
                    var propParams = method.GetParameters();
                    if (propParams.Length == args.Length - 2) {
                        Expression callExpr =
                            Expression.Call(
                                Expression.Convert(target.Expression, target.LimitType),
                                method,
                                args.Subarray(2).Select((a, i) => Expression.Convert(a.Expression, propParams[i].ParameterType)));
                        if (method.ReturnType == typeof(void)) {
                            callExpr = Expression.Block(
                                callExpr,
                                Expression.Constant(null));
                        }
                        return new DynamicMetaObject(Expression.Convert(callExpr, this.ReturnType), BindingRestrictions.Empty);
                    }
                }
            }

            // when all else fails, try invoking a CatchAllPrimitive
            return BonsaiPrimitives.BindCatchAllPrimitive(target, args, this.ReturnType);
        }
    }
}
