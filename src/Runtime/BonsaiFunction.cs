using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Linq.Expressions;

namespace Bonsai.Runtime {
    public abstract class BonsaiFunction : IDynamicMetaObjectProvider {
        public abstract object Call(object[] arguments);

        public virtual DynamicMetaObject GetMetaObject(Expression parameter) {
            return new MetaBonsaiFunction(parameter, this);
        }

        public class MetaBonsaiFunction : DynamicMetaObject {
            BonsaiFunction Function { get { return this.Value as BonsaiFunction; } }

            public MetaBonsaiFunction(Expression parameter, BonsaiFunction function)
                : base(parameter, BindingRestrictions.Empty, function) {
            }

            public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args) {
                return new DynamicMetaObject(
                    Expression.Call(
                        Expression.Constant(Function),
                        typeof(BonsaiFunction).GetMethod("Call"),
                        Expression.NewArrayInit(typeof(object), args.Select(a => Expression.Convert(a.Expression, typeof(object))))),
                    BindingRestrictions.GetInstanceRestriction(this.Expression, Function));
            }
        }
    }
}