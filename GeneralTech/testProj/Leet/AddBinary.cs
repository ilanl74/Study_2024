using System.Text;

namespace Leet;

public class AddBinary
{
    public string Action(string a, string b)
    {
        var len = Math.Max(a.Length, b.Length);
        a = a.PadLeft(len, '0');
        b = b.PadLeft(len, '0');
        short carry = 0;

        StringBuilder ans = new(len + 1);
        for (var i = len - 1; i >= 0; i--)
        {
            var adig = (a[i] == '1') ? 1 : 0;
            var bdig = (b[i] == '1') ? 1 : 0;
            var dig = adig + bdig + carry;
            if ((dig % 2) == 1)
            {
                ans.Insert(0, '1');
            }
            else
            {
                ans.Insert(0, '0');
            }

            if (dig > 1)
            {
                carry = 1;
            }
            else carry = 0;
        }
        if (carry == 1)
            ans.Insert(0, '1');
        var res = ans.ToString().TrimStart('0');
        return string.IsNullOrEmpty(res) ? "0" : res;
    }
}
