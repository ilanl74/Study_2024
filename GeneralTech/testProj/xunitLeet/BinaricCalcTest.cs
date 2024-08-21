using System;
using Leet;

namespace xunitLeet;

public class BinaricCalcTest
{
    [Theory]
    [InlineData(11, 3)]
    [InlineData(2147483645, 30)]
    [InlineData(128, 1)]
    public void HammingWeightTest
    (
        int num,
        int exp
    )
    {
        BinaricCalc calc = new();
        var res = calc.HammingWeight(num);
        Assert.Equal(exp, res);
    }

}
