using System;
using System.Numerics;
using NUnit.Framework;
using Bocchi.Internal;
using Bocchi.Math;

namespace BocchiTest.MathTest;

public class VecTest
{
    [Test]
    public void Add1()
    {
        var a = new Vec<double>(1, 2, 3);
        var b = new Vec<double>(4, 5, 6);
        var expected = new Vec<double>(5, 7, 9);

        var actual = a + b;

        var error = expected.Data.Zip(actual.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }

    [Test]
    public void Add2()
    {
        var a = new Vec<double>(1, 2, 3);
        var b = 5;
        var expected = new Vec<double>(6, 7, 8);

        var actual = a + b;

        var error = expected.Data.Zip(actual.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }

    [Test]
    public void Add3()
    {
        var a = 5;
        var b = new Vec<double>(1, 2, 3);
        var expected = new Vec<double>(6, 7, 8);

        var actual = a + b;

        var error = expected.Data.Zip(actual.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }

    [Test]
    public void AddInplace1()
    {
        var a = new Vec<double>(1, 2, 3);
        var b = new Vec<double>(4, 5, 6);
        var expected = new Vec<double>(5, 7, 9);

        a.AddInplace(b);

        var error = expected.Data.Zip(a.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }

    [Test]
    public void AddInplace2()
    {
        var a = new Vec<double>(1, 2, 3);
        var b = 5;
        var expected = new Vec<double>(6, 7, 8);

        a.AddInplace(b);

        var error = expected.Data.Zip(a.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }

    [Test]
    public void Sub1()
    {
        var a = new Vec<double>(4, 5, 6);
        var b = new Vec<double>(3, 2, 1);
        var expected = new Vec<double>(1, 3, 5);

        var actual = a - b;

        var error = expected.Data.Zip(actual.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }

    [Test]
    public void Sub2()
    {
        var a = new Vec<double>(4, 5, 6);
        var b = 3;
        var expected = new Vec<double>(1, 2, 3);

        var actual = a - b;

        var error = expected.Data.Zip(actual.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }

    [Test]
    public void Sub3()
    {
        var a = 3;
        var b = new Vec<double>(4, 5, 6);
        var expected = new Vec<double>(1, 2, 3);

        var actual = a - b;

        var error = expected.Data.Zip(actual.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }

    [Test]
    public void SubInplace1()
    {
        var a = new Vec<double>(4, 5, 6);
        var b = new Vec<double>(3, 2, 1);
        var expected = new Vec<double>(1, 3, 5);

        a.SubInplace(b);

        var error = expected.Data.Zip(a.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }

    [Test]
    public void SubInplace2()
    {
        var a = new Vec<double>(4, 5, 6);
        var b = 3;
        var expected = new Vec<double>(1, 2, 3);

        a.SubInplace(b);

        var error = expected.Data.Zip(a.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }
}
