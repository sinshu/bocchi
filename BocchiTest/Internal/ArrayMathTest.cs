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

    private static (float[] a, float[] b) GetTestData1_Float(int length)
    {
        var random = new Random(42);
        var a = Enumerable.Range(0, length).Select(i => GetFloatValue(random)).ToArray();
        var b = Enumerable.Range(0, length).Select(i => GetFloatValue(random)).ToArray();
        return (a, b);
    }

    private static (float[] a, float b) GetTestData2_Float(int length)
    {
        var random = new Random(42);
        var a = Enumerable.Range(0, length).Select(i => GetFloatValue(random)).ToArray();
        var b = GetFloatValue(random);
        return (a, b);
    }

    private static (double[] a, double[] b) GetTestData1_Double(int length)
    {
        var random = new Random(42);
        var a = Enumerable.Range(0, length).Select(i => GetDoubleValue(random)).ToArray();
        var b = Enumerable.Range(0, length).Select(i => GetDoubleValue(random)).ToArray();
        return (a, b);
    }

    private static (double[] a, double b) GetTestData2_Double(int length)
    {
        var random = new Random(42);
        var a = Enumerable.Range(0, length).Select(i => GetDoubleValue(random)).ToArray();
        var b = GetDoubleValue(random);
        return (a, b);
    }

    private static (Complex[] a, Complex[] b) GetTestData1_Complex(int length)
    {
        var random = new Random(42);
        var a = Enumerable.Range(0, length).Select(i => GetComplexValue(random)).ToArray();
        var b = Enumerable.Range(0, length).Select(i => GetComplexValue(random)).ToArray();
        return (a, b);
    }

    private static (Complex[] a, Complex b) GetTestData2_Complex(int length)
    {
        var random = new Random(42);
        var a = Enumerable.Range(0, length).Select(i => GetComplexValue(random)).ToArray();
        var b = GetComplexValue(random);
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
    public void Add1_Float(int length)
    {
        var (a, b) = GetTestData1_Float(length);

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
    public void Add2_Float(int length)
    {
        var (a, b) = GetTestData2_Float(length);

        var expected = a.Select(x => x + b).ToArray();

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
    public void Add1_Double(int length)
    {
        var (a, b) = GetTestData1_Double(length);

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
    public void Add2_Double(int length)
    {
        var (a, b) = GetTestData2_Double(length);

        var expected = a.Select(x => x + b).ToArray();

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
    public void Add1_Complex(int length)
    {
        var (a, b) = GetTestData1_Complex(length);

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
    public void Add2_Complex(int length)
    {
        var (a, b) = GetTestData2_Complex(length);

        var expected = a.Select(x => x + b).ToArray();

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
    public void Sub1_Float(int length)
    {
        var (a, b) = GetTestData1_Float(length);

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
    public void Sub2_Float(int length)
    {
        var (a, b) = GetTestData2_Float(length);

        var expected = a.Select(x => x - b).ToArray();

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
    public void Sub1_Double(int length)
    {
        var (a, b) = GetTestData1_Double(length);

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
    public void Sub2_Double(int length)
    {
        var (a, b) = GetTestData2_Double(length);

        var expected = a.Select(x => x - b).ToArray();

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
    public void Sub1_Complex(int length)
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
    public void Sub2_Complex(int length)
    {
        var (a, b) = GetTestData2_Complex(length);

        var expected = a.Select(x => x - b).ToArray();

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
    public void Mul1_Float(int length)
    {
        var (a, b) = GetTestData1_Float(length);

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
    public void Mul2_Float(int length)
    {
        var (a, b) = GetTestData2_Float(length);

        var expected = a.Select(x => x * b).ToArray();

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
    public void Mul1_Double(int length)
    {
        var (a, b) = GetTestData1_Double(length);

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
    public void Mul2_Double(int length)
    {
        var (a, b) = GetTestData2_Double(length);

        var expected = a.Select(x => x * b).ToArray();

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
    public void Mul1_Complex(int length)
    {
        var (a, b) = GetTestData1_Complex(length);

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
    public void Mul2_Complex(int length)
    {
        var (a, b) = GetTestData2_Complex(length);

        var expected = a.Select(x => x * b).ToArray();

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
    public void Div1_Float(int length)
    {
        var (a, b) = GetTestData1_Float(length);

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
    public void Div2_Float(int length)
    {
        var (a, b) = GetTestData2_Float(length);

        var expected = a.Select(x => x / b).ToArray();

        var actual = new float[length];
        ArrayMath.Div<float>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-3F);
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
    public void Div1_Double(int length)
    {
        var (a, b) = GetTestData1_Double(length);

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
    public void Div2_Double(int length)
    {
        var (a, b) = GetTestData2_Double(length);

        var expected = a.Select(x => x / b).ToArray();

        var actual = new double[length];
        ArrayMath.Div<double>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-6);
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
    public void Div1_Complex(int length)
    {
        var (a, b) = GetTestData1_Complex(length);

        var expected = a.Zip(b, (x, y) => x / y).ToArray();

        var actual = new Complex[length];
        ArrayMath.Div<Complex>(a, b, actual);

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
    public void Div2_Complex(int length)
    {
        var (a, b) = GetTestData2_Complex(length);

        var expected = a.Select(x => x / b).ToArray();

        var actual = new Complex[length];
        ArrayMath.Div<Complex>(a, b, actual);

        var error = expected.Zip(actual, (x, y) => (x - y).Magnitude).Max();
        Assert.IsTrue(error < 1.0E-6);
    }
}
