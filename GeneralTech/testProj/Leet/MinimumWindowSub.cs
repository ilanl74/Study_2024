namespace Leet;
//Leet 76. Minimum Window Substring
public class SlidingWindow
{
    record struct StringPart(int Length, string Content);
    public string MinWindow(string s, string t)
    {
        Dictionary<char, int> keysOrg = new(t.Length);
        StringPart minimum = default;
        var windowChars = new Dictionary<char, int>(t.Length);

        for (var i = 0; i < t.Length; i++)
        {
            if (keysOrg.ContainsKey(t[i]))
            {
                keysOrg[t[i]]++;
            }
            else
            {
                keysOrg.Add(t[i], 1);
                windowChars.Add(t[i], 0);
            }
        }
        var keys = new Dictionary<char, int>(keysOrg);
        int left = 0;
        int right = 0;
        int formed = 0;
        while (right < s.Length)
        {

            if (windowChars.ContainsKey(s[right]))
            {
                windowChars[s[right]]++;
                if (windowChars[s[right]] == keys[s[right]])
                    formed++;
            }


            while (left <= right && formed == keys.Count)
            {
                var currLen = right - left + 1;
                if (minimum == default || minimum.Length > currLen)
                {
                    string res = s.Substring(left, currLen);
                    minimum = new StringPart(currLen, res);
                }
                if (windowChars.ContainsKey(s[left]))
                {
                    windowChars[s[left]]--;
                    if (windowChars[s[left]] < keys[s[left]])
                        formed--;
                }

                left++;
            }




            right++;
        }
        if (minimum != default)
            return minimum.Content;
        else return string.Empty;
    }

    public int CharacterReplacement(string s, int k)
    {
        int l = 0;
        int r = 0;
        char? r_last = null;
        int tmp = k;
        int ans = 0;
        while (r < s.Length && tmp >= 0)
        {
            if (r_last.HasValue && r_last != s[r])
                tmp--;
            if (tmp < 0)
            {
                ans = Math.Max(ans, r - l + 1);
                char? l_last = s[l];
                while (l <= r && tmp < 1)
                {
                    if (l_last.HasValue && l_last != s[l])
                        tmp++;

                    l_last = s[l];
                    l++;
                }
            }
            r_last = s[r];
            ans = Math.Max(ans, r - l + 1);
            r++;

        }
        return ans;
    }
}
