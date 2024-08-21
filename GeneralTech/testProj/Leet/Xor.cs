using System;

namespace Leet;

public class Xor
{
    //Leet 136 single mumner 
    /*Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.

    You must implement a solution with a linear runtime complexity and use only constant extra space.



    Example 1:

    Input: nums = [2,2,1]
    Output: 1
    Example 2:

    Input: nums = [4,1,2,1,2]
    Output: 4
    Example 3:

    Input: nums = [1]
    Output: 1*/
    public int SingleNumber(int[] nums)
    {
        int a = 0;
        foreach (int i in nums)
        {
            a ^= i;  // bitwize xor is finding the odd occurances of a number 
        }

        return a;
    }

    /*
    Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.



    Example 1:

    Input: nums = [3,0,1]
    Output: 2
    Explanation: n = 3 since there are 3 numbers, so all numbers are in the range [0,3]. 2 is the missing number in the range since it does not appear in nums.
    Example 2:

    Input: nums = [0,1]
    Output: 2
    Explanation: n = 2 since there are 2 numbers, so all numbers are in the range [0,2]. 2 is the missing number in the range since it does not appear in nums.
    Example 3:

    Input: nums = [9,6,4,2,3,5,7,0,1]
    Output: 8
    Explanation: n = 9 since there are 9 numbers, so all numbers are in the range [0,9]. 8 is the missing number in the range since it does not appear in nums.
    */
    public int MissingNumber(int[] nums)
    {
        int a = 0;
        foreach (int i in nums)
        {
            a ^= i;  // bitwize xor is finding the odd occurances of a number 
        }
        for (int i = 0; i <= nums.Length; i++)
        {
            a ^= i;  // bitwize xor is finding the odd occurances of a number 
        }
        return a;
    }
}
