using System;
using System.Numerics;
using NUnit.Framework;
using Bocchi.Internal;
using Bocchi.Math;

namespace BocchiTest.MathTest;

public class VecTest
{
    [Test]
    public void Add()
    {
        var a = new Vec<double>(1, 2, 3);
        var b = new Vec<double>(4, 5, 6);
        var expected = new Vec<double>(5, 7, 9);

        var actual = a + b;

        var error = expected.Data.Zip(actual.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }

    [Test]
    public void AddInplace()
    {
        var a = new Vec<double>(1, 2, 3);
        var b = new Vec<double>(4, 5, 6);
        var expected = new Vec<double>(5, 7, 9);

        a.AddInplace(b);

        var error = expected.Data.Zip(a.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }

    [Test]
    public void Sub()
    {
        var a = new Vec<double>(4, 5, 6);
        var b = new Vec<double>(3, 2, 1);
        var expected = new Vec<double>(1, 3, 5);

        var actual = a - b;

        var error = expected.Data.Zip(actual.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }

    [Test]
    public void SubInplace()
    {
        var a = new Vec<double>(4, 5, 6);
        var b = new Vec<double>(3, 2, 1);
        var expected = new Vec<double>(1, 3, 5);

        a.SubInplace(b);

        var error = expected.Data.Zip(a.Data, (x, y) => Math.Abs(x - y)).Max();
        Assert.IsTrue(error < 1.0E-12F);
    }
}
