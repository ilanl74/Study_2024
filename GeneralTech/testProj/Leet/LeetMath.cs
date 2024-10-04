using System;

namespace Leet;

public class LeetMath
{
    public double MyPowLogaritmic(double x, int n)
    {
        if (x * x == 1)
        {
            if (x == 1)
                return 1;
            else if (x == -1)
            {
                if (n % 2 == 0)
                    return 1;
                else return -1;
            }
        }

        if (n == 0)
            return 1;
        double ans = 1;
        if (n > 0)
        {
            while (n > 0)
            {
                ans *= x;
                n--;
            }
        }
        else
        {
            while (n < 0)
            {
                ans *= x;
                n++;
            }
            ans = 1 / ans;
        }
        return ans;

    }
    //Leet 50. Pow(x, n)
    /*
    Implement pow(x, n), which calculates x raised to the power n (i.e., xn).

    Example 1:
    Input: x = 2.00000, n = 10
    Output: 1024.00000

    Example 2:
    Input: x = 2.10000, n = 3
    Output: 9.26100
   
    Example 3:
    Input: x = 2.00000, n = -2
    Output: 0.25000
    Explanation: 2-2 = 1/22 = 1/4 = 0.25

    the solution based on recursion and memoize 
    */
    public double MyPow(double x, int n)
    {
        if (x * x == 1)
        {
            if (x == 1)
                return 1;
            else if (x == -1)
            {
                if (n % 2 == 0)
                    return 1;
                else return -1;
            }
        }

        if (n == 0)
            return 1;
        bool pPositive = (n > 0);
        n = pPositive ? n : n * (-1);
        Dictionary<int, double> memo = new(10);

        memo[0] = 1;
        memo[1] = x;
        var rec = RecMyPow(x, n, memo);
        return pPositive ? rec : 1 / rec;
    }

    private double RecMyPow(double x, int n, Dictionary<int, double> memo)
    {
        if (memo.ContainsKey(n))
        {
            return memo[n];
        }
        if (n % 2 == 0)
        {
            memo[n] = RecMyPow(x, n / 2, memo) * RecMyPow(x, n / 2, memo);
            return memo[n];
        }
        memo[n] = RecMyPow(x, n / 2, memo) * RecMyPow(x, n / 2, memo) * x;
        return memo[n];
    }
}
