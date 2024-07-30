using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Leet;

public class JumpGame
{
    public bool CanJump(int[] nums)
    {
        int pos = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > pos) return false;
            pos = Math.Max(pos, i + nums[i]);
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
