using System;
using System.Numerics;

namespace Bocchi.Math
{
    /// <summary>
    /// Provides utility methods to handle vectors.
    /// </summary>
    public static class VecEx
    {
        public static Vec<T> ToVec<T>(this T[] data) where T : struct, INumberBase<T>
        {
            return new Vec<T>(data);
        }
    }
}
