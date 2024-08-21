using System;
using Leet;

namespace xunitLeet;

public class ClimbStairsTest
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(0, 0)]
    [InlineData(6, 13)]
    public void Test
    (
        int n,
        int exp
    )
    {
        ClimbS climb = new();
        var res = climb.ClimbStairs(n);
        Assert.Equal(exp, res);
    }
}
