using System;
using Leet;

namespace xunitLeet;

public class XorTest
{
    [Theory]
    [InlineData(new int[] { 1, 3, 0 }, 2)]
    [InlineData(new int[] { 1, 0 }, 2)]
    [InlineData(new int[] { 1, 3, 5, 4, 6 }, 2)]
    [InlineData(new int[] { 1, 3, 5, 4, 6, 2 }, 0)]

    public void MissingNumberTest
    (
        int[] input,
        int exp
    )
    {
        Xor xor = new();
        var res = xor.MissingNumber(input);
        Assert.Equal(exp, res);
    }
}
