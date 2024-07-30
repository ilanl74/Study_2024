using Leet;

namespace xunitLeet;

public class JumpGameTest
{
    [Theory]
    [InlineData(new int[] { 2, 3, 1, 1, 4 }, true)]
    [InlineData(new int[] { 3, 2, 1, 0, 4 }, false)]
    [InlineData(new int[] { 2, 0 }, true)]
    public static void TestCanJump
    (
        int[] input,
        bool expected
    )
    {
        JumpGame game = new();
        Assert.Equal(expected, game.CanJump(input));
    }

    [Theory]
    [InlineData(new int[] { 2, 3, 1, 1, 4 }, 2)]
    [InlineData(new int[] { 2, 3, 0, 1, 4 }, 2)]
    [InlineData(new int[] { }, 0)]
    [InlineData(new int[] { 9 }, 0)]
    [InlineData(new int[] { 1, 2, 1, 1, 1 }, 3)]
    [InlineData(new int[] { 7, 0, 9, 6, 9, 6, 1, 7, 9, 0, 1, 2, 9, 0, 3 }, 2)]
    public static void TestNumOfJumps
    (
        int[] input,
        int expectedMin
    )
    {
        JumpGame game = new();
        var actual = game.Jump2(input);
        Assert.Equal(actual, expectedMin);
    }

    //https://leetcode.com/problems/jump-game-iii/description/
    [Theory]
    [InlineData(new int[] { 4, 2, 3, 0, 3, 1, 2 }, 5, true)]
    [InlineData(new int[] { 4, 2, 3, 0, 3, 1, 2 }, 0, true)]
    public static void TestJump3
    (
        int[] nums,
        int start,
        bool expected
    )
    {
        JumpGame game = new();
        var actual = game.Jump3(nums, start);
        Assert.Equal(expected, actual);
    }

}
