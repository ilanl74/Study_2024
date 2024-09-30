using System;
using System.ComponentModel;

namespace Leet;

public class BinaricCalc
{
    /*
    Leet 191 number of 1 bits
    Example 1:

    Input: n = 11

    Output: 3

    Explanation:

    The input binary string 1011 has a total of three set bits.

    Example 2:

    Input: n = 128

    Output: 1

    Explanation:

    The input binary string 10000000 has a total of one set bit.
    */
    public int HammingWeight(int n)
    {
        int ones = 0;
        int d = 1;
        for (var i = 0; i < 32; i++)//there are 32 bit in int 
        {
            if ((n & d) != 0)//count only 1 s 
            {
                ones++;
            }
            d <<= 1;// move to the bit to the next digit 
        }

        return ones;
    }

    public static bool isUniqueChars(String str)
    {
        int checker = 0;
        for (int i = 0; i < str.Length; ++i)
        {
            int val = str[i] - 'a';
            if ((checker & (1 << val)) > 0) return false; // we place 1 in the char location and then the & operation is 1 if it exist already 
            checker |= (1 << val);// this will flag 1 at the char location 
        }
        return true;
    }

    //201. Bitwise AND of Numbers Range
    /*
    Given two integers left and right that represent the range [left, right], return the bitwise AND of all numbers in this range, inclusive.

    Example 1:
    Input: left = 5, right = 7
    Output: 4

    Example 2:
    Input: left = 0, right = 0
    Output: 0

    Example 3:
    Input: left = 1, right = 2147483647
    Output: 0
    */
    public int RangeBitwiseAnd(int left, int right)
    {
        while (left < right)
        {
            // turn off rightmost 1-bit
            right &= (right - 1);
        }
        return right;
    }
}
