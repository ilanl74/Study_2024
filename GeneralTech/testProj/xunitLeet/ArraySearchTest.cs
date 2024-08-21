using System;
using System.Globalization;

namespace xunitLeet;

public class ArraySearchTest
{
    [Theory]
    [InlineData(new int[] { 3, 2, 1, 5, 6, 4 }, 2, 5)]
    [InlineData(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 4)]
    public void KthLargestTest
    (
        int[] input,
        int location,
        int exp
    )
    {
        ArraySearchTricks arr = new();
        var res = arr.FindKthLargest(input, location);
        Assert.Equal(exp, res);
    }

    [Theory]
    [InlineData("cbbd", "bb")]
    [InlineData("babad", "aba")]
    [InlineData("bb", "bb")]
    public void LongestPalindromeTest
    (
        string input,
        string exp
    )
    {
        ArraySearchTricks arr = new();
        var res = arr.LongestPalindrome(input);
        Assert.Equal(exp, res);
    }

    [Theory]
    //[InlineData("abcabcbb", 3)]
    [InlineData("pwwkew", 4)]
    public void LengthOfLongestSubstring
    (
        string input,
        int exp
    )
    {
        ArraySearchTricks arr = new();
        var res = arr.LengthOfLongestSubstring(input);
        Assert.Equal(exp, res);
    }


}
