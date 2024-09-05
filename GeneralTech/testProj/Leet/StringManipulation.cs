using System;
using System.Data.SqlTypes;

namespace Leet;
public static class stringExt
{
    public static bool IsSubstringOf(this string str, string containing)
    {
        int match = 0;
        for (var i = 0; i < containing.Length && match < str.Length - 1; i++)
        {
            if (containing[i] != str[match++])
            {
                match = 0;
            }

        }
        return match == str.Length - 1;
    }
}
public class StringManipulation
{

    // page 48 on crack interview book
    public bool IsRotation(string source, string rotation)
    {
        if (rotation.Length != source.Length)
            return false;
        var tester = source + source;
        return rotation.IsSubstringOf(tester);
    }

    public List<List<string>> GroupAnagrams(string[] strs)
    {
        byte[] chars = new byte[26];
        Dictionary<byte[], List<string>> memo = new(strs.Length);
        foreach (var str in strs)
        {
            memo.Clear();
            for (var i = 0; i < str.Length; i++)
            {
                chars[str[i] - 'a']++;
            }
            if (memo.ContainsKey(chars))
            {
                memo[chars].Add(str);
            }
            else
            {
                memo.Add(chars, new List<string>(strs.Length)
                {
                    str
                });

            }
        }
        return memo.Select((a, b) => a.Value).ToList();
    }

    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> memo = new(s.Length);
        //bool[] memo = new bool[26];
        int r = 0;
        int l = 0;
        int ans = 0;
        while (l <= r && r < s.Length)
        {
            if (memo.ContainsKey(s[r]))
            {
                ans = Math.Max(ans, r - l);
                l = Math.Max(memo[s[r]] + 1, l);


            }
            memo[s[r]] = r;
            r++;

        }

        return Math.Max(ans, r - l);
    }
}
