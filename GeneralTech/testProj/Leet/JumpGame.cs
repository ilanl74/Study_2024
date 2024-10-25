using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Leet;

public class JumpGame
{
    //https://leetcode.com/problems/jump-game/description/
    // Leet 55
    /*
    You are given an integer array nums. You start at the first index of the array, and each element in the array represents your maximum jump length at that position2
    . Your goal is to determine if you can reach the last index starting from the first index3
    . Return true if you can reach the last index, or false otherwise2
    .

    Example
    Input: [2,3,1,1,4]

    Output: true

    Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index2
    .

    Input: [3,2,1,0,4]

    Output: false

    Explanation: You will always arrive at index 3 no matter what2
    . Its maximum jump length is 0, which makes it impossible to reach the last index2
    .*/
    public bool CanJump(int[] nums)
    {
        int maxJump = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > maxJump) return false;
            maxJump = Math.Max(maxJump, i + nums[i]);
        }
        return true;
    }

    public bool CanJump1(int[] nums) //true false 
    {
        var memo = new bool[nums.Length];
        int lastTarget = memo.Length - 1;
        memo[memo.Length - 1] = true;
        for (var i = memo.Length - 2; i >= 0; i--)
        {
            memo[i] = i + nums[i] >= lastTarget;
            if (memo[i])
                lastTarget = i;
        }
        return memo[0];
    }
    public int Jump(int[] nums) // minimum jumps n^2
    {
        if (nums.Length < 2)
        {
            return 0;
        }
        int curr = nums.Length - 1;
        int currBestJump = -1;
        int jumps = 0;

        while (currBestJump != 0)
        {
            for (var i = nums.Length - 2; i >= 0; i--)
            {
                if (i + nums[i] >= curr)
                {
                    currBestJump = i;
                }
            }
            jumps++;
            curr = currBestJump;
        }


        return jumps;


    }
    //https://leetcode.com/problems/jump-game-ii/description/
    // Leet 45
    /*
    You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0]. Each element nums[i] represents the maximum length of a forward jump from index i. Your goal is to return the minimum number of jumps required to reach the last index (nums[n - 1]).

    Example
    Input: [2,3,1,1,4]

    Output: 2

    Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.

    Input: [2,3,0,1,4]

    Output: 2

    Explanation: Jump 2 steps from index 0 to 2, then 2 steps to the last index.


    */
    public int Jump2(int[] nums) // minimum jumps 
    {
        int curr = 0;
        int jumps = 0;
        int maxJump = 0;
        for (var i = 0; i < nums.Length && curr < nums.Length - 1; i++)
        {

            maxJump = Math.Max(maxJump, i + nums[i]);

            if (curr == i)
            {
                jumps++;
                curr = maxJump;
            }


        }
        return jumps;
    }

    // https://leetcode.com/problems/jump-game-iii/description/
    // Leet 1306
    /*You are given an array of non-negative integers arr and a starting index start. From each index i, you can jump to i + arr[i] or i - arr[i]. Your goal is to determine if you can reach any index with value 01
    . You must stay within the bounds of the array at all times1
    .

    Example
    Input: arr = [4,2,3,0,3,1,2], start = 5

    Output: true

    Explanation: You can reach index 3 with value 0 through the following jumps: 5 -> 4 -> 1 -> 31
    .

    Input: arr = [4,2,3,0,3,1,2], start = 0

    Output: true

    Explanation: One possible way to reach index 3 with value 0 is: 0 -> 4 -> 1 -> 31
    .

    Input: arr = [3,0,2,1,2], start = 2

    Output: false

    Explanation: There is no way to reach an index with value 01
.*/
    public bool Jump3(int[] nums, int start)
    {
        return RecJump3(nums, start, new bool?[nums.Length]);
    }

    private bool RecJump3(int[] nums, int pos, bool?[] memo) // dfs 
    {
        if (pos > nums.Length - 1 || pos < 0)
        {
            return false;
        }

        if (nums[pos] == 0)
        {
            memo[pos] = true;
        }

        if (memo[pos].HasValue)
            return memo[pos].Value;

        memo[pos] = RecJump3(nums, pos - nums[pos], memo) || RecJump3(nums, pos + nums[pos], memo);
        return memo[pos].Value;

    }
}
/*
https://leetcode.com/problems/jump-game/editorial/
*/
