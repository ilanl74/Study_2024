using System;
using System.Globalization;
using Leet;

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
        ArrayTricks arr = new();
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
        ArrayTricks arr = new();
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
        ArrayTricks arr = new();
        var res = arr.LengthOfLongestSubstring(input);
        Assert.Equal(exp, res);
    }

    [Theory]
    [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
    [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
    [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 6, 2)]
    [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 1, 5)]
    [InlineData(new int[] { 1, 3 }, 0, -1)]
    [InlineData(new int[] { 3, 1 }, 1, 1)]
    [InlineData(new int[] { 5, 1, 3 }, 5, 0)]
    public void RotatedSearch
    (
        int[] nums,
        int target,
        int exp
    )
    {
        ArrayTricks arr = new();
        var res = arr.RotatedSearch(nums, target);
        Assert.Equal(exp, res);
    }

}
