using System;
using System.Data.Common;
using System.Globalization;
using System.Runtime.InteropServices.Marshalling;

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

    // return true if the word can be compose out of the sub words
    public bool CanComposeWord(string[] subs, string target)
    {
        Queue<int> reachableIndexes = new(target.Length + 1);
        reachableIndexes.Enqueue(0);
        while (reachableIndexes.Any())
        {
            int i = reachableIndexes.Dequeue();
            if (i == target.Length)
                return true;
            foreach (var sub in subs)
            {
                if (i + sub.Length - 1 < target.Length && target.Substring(i, sub.Length) == sub)
                {
                    reachableIndexes.Enqueue(i + sub.Length);
                }
            }
        }

        return false;
    }

    //Leet 322. Coin Change
    /*
    You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.

    Return the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

    You may assume that you have an infinite number of each kind of coin.

    

    Example 1:

    Input: coins = [1,2,5], amount = 11
    Output: 3
    Explanation: 11 = 5 + 5 + 1
    Example 2:

    Input: coins = [2], amount = 3
    Output: -1
    Example 3:

    Input: coins = [1], amount = 0
    Output: 0
    */
    public int CoinChange(int[] coins, int amount)
    {

        var validCoins = coins.Where(c => c <= amount).Select(c => c).ToArray();
        //Array.Sort(validCoins, (c1, c2) => c2.CompareTo(c1));
        int[] can = new int[amount + 1];
        Array.Fill(can, -1);
        can[0] = 0;
        int index = 0;
        //int counter = 0;
        while (index < amount)
        {

            if (can[index] == -1)
            {
                index++;
                continue;
            }

            foreach (var coin in validCoins)
            {
                if (index + coin >= can.Length)
                    continue;
                if (can[index + coin] == -1)
                    can[index + coin] = can[index] + 1;
                else
                {
                    can[index + coin] = Math.Min(can[index + coin], can[index] + 1);
                }
            }
            index++;
        }
        return can[can.Length - 1];
    }

    //Leet 64. Minimum Path Sum
    /*
    Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.
dp
    Note: You can only move either down or right at any point in time.// I think this restriction is separating from DP to backtracking 
    
    Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
    Output: 7
    Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.
    
    Example 2:
    Input: grid = [[1,2,3],[4,5,6]]
    Output: 12
    the solution is to create a new matrix 
    start from the target (left bottom)
    and put the value of self + min(right , down) 
    then move towards the top right 
    */
    public int MinPathSum(int[][] grid)
    {
        var dp = new int[grid.Length][];

        for (var i = 0; i < dp.GetLength(0); i++)
        {
            dp[i] = new int[grid[0].Length];
            Array.Fill(dp[i], int.MaxValue);

        };
        for (var y = grid.Length - 1; y > -1; y--)
        {
            for (var x = grid[0].Length - 1; x > -1; x--)
            {
                int down = int.MaxValue;
                if (y + 1 < dp.Length)
                    down = dp[y + 1][x];
                int right = int.MaxValue;
                if (x + 1 < grid[0].Length)
                    right = dp[y][x + 1];
                if (down == int.MaxValue && right == int.MaxValue)
                    dp[y][x] = grid[y][x];
                else
                    dp[y][x] = grid[y][x] + Math.Min(down, right);
            }
        }
        return dp[0][0];
    }


}
