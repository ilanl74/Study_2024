using Leet;

namespace xunitLeet;

public class SlidingWindowTest
{
    [Theory]
    [InlineData("ADOBECODEBANC", "ABC", "BANC")]
    [InlineData("a", "a", "a")]
    [InlineData("a", "aa", "")]
    public void MinWindow
    (
        string a,
        string t,
        string exp
    )
    {
        SlidingWindow win = new();
        var res = win.MinWindow(a, t);
        Assert.Equal(exp, res);
    }

    [Theory]
    [InlineData("ABAB", 2, 4)]
    [InlineData("ABBB", 1, 4)]
    [InlineData("AABABBA", 1, 4)]
    [InlineData("AAAB", 0, 3)]
    public void CharacterReplacementTest
    (
        string input,
        int numOfReplace,
        int exp
    )
    {
        SlidingWindow win = new();
        var res = win.CharacterReplacement(input, numOfReplace);
        Assert.Equal(exp, res);
    }
}
