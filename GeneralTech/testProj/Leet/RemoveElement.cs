namespace Leet;

public class RemoveElementInArray
{
    public int RemoveElement(int[] nums, int val)
    {
        int k = 0;
        for (var i = 0; i < nums.Length; i++)
        {

            if (nums[i] == val)
            {
                continue;
            }
            if (k != i)
            {
                nums[k] = nums[i];
            }

            k++;
        }
        return k;
    }

}
