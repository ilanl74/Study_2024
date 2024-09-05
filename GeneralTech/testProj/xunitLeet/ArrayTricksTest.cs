using System;
using Leet;

namespace xunitLeet;

public class ArrayTricksTest
{
    [Theory]
    // [InlineData(new int[] { 2, 3, -2, 4 }, 6)]
    // [InlineData(new int[] { 7, -2, -4 }, 56)]
    // [InlineData(new int[] { -3, -1, -1 }, 3)]
    // [InlineData(new int[] { -3 }, -3)]
    // [InlineData(new int[] { -3, 0, -2 }, 0)]
    // [InlineData(new int[] { 0, 2 }, 2)]

    [InlineData(new int[] { 2, -5, -2, -4, 3 }, 24)]

    public void MaxProductTest
    (
        int[] nums,
        int exp
    )
    {
        ArrayTricks arr = new();
        var res = arr.MaxProduct(nums);
        Assert.Equal(exp, res);
    }
}
