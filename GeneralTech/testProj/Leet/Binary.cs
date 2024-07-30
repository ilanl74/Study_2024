
namespace Leet;

public class Binary
{
    public int SearchInsert(int[] nums, int target)
    {
        int r = nums.Length - 1;
        int l = 0;
        while (r > l)
        {
            var mid = (r + l) / 2;
            if (target > nums[mid])
                l = mid + 1;
            else if (target < nums[mid])
                r = mid - 1;
            else
                return mid;

        }
        return l + 1;
    }
}
