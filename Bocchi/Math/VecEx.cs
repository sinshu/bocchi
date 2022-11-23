using System;
using System.Numerics;

namespace Bocchi.Math
{
    /// <summary>
    /// Provides utility methods to handle vectors.
    /// </summary>
    public static class VecEx
    {
        public static Vec<T> ToVec<T>(this T[] data)
            where T : struct, IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IMultiplyOperators<T, T, T>, IDivisionOperators<T, T, T>
        {
            return new Vec<T>(data);
        }
    }
}
