using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bonsai.Runtime {
    public static class ArrayExtensions {
        public static T[] Subarray<T>(this T[] array, int startIndex, int length) {
            if (array == null)
                throw new ArgumentNullException("array");
            if (array.Length < startIndex + length)
                throw new ArgumentException(
                    "The length of the array (" + array.Length + ") is to small. "+
                    "You asked for " + length + " elements starting at " + startIndex);

            T[] dest = new T[length];
            Array.Copy(array, startIndex, dest, 0, length);
            return dest;
        } 
    }
}
