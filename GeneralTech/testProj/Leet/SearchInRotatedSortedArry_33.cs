namespace Leet;

public class SearchInRotatedSortedArry_33
{

    public int FindPivot(int[] nums)
    {
        var l = 0;
        var r = nums.Length - 1;
        while (l <= r)
        {
            var mid = (r + l) / 2;
            if (nums[mid] > nums[nums.Length - 1])
            {
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }
        return l;
    }

    public bool BinarySearch(int[] nums, int l, int r, int target)
    {
        while (l <= r)
        {
            var mid = (l + r) / 2;
            if (nums[mid] == target)
                return true;
            if (nums[mid] > target)
            {
                r = mid - 1;

            }
            else
            {
                l = mid + 1;
            }
        }
        return false;
    }
}
