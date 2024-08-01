using System.Diagnostics;
using System.Transactions;

namespace Leet;

public class RemoveDuplicates_80
{
    public int Run(int[] nums)
    {
        int n = nums.Length;
        if (n <= 2)
        {
            return n;
        }

        int j = 2;
        for (int i = 2; i < n; i++)
        {
            if (nums[i] != nums[j - 2])
            {
                nums[j] = nums[i];
                j++;
            }
        }
        return j;
    }
}
