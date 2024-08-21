using System;

namespace Leet;

public class ArrayTricks
{
    /*
    Leet 169 Majority Element 
    Given an array nums of size n, return the majority element.

    The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.


    Example 1:

    Input: nums = [3,2,3]
    Output: 3
    Example 2:

    Input: nums = [2,2,1,1,1,2,2]
    Output: 2
    */

    public int MajorityElement(int[] nums)
    {
        int count = 0;
        int? candidate = null;

        foreach (int num in nums)
        {
            if (count == 0)
            {
                candidate = num;
            }

            count += (num == candidate) ? 1 : -1;
        }

        return candidate.Value;
    }
}
