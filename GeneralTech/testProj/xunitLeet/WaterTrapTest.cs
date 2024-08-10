using Leet;

namespace xunitLeet;

public class WaterTrapTest
{
    [Theory]
    [InlineData(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
    [InlineData(new int[] { 4, 2, 0, 3, 2, 5 }, 9)]
    public static void Test
    (
        int[] input,
        int exp
    )
    {
        WaterTrap trap = new();
        var res = trap.Trap(input);
        Assert.Equal(exp, res);
    }
}
