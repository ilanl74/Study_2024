using System;

namespace Leet;
//Leet 70 
/*
You are climbing a staircase. It takes n steps to reach the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

 

Example 1:

Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps
Example 2:

Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
*/
public class ClimbS
{
    public int ClimbStairs(int n)
    {
        return DynamicClimb(n);
        // return RecClimb(n,new Dictionary<int,int>(n));
    }

    private int DynamicClimb(int n)
    {
        if (n <= 3)
            return n;
        int first = 1;
        int second = 2;

        for (var i = 3; i <= n; i++)
        {
            var third = first + second;
            first = second;
            second = third;

        }
        return second;
    }

    private int RecClimb(int n, Dictionary<int, int> memo)
    {
        if (memo.ContainsKey(n))
        {
            return memo[n];
        }
        if (n <= 2)
            return n;
        var curr = RecClimb(n - 1, memo) + RecClimb(n - 2, memo);
        if (!memo.ContainsKey(n))
        {
            memo.Add(n, curr);
        }
        return curr;

    }
}
