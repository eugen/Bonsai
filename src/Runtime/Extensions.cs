using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting;

namespace Bonsai.Runtime {
    public static class ArrayExtensions {
        public static T[] Subarray<T>(this T[] array, int startIndex, int length = -1) {
            if (array == null)
                throw new ArgumentNullException("array");
            if (array.Length < startIndex + length)
                throw new ArgumentException(
                    "The length of the array (" + array.Length + ") is to small. "+
                    "You asked for " + length + " elements starting at " + startIndex);

            if (length == -1)
                length = array.Length - startIndex;
            T[] dest = new T[length];
            Array.Copy(array, startIndex, dest, 0, length);
            return dest;
        } 
    }

    public static class StringExtensions
    {
        public static SymbolId ToSymbol(this string self) {
            return SymbolTable.StringToId(self);
        }
    }
}

namespace System.Reflection {
    public static class TypeExtensions {
        public static IEnumerable<MethodInfo> GetMethodsWith<T>(
            this Type type, 
            Func<MethodInfo, T, bool> test = null,
            BindingFlags flags = BindingFlags.NonPublic
                               | BindingFlags.Public
                               | BindingFlags.Instance 
                               | BindingFlags.Static)
            where T : Attribute
        {
            foreach (MethodInfo mi in type.GetMethods(flags)) {
                var attributes = mi.GetCustomAttributes(typeof(T), false);
                if (attributes.Length > 0) {
                    if(test == null || test(mi, (T)attributes[0]))
                        yield return mi;
                }
            }
        }
    }
}

namespace System {
    public static class StringExtensions {
        public static SymbolId ToSymbol(this string s) {
            return SymbolTable.StringToId(s);
        }
    }
}

namespace System.Linq.Expressions
{
    public static class ExpressionExtensions
    {
        public static Expression ConvertTo<T>(this Expression exp) {
            return Expression.Convert(exp, typeof(T));
        }
    }
}

namespace System.Reflection {
    public static class ReflectionExtensions {
        public static bool IsA(this object o, Type type) {
            if(o == null)
                return false;
            var oType = o.GetType();
            return
                oType == type ||
                (oType.IsGenericType && oType.GetGenericTypeDefinition() == type);
        }
    }
}