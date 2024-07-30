public class Prefix{
    public string LongestCommonPrefix(string[] strs) {
        Array.Sort(strs);
        string ans = string.Empty;
        var len = strs.Min(s=>s.Length);
        var first = strs.First();
        var last = strs.Last();
        for (var i =0 ;i<len;i++)
        {
            if (first[i] != last[i] ){
                return ans;
            }
            ans+=first[i];
        }
        return ans;
    }
}