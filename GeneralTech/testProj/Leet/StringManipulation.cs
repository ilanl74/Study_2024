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
    /*
        Leet 139. Word Break
        Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of one or more dictionary words.

        Note that the same word in the dictionary may be reused multiple times in the segmentation.

        

        Example 1:

        Input: s = "leetcode", wordDict = ["leet","code"]
        Output: true
        Explanation: Return true because "leetcode" can be segmented as "leet code".
        Example 2:

        Input: s = "applepenapple", wordDict = ["apple","pen"]
        Output: true
        Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
        Note that you are allowed to reuse a dictionary word.
        Example 3:

        Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
        Output: false
    */
    /* recursive solution
    
    public bool WordBreak(string s, IList<string> wordDict)
    {
        return RecWordBreak(s, wordDict, 0);
    }
    public bool RecWordBreak(string s, IList<string> wordDict, int first)
    {
        if (first == s.Length)
            return true;
        var ans = false;
        for (var i = 0; i < wordDict.Count; i++)
        {
            if (s.Length >= first + wordDict[i].Length && s.Substring(first, wordDict[i].Length) == wordDict[i])
            {
                ans |= RecWordBreak(s, wordDict, first + wordDict[i].Length);

            }
        }
        return ans;
    }*/
    // DP solution is linear 
    public bool WordBreak(string s, IList<string> wordDict)
    {
        bool[] pos = new bool[s.Length + 1];
        var maxLen = wordDict.Max(w => w.Length);
        pos[0] = true;
        for (var i = 0; i < pos.Length; i++)
        {
            if (pos[i])
            {
                foreach (var word in wordDict)
                {
                    var newIndex = i + word.Length;
                    if (newIndex > pos.Length - 1)
                        continue;
                    if (!pos[newIndex] && s.Substring(i, word.Length) == word)
                    {
                        // if (newIndex == pos.Length - 1)
                        //     return true;
                        pos[newIndex] = true;
                    }
                }
            }

        }
        return pos[pos.Length - 1];
    }
}
