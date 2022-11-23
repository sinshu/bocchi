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
    /// Computes the element-wise addition of the arrays.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="a">The array a.</param>
    /// <param name="b">The array b.</param>
    /// <param name="result">The result of the addition.</param>
    public static void Add<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> result) where T : struct, IAdditionOperators<T, T, T>
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
    /// Computes the element-wise subtraction of the arrays.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="a">The array a.</param>
    /// <param name="b">The array b.</param>
    /// <param name="result">The result of the subtraction.</param>
    public static void Sub<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> result) where T : struct, ISubtractionOperators<T, T, T>
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
    /// Computes the element-wise multiplication of the arrays.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="a">The array a.</param>
    /// <param name="b">The array b.</param>
    /// <param name="result">The result of the multiplication.</param>
    public static void Mul<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> result) where T : struct, IMultiplyOperators<T, T, T>
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
    /// Computes the element-wise division of the arrays.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="a">The array a.</param>
    /// <param name="b">The array b.</param>
    /// <param name="result">The result of the division.</param>
    public static void Div<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> result) where T : struct, IDivisionOperators<T, T, T>
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

    private static void ThrowIfLengthsAreNotSame<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, ReadOnlySpan<T> c)
    {
        const string message = "All Arguments must have the same length.";

        if (a.Length != b.Length)
        {
            throw new ArgumentException(message);
        }

        if (a.Length != c.Length)
        {
            throw new ArgumentException(message);
        }
    }
}
