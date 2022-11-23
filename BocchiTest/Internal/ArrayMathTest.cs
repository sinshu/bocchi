using System;
using System.Numerics;
using NUnit.Framework;
using Bocchi.Internal;

namespace BocchiTest.InternalTest;

public class ArrayMathTest
{
    private static float GetFloatValue(Random random)
    {
        while (true)
        {
            var value = 20 * (random.NextDouble() - 0.5);

            if (Math.Abs(value) >= 1.0E-3)
            {
                return (float)value;
            }
        }
    }

    private static double GetDoubleValue(Random random)
    {
        while (true)
        {
            var value = 20 * (random.NextDouble() - 0.5);

            if (Math.Abs(value) >= 1.0E-3)
            {
                return value;
            }
        }
    }

    private static Complex GetComplexValue(Random random)
    {
        return new Complex(GetDoubleValue(random), GetDoubleValue(random));
    }

    private static (float[] a, float[] b) GetTestDataFloat(int length)
    {
        var random = new Random(42);
        var a = Enumerable.Range(0, length).Select(i => GetFloatValue(random)).ToArray();
        var b = Enumerable.Range(0, length).Select(i => GetFloatValue(random)).ToArray();
        return (a, b);
    }

    private static (double[] a, double[] b) GetTestDataDouble(int length)
    {
        var random = new Random(42);
        var a = Enumerable.Range(0, length).Select(i => GetDoubleValue(random)).ToArray();
        var b = Enumerable.Range(0, length).Select(i => GetDoubleValue(random)).ToArray();
        return (a, b);
    }

    private static (Complex[] a, Complex[] b) GetTestDataComplex(int length)
    {
        var random = new Random(42);
        var a = Enumerable.Range(0, length).Select(i => GetComplexValue(random)).ToArray();
        var b = Enumerable.Range(0, length).Select(i => GetComplexValue(random)).ToArray();
        return (a, b);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(33)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    public void Add_Float(int length)
    {
        var (a, b) = GetTestDataFloat(length);

        var expected = a.Zip(b, (x, y) => x + y).ToArray();

        var actual = new float[length];
        ArrayMath.Add<float>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-6F);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(33)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    public void Add_Double(int length)
    {
        var (a, b) = GetTestDataDouble(length);

        var expected = a.Zip(b, (x, y) => x + y).ToArray();

        var actual = new double[length];
        ArrayMath.Add<double>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(33)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    public void Add_Complex(int length)
    {
        var (a, b) = GetTestDataComplex(length);

        var expected = a.Zip(b, (x, y) => x + y).ToArray();

        var actual = new Complex[length];
        ArrayMath.Add<Complex>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => (x - y).Magnitude).Max();
        Assert.IsTrue(error < 1.0E-12);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(33)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    public void Sub_Float(int length)
    {
        var (a, b) = GetTestDataFloat(length);

        var expected = a.Zip(b, (x, y) => x - y).ToArray();

        var actual = new float[length];
        ArrayMath.Sub<float>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-6F);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(33)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    public void Sub_Double(int length)
    {
        var (a, b) = GetTestDataDouble(length);

        var expected = a.Zip(b, (x, y) => x - y).ToArray();

        var actual = new double[length];
        ArrayMath.Sub<double>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(33)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    public void Sub_Complex(int length)
    {
        var random = new Random(42);
        var a = Enumerable.Range(0, length).Select(i => new Complex(random.NextDouble(), random.NextDouble())).ToArray();
        var b = Enumerable.Range(0, length).Select(i => new Complex(random.NextDouble(), random.NextDouble())).ToArray();

        var expected = a.Zip(b, (x, y) => x - y).ToArray();

        var actual = new Complex[length];
        ArrayMath.Sub<Complex>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => (x - y).Magnitude).Max();
        Assert.IsTrue(error < 1.0E-12);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(33)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    public void Mul_Float(int length)
    {
        var (a, b) = GetTestDataFloat(length);

        var expected = a.Zip(b, (x, y) => x * y).ToArray();

        var actual = new float[length];
        ArrayMath.Mul<float>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-6F);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(33)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    public void Mul_Double(int length)
    {
        var (a, b) = GetTestDataDouble(length);

        var expected = a.Zip(b, (x, y) => x * y).ToArray();

        var actual = new double[length];
        ArrayMath.Mul<double>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(33)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    public void Mul_Complex(int length)
    {
        var (a, b) = GetTestDataComplex(length);

        var expected = a.Zip(b, (x, y) => x * y).ToArray();

        var actual = new Complex[length];
        ArrayMath.Mul<Complex>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => (x - y).Magnitude).Max();
        Assert.IsTrue(error < 1.0E-12);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(33)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    public void Div_Float(int length)
    {
        var (a, b) = GetTestDataFloat(length);

        var expected = a.Zip(b, (x, y) => x / y).ToArray();

        var actual = new float[length];
        ArrayMath.Div<float>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-6F);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(33)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    public void Div_Double(int length)
    {
        var (a, b) = GetTestDataDouble(length);

        var expected = a.Zip(b, (x, y) => x / y).ToArray();

        var actual = new double[length];
        ArrayMath.Div<double>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(33)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    public void Div_Complex(int length)
    {
        var (a, b) = GetTestDataComplex(length);

        var expected = a.Zip(b, (x, y) => x / y).ToArray();

        var actual = new Complex[length];
        ArrayMath.Div<Complex>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => (x - y).Magnitude).Max();
        Assert.IsTrue(error < 1.0E-12);
    }
}
