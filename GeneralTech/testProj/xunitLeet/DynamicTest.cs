using System;
using Leet;

namespace xunitLeet;

public class DynamicTest
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 1 }, 4)]
    [InlineData(new int[] { 1, 2, 3, 10 }, 12)]
    [InlineData(new int[] { 2, 7, 9, 3, 1 }, 12)]
    public void RobTest
    (
        int[] input,
        int exp

    )
    {
        Dynamic d = new();
        var res = d.Rob(input);
        Assert.Equal(exp, res);
    }
}
