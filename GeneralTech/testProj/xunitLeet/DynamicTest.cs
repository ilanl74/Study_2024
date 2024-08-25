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
}
