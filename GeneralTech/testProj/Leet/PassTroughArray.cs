using System;

namespace Leet;

public class PassTroughArray
{
    //Leet 242 valid anagram
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;
        Dictionary<char, int> map = new(s.Length);
        for (var i = 0; i < s.Length; i++)
        {
            if (map.ContainsKey(s[i]))
                map[s[i]]++;
            else map.Add(s[i], 1);
        }
        for (var i = 0; i < t.Length; i++)
        {
            if (!map.ContainsKey(t[i]))
                return false;
            map[t[i]]--;
            if (map[t[i]] == 0)
                map.Remove(t[i]);

        }
        return true;
    }
}
