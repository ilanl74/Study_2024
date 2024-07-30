namespace Leet;

public class SortedArrayDuplicate
{
    public int RemoveDuplicates(int[] nums)
    {
        int k = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[k])
            {
                continue;
            }
            else if (nums[k] < nums[i])
            {
                k++;
                var tmp = nums[k];
                nums[k] = nums[i];
                nums[i] = tmp;
            }
            else if (nums[k] > nums[i])
            {
                return k + 1;
            }

        }
        return k + 1;
    }
}
