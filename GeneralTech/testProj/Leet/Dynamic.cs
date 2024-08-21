using System;

namespace Leet;

public class Dynamic
{
    /*
    Leet 198 House robber
    You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

    Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

    

    Example 1:

    Input: nums = [1,2,3,1]
    Output: 4
    Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
    Total amount you can rob = 1 + 3 = 4.
    Example 2:

    Input: nums = [2,7,9,3,1]
    Output: 12
    Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
    Total amount you can rob = 2 + 9 + 1 = 12.
    */
    //recurcive + momo
    public int Rob(int[] nums)
    {
        int[] memo = new int[nums.Length];
        Array.Fill(memo, -1);
        return RecRob(nums, 0, memo);
    }
    private int RecRob(int[] nums, int pos, int[] memo)
    {
        if (pos > nums.Length - 1)
            return 0;
        var mVal = memo[pos];
        if (mVal >= 0)
            return mVal;


        var tmp = Math.Max(RecRob(nums, pos + 2, memo) + nums[pos], RecRob(nums, pos + 1, memo));
        memo[pos] = tmp;

        return tmp;
    }

    // liniar dynamic 
    // add an array with length +1
    // at the end of it put 0 
    // and copy nums[length-1] -> memoArry[Length-1]
    // now compare the max between memo[i+1] and memo[i+2]+nums[i] and the result will be in memo[i]
    public int rob1(int[] nums)
    {
        int N = nums.Length;

        // Special handling for empty array case.
        if (N == 0)
        {
            return 0;
        }

        int[] maxRobbedAmount = new int[nums.Length + 1];

        // Base case initializations.
        maxRobbedAmount[N] = 0;
        maxRobbedAmount[N - 1] = nums[N - 1];

        // DP table calculations.
        for (int i = N - 2; i >= 0; --i)
        {
            // Same as the recursive solution.
            maxRobbedAmount[i] = Math.Max(
                maxRobbedAmount[i + 1],
                maxRobbedAmount[i + 2] + nums[i]
            );
        }

        return maxRobbedAmount[0];
    }
}
