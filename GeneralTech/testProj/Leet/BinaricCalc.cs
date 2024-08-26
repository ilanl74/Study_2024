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

    public static boolean isUniqueChars(String str)
    {
        int checker = 0;
        for (int i = 0; i < str.length(); ++i)
        {
            int val = str.charAt(i) - 'a';
            if ((checker & (1 << val)) > 0) return false; // we place 1 in the char location and then the & operation is 1 if it exist already 
            checker |= (1 << val);// this will flag 1 at the char location 
        }
        return true;
    }
}
