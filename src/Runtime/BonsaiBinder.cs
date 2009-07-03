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
                for (int i = 0; i < args.Length; i++) {
                    Expression argExpr = args[i].Expression;
                    argExpr = Expression.Convert(argExpr, parms[i].ParameterType);
                    callArgs[i] = argExpr;
                }

                var expression = Expression.Invoke(
                    Expression.Convert(target.Expression, target.LimitType),
                    callArgs);

                return new DynamicMetaObject(
                    expression,
                    BindingRestrictions.Empty);
            }
            // "normal" objects evaluate to themselves when called with no arguments
            if(args.Length == 0)
                return target;

            // TODO: implement math
            if (value is decimal) {
            } 

            // if the second argument is a symbol, fallback to invoking a member called like that
            if (args[0].Value is SymbolId) {
                string name = ((SymbolId)args[0].Value).ToString();
                // setters end with =
                if (name.EndsWith("="))
                    name = name.Substring(0, name.Length - 1);

                var members = target.LimitType.GetMember(
                    name,
                    MemberTypes.Property | MemberTypes.Method,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);

                if (members.Length > 0 && members[0] is MethodInfo) {
                    var method = (MethodInfo)members[0];
                    var parms = method.GetParameters();
                    Expression[] callArgs = new Expression[args.Length-1];
                    for (int i = 0; i < args.Length - 1; i++) {
                        Expression argExpr = args[i+1].Expression;
                        argExpr = Expression.Convert(argExpr, parms[i].ParameterType);
                        callArgs[i] = argExpr;
                    }
                    return new DynamicMetaObject(
                        Expression.Call(target.Expression, (MethodInfo)method, callArgs), 
                        BindingRestrictions.Empty);
                }
                if (members.Length == 1 && members[0] is PropertyInfo && args.Length == 1) {
                    return new DynamicMetaObject(
                        Expression.Property(target.Expression, (PropertyInfo)members[0]),
                        BindingRestrictions.Empty);
                }
                if (members.Length == 1 && members[0] is PropertyInfo && args.Length == 2) {
                    var callArg = Expression.Convert(args[0].Expression, ((PropertyInfo)members[0]).PropertyType);

                    return new DynamicMetaObject(
                        Expression.Call(target.Expression,
                            ((PropertyInfo)members[0]).GetSetMethod(),
                            new Expression[] { callArg }),
                        BindingRestrictions.Empty);
                }
            }

            throw new InvalidOperationException();
        }
    }
}
