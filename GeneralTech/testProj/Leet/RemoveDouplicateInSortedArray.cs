using System.Reflection.Metadata.Ecma335;

namespace Leet;

public class RemoveDouplicateInSortedArray
{
    public (int, int[]) Run(int[] input)
    {
        int currIndex = -1;
        for (var i = 0; i < input.Length; i++)
        {
            if (currIndex < 0)
            {
                currIndex = i;
                continue;
            }
            else if (input[i] == input[currIndex])
            {

                continue;
            }
            else
            {
                currIndex++;
                var tmp = input[currIndex];

                input[currIndex] = input[i];
                input[i] = tmp;
            }
        }
        return (currIndex + 1, input);
    }
    /*
    Leet 26. Remove Duplicates from Sorted Array
    Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

    Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

    Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
    Return k.

    Example 1:

    Input: nums = [1,1,2]
    Output: 2, nums = [1,2,_]
    Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
    It does not matter what you leave beyond the returned k (hence they are underscores).

    Example 2:
    Input: nums = [0,0,1,1,1,2,2,3,3,4]
    Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
    Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
    It does not matter what you leave beyond the returned k (hence they are underscores).
    */
    public (int, int[]) Run2(int[] input)
    {
        if (input.Length < 2)
        {
            return (input.Length, input);
        }
        int j = 1;
        for (var i = 1; i < input.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                input[j] = input[i];
                j++;
            }

        }
        return (j, input);
    }


}
