/*
Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]
Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]
*/
//brute force 
public class TwoSum {
    public int[] BruteForceTwoSum(int[] nums, int target) {
        return RecSum(nums,target,0,1);
    }
    private int[] RecSum(int[] nums, int target,int x, int y){
        if (x == nums.Length || y == nums.Length)
            return new int[]{};
        if (nums[x]+nums[y] == target)
        {
            return new int[]{x,y};
        }

        return RecSum(nums,target,x+1,y);
        return RecSum(nums,target,x,y+1);

    }


//sorting Solution

    public int[] SortingTwoSum(int[] nums, int target) {
        var clone = new int[nums.Length];
        Array.Copy(nums,clone,nums.Length);
        Array.Sort(clone);
        var resNums = SortingRecSum(clone,target,0,clone.Length-1);
        return FindPositions(resNums,nums);
    }
    private int[] SortingRecSum(int[] nums, int target,int x, int y){
        if (x ==  y)
            return new int[]{};
        var sum = nums[x]+nums[y];
        if (sum == target)
            return new int[]{nums[x],nums[y]};
        if (sum <target)
            return RecSum(nums,target,x+1,y);
        return RecSum(nums,target,x,y-1);

    }
    private int[] FindPositions(int[] res,int[] nums){
        int? xPos = -1;
        int? yPos = -1;
        int xVal = res[0];
        int yVal= res[1];
        for(var i=0;i<nums.Length;i++)
        {
            if (nums[i]==xVal && xPos==-1)
                xPos = i;
            if (nums[i] == yVal)
                yPos = i;
        }
        if (xPos.HasValue && yPos.HasValue )
            return new int[]{xPos.Value,yPos.Value};
        return new int[]{};
    }
}
