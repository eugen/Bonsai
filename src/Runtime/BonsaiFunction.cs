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
                var value = Function.Call(args.Select(dmo => dmo.Value).ToArray());
                return new DynamicMetaObject(Expression.Constant(value), BindingRestrictions.Empty, value);
            }
        }
    }
}