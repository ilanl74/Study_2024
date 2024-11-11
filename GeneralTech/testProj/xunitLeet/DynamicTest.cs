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
        var res = d.rob2(input);//d.Rob(input);
        Assert.Equal(exp, res);
    }

    [Theory]
    [InlineData(new string[] { "bd", "a", "gt", "kk", "rt", "rty", "r" }, "akkrrtgy", false)]
    [InlineData(new string[] { "bd", "a", "gt", "kk", "rt", "rty", "r" }, "akkrrtg", false)]
    [InlineData(new string[] { "bd", "a", "gt", "kk", "rt", "rty", "r" }, "akkrrtgtr", true)]
    [InlineData(new string[] { "bd", "a", "gt", "kk", "rt", "rty", "r", "kkrrtg" }, "akkrrtgtr", true)]
    [InlineData(new string[] { "f", "fg", "o" }, "fgo", true)]
    public void CanComposeWordTest
    (
        string[] input,
        string target,
        bool exp
    )
    {
        Dynamic d = new();
        var res = d.CanComposeWord(input, target);
        Assert.Equal(exp, res);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 5 }, 11, 3)]
    [InlineData(new int[] { 2 }, 3, -1)]
    [InlineData(new int[] { 1 }, 0, 0)]
    [InlineData(new int[] { 186, 419, 83, 408 }, 6249, 20)]
    public void CoinChangeTest(int[] coins, int amount, int exp)
    {
        Dynamic d = new();
        var res = d.CoinChange(coins, amount);
        Assert.Equal(exp, res);
    }

    [Theory]
    [MemberData(nameof(MinPathSumTestData))]
    public void MinPathSumTest
    (
        int[][] matrix,
        int exp
    )
    {
        Dynamic d = new();
        var res = d.MinPathSum(matrix);
        Assert.Equal(exp, res);
    }

    public static IEnumerable<object[]> MinPathSumTestData()
    {
        yield return new object[] { new int[2][] { [1, 2, 3], [4, 5, 6] }, 12 };
    }
}
