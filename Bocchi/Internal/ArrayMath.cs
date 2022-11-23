using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Bocchi.Internal;

/// <summary>
/// Provides common mathematical functions for numerical arrays.
/// </summary>
public static class ArrayMath
{
    /// <summary>
    /// Computes the element-wise addition.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="a">The augend.</param>
    /// <param name="b">The addend.</param>
    /// <param name="result">The result of the addition.</param>
    public static void Add<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> result)
        where T : struct, IAdditionOperators<T, T, T>
    {
        ThrowIfLengthsAreNotSame(a, b, result);

        var count = 0;

        if (Vector<T>.IsSupported)
        {
            var va = MemoryMarshal.Cast<T, Vector<T>>(a);
            var vb = MemoryMarshal.Cast<T, Vector<T>>(b);
            var vr = MemoryMarshal.Cast<T, Vector<T>>(result);

            for (var i = 0; i < vr.Length; i++)
            {
                vr[i] = va[i] + vb[i];
                count += Vector<T>.Count;
            }
        }

        for (var i = count; i < result.Length; i++)
        {
            result[i] = a[i] + b[i];
        }
    }

    /// <summary>
    /// Computes the element-wise addition.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="a">The augend.</param>
    /// <param name="b">The addend.</param>
    /// <param name="result">The result of the addition.</param>
    public static void Add<T>(ReadOnlySpan<T> a, T b, Span<T> result)
        where T : struct, IAdditionOperators<T, T, T>
    {
        ThrowIfLengthsAreNotSame(a, result);

        var count = 0;

        if (Vector<T>.IsSupported)
        {
            var va = MemoryMarshal.Cast<T, Vector<T>>(a);
            var vb = new Vector<T>(b);
            var vr = MemoryMarshal.Cast<T, Vector<T>>(result);

            for (var i = 0; i < vr.Length; i++)
            {
                vr[i] = va[i] + vb;
                count += Vector<T>.Count;
            }
        }

        for (var i = count; i < result.Length; i++)
        {
            result[i] = a[i] + b;
        }
    }

    /// <summary>
    /// Computes the element-wise subtraction.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="a">The minuend.</param>
    /// <param name="b">The subtrahend.</param>
    /// <param name="result">The result of the subtraction.</param>
    public static void Sub<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> result)
        where T : struct, ISubtractionOperators<T, T, T>
    {
        ThrowIfLengthsAreNotSame(a, b, result);

        var count = 0;

        if (Vector<T>.IsSupported)
        {
            var va = MemoryMarshal.Cast<T, Vector<T>>(a);
            var vb = MemoryMarshal.Cast<T, Vector<T>>(b);
            var vr = MemoryMarshal.Cast<T, Vector<T>>(result);

            for (var i = 0; i < vr.Length; i++)
            {
                vr[i] = va[i] - vb[i];
                count += Vector<T>.Count;
            }
        }

        for (var i = count; i < result.Length; i++)
        {
            result[i] = a[i] - b[i];
        }
    }

    /// <summary>
    /// Computes the element-wise subtraction.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="a">The minuend.</param>
    /// <param name="b">The subtrahend.</param>
    /// <param name="result">The result of the subtraction.</param>
    public static void Sub<T>(ReadOnlySpan<T> a, T b, Span<T> result)
        where T : struct, ISubtractionOperators<T, T, T>
    {
        ThrowIfLengthsAreNotSame(a, result);

        var count = 0;

        if (Vector<T>.IsSupported)
        {
            var va = MemoryMarshal.Cast<T, Vector<T>>(a);
            var vb = new Vector<T>(b);
            var vr = MemoryMarshal.Cast<T, Vector<T>>(result);

            for (var i = 0; i < vr.Length; i++)
            {
                vr[i] = va[i] - vb;
                count += Vector<T>.Count;
            }
        }

        for (var i = count; i < result.Length; i++)
        {
            result[i] = a[i] - b;
        }
    }

    /// <summary>
    /// Computes the element-wise multiplication.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="a">The multiplicand.</param>
    /// <param name="b">The multiplier.</param>
    /// <param name="result">The result of the multiplication.</param>
    public static void Mul<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> result)
        where T : struct, IMultiplyOperators<T, T, T>
    {
        ThrowIfLengthsAreNotSame(a, b, result);

        var count = 0;

        if (Vector<T>.IsSupported)
        {
            var va = MemoryMarshal.Cast<T, Vector<T>>(a);
            var vb = MemoryMarshal.Cast<T, Vector<T>>(b);
            var vr = MemoryMarshal.Cast<T, Vector<T>>(result);

            for (var i = 0; i < vr.Length; i++)
            {
                vr[i] = va[i] * vb[i];
                count += Vector<T>.Count;
            }
        }

        for (var i = count; i < result.Length; i++)
        {
            result[i] = a[i] * b[i];
        }
    }

    /// <summary>
    /// Computes the element-wise multiplication.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="a">The multiplicand.</param>
    /// <param name="b">The multiplier.</param>
    /// <param name="result">The result of the multiplication.</param>
    public static void Mul<T>(ReadOnlySpan<T> a, T b, Span<T> result)
        where T : struct, IMultiplyOperators<T, T, T>
    {
        ThrowIfLengthsAreNotSame(a, result);

        var count = 0;

        if (Vector<T>.IsSupported)
        {
            var va = MemoryMarshal.Cast<T, Vector<T>>(a);
            var vr = MemoryMarshal.Cast<T, Vector<T>>(result);

            for (var i = 0; i < vr.Length; i++)
            {
                vr[i] = va[i] * b;
                count += Vector<T>.Count;
            }
        }

        for (var i = count; i < result.Length; i++)
        {
            result[i] = a[i] * b;
        }
    }

    /// <summary>
    /// Computes the element-wise division.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="a">The dividend.</param>
    /// <param name="b">The divisor.</param>
    /// <param name="result">The result of the division.</param>
    public static void Div<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> result)
        where T : struct, IDivisionOperators<T, T, T>
    {
        ThrowIfLengthsAreNotSame(a, b, result);

        var count = 0;

        if (Vector<T>.IsSupported)
        {
            var va = MemoryMarshal.Cast<T, Vector<T>>(a);
            var vb = MemoryMarshal.Cast<T, Vector<T>>(b);
            var vr = MemoryMarshal.Cast<T, Vector<T>>(result);

            for (var i = 0; i < vr.Length; i++)
            {
                vr[i] = va[i] / vb[i];
                count += Vector<T>.Count;
            }
        }

        for (var i = count; i < result.Length; i++)
        {
            result[i] = a[i] / b[i];
        }
    }

    /// <summary>
    /// Computes the element-wise division.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="a">The dividend.</param>
    /// <param name="b">The divisor.</param>
    /// <param name="result">The result of the division.</param>
    public static void Div<T>(ReadOnlySpan<T> a, T b, Span<T> result)
        where T : struct, IMultiplyOperators<T, T, T>, IDivisionOperators<T, T, T>, IMultiplicativeIdentity<T, T>
    {
        ThrowIfLengthsAreNotSame(a, result);

        var ib = T.MultiplicativeIdentity / b;

        var count = 0;

        if (Vector<T>.IsSupported)
        {
            var va = MemoryMarshal.Cast<T, Vector<T>>(a);
            var vr = MemoryMarshal.Cast<T, Vector<T>>(result);

            for (var i = 0; i < vr.Length; i++)
            {
                vr[i] = va[i] * ib;
                count += Vector<T>.Count;
            }
        }

        for (var i = count; i < result.Length; i++)
        {
            result[i] = a[i] * ib;
        }
    }

    private static void ThrowIfLengthsAreNotSame<T>(ReadOnlySpan<T> s1, ReadOnlySpan<T> s2)
    {
        const string message = "All Arguments must have the same length.";

        if (s1.Length != s2.Length)
        {
            throw new ArgumentException(message);
        }
    }

    private static void ThrowIfLengthsAreNotSame<T>(ReadOnlySpan<T> s1, ReadOnlySpan<T> s2, ReadOnlySpan<T> s3)
    {
        const string message = "All Arguments must have the same length.";

        if (s1.Length != s2.Length)
        {
            throw new ArgumentException(message);
        }

        if (s1.Length != s3.Length)
        {
            throw new ArgumentException(message);
        }
    }
}
