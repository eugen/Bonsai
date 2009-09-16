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

namespace Bonsai.Runtime {
    public class BonsaiBinder : InvokeBinder {
        public BonsaiBinder(CallInfo callInfo)
            : base(callInfo) {
        }

        public override DynamicMetaObject FallbackInvoke(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject errorSuggestion) {
            var value = target.Value;
            if (value == null) {
                throw new NotImplementedException("target.Value is null.");
            }
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
            // "normal" objects evaluate to themselves when called with no arguments
            if(args.Length == 1)
                return target;

            // Try to fallback to a BonsaiNumberFunction
            if (value is decimal) {
                return new DynamicMetaObject(
                    Expression.Call(
                        Expression.New(typeof(BonsaiNumberFunction).GetConstructor(new Type[0])),
                        typeof(BonsaiFunction).GetMethod("Call"),
                        Expression.NewArrayInit(
                            typeof(object), 
                            (new Expression[] { Expression.Convert(target.Expression, typeof(object)) }).Union(args.Select(a => Expression.Convert(a.Expression, typeof(object)))))),
                    BindingRestrictions.GetTypeRestriction(target.Expression, typeof(decimal)));
            } 

            // if the second argument is a symbol, fallback to invoking a member called like that
            if (args[1].Value is SymbolId) {
                string name = ((SymbolId)args[1].Value).ToString();
                // setters end with =, so remove that when searching for members
                if (name.EndsWith("="))
                    name = name.Substring(1, name.Length - 1);

                var members = target.LimitType.GetMember(
                    name,
                    MemberTypes.Property | MemberTypes.Method,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);

                // method call
                if (members.Length > 0 && members[0] is MethodInfo) {
                    var method = (MethodInfo)members[0];
                    var parms = method.GetParameters();
                    Expression[] callArgs = new Expression[args.Length-2];
                    // skip the target and the scope
                    for (int i = 2; i < args.Length; i++) {
                        Expression argExpr = args[i].Expression;
                        argExpr = Expression.Convert(argExpr, parms[i-2].ParameterType);
                        callArgs[i-2] = argExpr;
                    }
                    return new DynamicMetaObject(
                        Expression.Call(target.Expression, (MethodInfo)method, callArgs), 
                        BindingRestrictions.Empty);
                }
                // getter
                if (members.Length == 1 && members[0] is PropertyInfo && args.Length == 2) {
                    return new DynamicMetaObject(
                        Expression.Property(target.Expression, (PropertyInfo)members[0]),
                        BindingRestrictions.Empty);
                }
                // setter
                if (members.Length == 1 && members[0] is PropertyInfo && args.Length == 3) {
                    var callArg = Expression.Convert(args[0].Expression, ((PropertyInfo)members[0]).PropertyType);

                    return new DynamicMetaObject(
                        Expression.Call(target.Expression,
                            ((PropertyInfo)members[0]).GetSetMethod(),
                            new Expression[] { callArg }),
                        BindingRestrictions.Empty);
                }
            }

            throw new Exception("Binding failed");
        }
    }
}
