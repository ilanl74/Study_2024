using System;
using FluentAssertions;
using Leet;

namespace xunitLeet;

public class LeetMathTest
{
    [Theory]
    // [InlineData(-3, -5, -0.00411522633744855967078189300412)]
    //[InlineData(0.00001, 2147483647, 0)]
    [InlineData(2, 20, 1048576)]
    public void MyPowTest
    (
        int x,
        int n,
        double exp
    )
    {
        LeetMath cal = new();
        var res = cal.MyPow(x, n);
        res.Should().BeApproximately(exp, 0.000000000000000000000000000001);
    }

}
