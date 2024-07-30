namespace Leet;

public class FirstOccurrence
{
    public int StrStr(string haystack, string needle)
    {
        int k = 0;

        for (var i = 0; i < haystack.Length; i++)
        {
            if (haystack[i] == needle[k])
            {
                k++;
            }
            else if (k != 0)
            {
                i = i - k;
                k = 0;
            }
            if (k == needle.Length)
                return i - k + 1;
        }
        return -1;
    }
}
