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

    //[InlineData(new int[] { 2, -5, -2, -4, 3 }, 24)]
    [InlineData(new int[] { 2, 3, -2, 4 }, 6)]
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

    [Theory]
    [InlineData(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
    [InlineData(new int[] { 4, 10, 4, 3, 8, 9 }, 3)]
    [InlineData(new int[] { 3, 5, 6, 2, 5, 4, 19, 5, 6, 7, 12 }, 6)]
    public void LengthOfLISTest
    (
        int[] input,
        int exp
    )
    {
        ArrayTricks arr = new();
        var res = arr.LengthOfLIS(input);
        Assert.Equal(exp, res);
    }

    [Theory]
    // [InlineData(new int[] { 100, 4, 200, 1, 3, 2 }, 4)]
    //    [InlineData(new int[] { 0 }, 1)]
    [InlineData(new int[] { -1, 1, 0 }, 3)]
    public void LongestConsecutiveTest
    (
        int[] input,
        int exp

    )
    {
        ArrayTricks arr = new();
        var res = arr.LongestConsecutive(input);
        Assert.Equal(exp, res);
    }
}
