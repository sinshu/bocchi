using System;
using System.Numerics;
using Bocchi.Internal;

namespace Bocchi.Math;

/// <summary>
/// Represents a vector.
/// </summary>
/// <typeparam name="T">The type of the values.</typeparam>
public struct Vec<T> where T : struct, INumberBase<T>
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
    /// Constructs a vector filled with zeros.
    /// </summary>
    /// <param name="length">The length of the vector.</param>
    /// <returns>The resultant vector.</returns>
    public static Vec<T> Zeros(int length)
    {
        return new Vec<T>(new T[length]);
    }

    /// <summary>
    /// Constructs a vector filled with ones.
    /// </summary>
    /// <param name="length">The length of the vector.</param>
    /// <returns>The resultant vector.</returns>
    public static Vec<T> Ones(int length)
    {
        var data = new T[length];
        for (var i = 0; i < data.Length; i++)
        {
            data[i] = T.MultiplicativeIdentity;
        }
        return new Vec<T>(data);
    }

    /// <summary>
    /// Computes the element-wise addition.
    /// </summary>
    /// <param name="a">The augend.</param>
    /// <param name="b">The addend.</param>
    /// <returns>The resultant vector.</returns>
    public static Vec<T> operator +(Vec<T> a, Vec<T> b)
    {
        var result = new T[a.Length];
        ArrayMath.Add<T>(a.data, b.data, result);
        return result.ToVec();
    }

    /// <summary>
    /// Computes the element-wise addition.
    /// </summary>
    /// <param name="a">The augend.</param>
    /// <param name="b">The addend.</param>
    /// <returns>The resultant vector.</returns>
    public static Vec<T> operator +(Vec<T> a, T b)
    {
        var result = new T[a.Length];
        ArrayMath.Add<T>(a.data, b, result);
        return result.ToVec();
    }

    /// <summary>
    /// Computes the element-wise addition.
    /// </summary>
    /// <param name="a">The augend.</param>
    /// <param name="b">The addend.</param>
    /// <returns>The resultant vector.</returns>
    public static Vec<T> operator +(T a, Vec<T> b)
    {
        var result = new T[b.Length];
        ArrayMath.Add<T>(b.data, a, result);
        return result.ToVec();
    }

    /// <summary>
    /// Computes the element-wise addition.
    /// This vector will be replaced by the resultant vector.
    /// </summary>
    /// <param name="b">The addend.</param>
    public void AddInplace(Vec<T> b)
    {
        ArrayMath.Add<T>(data, b.data, data);
    }

    /// <summary>
    /// Computes the element-wise addition.
    /// This vector will be replaced by the resultant vector.
    /// </summary>
    /// <param name="b">The addend.</param>
    public void AddInplace(T b)
    {
        ArrayMath.Add<T>(data, b, data);
    }

    /// <summary>
    /// Computes the element-wise subtraction.
    /// </summary>
    /// <param name="a">The minuend.</param>
    /// <param name="b">The subtrahend.</param>
    /// <returns>The resultant vector.</returns>
    public static Vec<T> operator -(Vec<T> a, Vec<T> b)
    {
        var result = new T[a.Length];
        ArrayMath.Sub<T>(a.data, b.data, result);
        return result.ToVec();
    }

    /// <summary>
    /// Computes the element-wise subtraction.
    /// </summary>
    /// <param name="a">The minuend.</param>
    /// <param name="b">The subtrahend.</param>
    /// <returns>The resultant vector.</returns>
    public static Vec<T> operator -(Vec<T> a, T b)
    {
        var result = new T[a.Length];
        ArrayMath.Sub<T>(a.data, b, result);
        return result.ToVec();
    }

    /// <summary>
    /// Computes the element-wise subtraction.
    /// </summary>
    /// <param name="a">The minuend.</param>
    /// <param name="b">The subtrahend.</param>
    /// <returns>The resultant vector.</returns>
    public static Vec<T> operator -(T a, Vec<T> b)
    {
        var result = new T[b.Length];
        ArrayMath.Sub<T>(b.data, a, result);
        return result.ToVec();
    }

    /// <summary>
    /// Computes the element-wise subtraction.
    /// This vector will be replaced by the resultant vector.
    /// </summary>
    /// <param name="b">The subtrahend.</param>
    public void SubInplace(Vec<T> b)
    {
        ArrayMath.Sub<T>(data, b.data, data);
    }

    /// <summary>
    /// Computes the element-wise subtraction.
    /// This vector will be replaced by the resultant vector.
    /// </summary>
    /// <param name="b">The subtrahend.</param>
    public void SubInplace(T b)
    {
        ArrayMath.Sub<T>(data, b, data);
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
