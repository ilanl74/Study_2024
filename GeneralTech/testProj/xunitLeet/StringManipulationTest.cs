using System;
using Leet;

namespace xunitLeet;

public class StringManipulationTest
{
    [Theory]
    [InlineData("waterbottle", "erbottlewat", true)]
    [InlineData("waterbottl", "erbottlewat", false)]
    [InlineData("waterbottle", "terbottlewa", false)]
    public void IsRotationTest
    (
        string source,
        string rotation,
        bool exp
    )
    {
        StringManipulation str = new();
        var res = str.IsRotation(source, rotation);
        Assert.Equal(res, exp);
        res = str.IsRotation(rotation, source);
        Assert.Equal(res, exp);

    }

    [Theory]
    [MemberData(nameof(GroupAnagramsData))]
    public void GroupAnagramsTest
    (
        string[] arr,
        List<List<string>> exp)
    {
        StringManipulation str = new();
        var res = str.GroupAnagrams(arr);
        Assert.Equal(exp, res);

    }

    public static IEnumerable<object[]> GroupAnagramsData()
    {
        yield return new object[] { new string[] { "eat", "tea", "tan", "ate", "nat", "bat" }, new List<List<string>>() { new List<string> { "bat" } } };
    }

    [Theory]
    [InlineData("abba", 2)]

    // [InlineData("abcabcbb", 3)]
    // [InlineData("bbbbbbbbb", 1)]
    // [InlineData("dvdf", 3)]
    // [InlineData("abcabcbbr", 3)]
    public void LengthOfLongestSubstringTest
    (
        string input,
        int exp
        )
    {
        StringManipulation man = new();
        var res = man.LengthOfLongestSubstring(input);
        Assert.Equal(exp, res);
    }

    [Theory]
    [MemberData(nameof(WordBreakTestData))]
    public void WordBreakTest
    (
        string s, IList<string> wordDict, bool exp
    )
    {
        StringManipulation man = new();
        var res = man.WordBreak(s, wordDict);
        Assert.Equal(exp, res);
    }
    public static IEnumerable<object[]> WordBreakTestData()
    {
        yield return new object[] { "leetcode", new List<string>() { "leet", "code" }, true };
        yield return new object[] { "leetcode", new List<string>() { "leet", "co", "cod", "ee" }, false };
        yield return new object[] { "cars", new List<string>() { "car", "ca", "rs" }, true };

    }
}//

//["eat","tea","tan","ate","nat","bat"],[["bat"],["nat","tan"],["ate","eat","tea"]]

