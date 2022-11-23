using System;
using System.Numerics;
using Bocchi.Internal;

namespace Bocchi.Math;

/// <summary>
/// Represents a vector.
/// </summary>
/// <typeparam name="T">The type of the values.</typeparam>
public struct Vec<T>
    where T : struct, IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IMultiplyOperators<T, T, T>, IDivisionOperators<T, T, T>
{
    private readonly T[] data;

    /// <summary>
    /// Constructs a vector from the given array.
    /// </summary>
    /// <param name="data">The array to be converted to a vector.</param>
    public Vec(params T[] data)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        this.data = data;
    }

    /// <summary>
    /// Computes the element-wise addition of the vectors.
    /// </summary>
    /// <param name="a">The vector a.</param>
    /// <param name="b">The vector b.</param>
    /// <returns>The resultant vector.</returns>
    public static Vec<T> operator +(Vec<T> a, Vec<T> b)
    {
        var result = new T[a.Length];
        ArrayMath.Add<T>(a.data, b.data, result);
        return result.ToVec();
    }

    /// <summary>
    /// Computes the element-wise addition of the vectors.
    /// The first vector will be replaced by the resultant vector.
    /// </summary>
    /// <param name="x"></param>
    public void AddInplace(Vec<T> x)
    {
        ArrayMath.Add<T>(data, x.data, data);
    }

    /// <summary>
    /// Computes the element-wise subtraction of the vectors.
    /// </summary>
    /// <param name="a">The vector a.</param>
    /// <param name="b">The vector b.</param>
    /// <returns>The resultant vector.</returns>
    public static Vec<T> operator -(Vec<T> a, Vec<T> b)
    {
        var result = new T[a.Length];
        ArrayMath.Sub<T>(a.data, b.data, result);
        return result.ToVec();
    }

    /// <summary>
    /// Computes the element-wise subtraction of the vectors.
    /// The first vector will be replaced by the resultant vector.
    /// </summary>
    /// <param name="x"></param>
    public void SubInplace(Vec<T> x)
    {
        ArrayMath.Sub<T>(data, x.data, data);
    }

    /// <summary>
    /// Gets the length of the vector.
    /// </summary>
    public int Length => data.Length;

    /// <summary>
    /// Gets the original array.
    /// </summary>
    public T[] Data => data;
}
