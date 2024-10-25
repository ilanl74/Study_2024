using System;

namespace Leet;

public class Anagrams
{
    // Leet 49. Group Anagrams
    /*
    Given an array of strings strs, group the anagrams together. You can return the answer in any order.
    An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

    Example 1:

    Input: strs = ["eat","tea","tan","ate","nat","bat"]
    Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
    Example 2:

    Input: strs = [""]
    Output: [[""]]
    Example 3:

    Input: strs = ["a"]
    Output: [["a"]]

    the solution is to create a key based on the number of the char appearance and use that key in a dictionary containing the list of words connected to that count 
    
    */
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, IList<string>> hash = new();
        for (var i = 0; i < strs.Length; i++)
        {
            var k = Compute(strs[i]);
            if (hash.ContainsKey(k))
            {
                hash[k].Add(strs[i]);
            }
            else
            {
                hash.Add(k, new List<string>() { strs[i] });
            }
        }
        return hash.Values.ToList();

    }
    private string Compute(string str)
    {
        char[] c = new char[26];
        for (var i = 0; i < str.Length; i++)
        {
            c[str[i] - 'a']++;
        }
        return string.Join(',', c);//makes sure that 11 a are deferent then 1 a and 1 b
    }
}
