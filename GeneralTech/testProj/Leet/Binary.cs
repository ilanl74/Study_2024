
namespace Leet;

public class Binary
{
    public int SearchInsert(int[] nums, int target)
    {
        int r = nums.Length - 1;
        int l = 0;
        while (r > l)
        {
            var mid = (r + l) / 2;
            if (target > nums[mid])
                l = mid + 1;
            else if (target < nums[mid])
                r = mid - 1;
            else
                return mid;

        }
        return l + 1;
    }

    //Leet 4. Median of Two Sorted Arrays
    /*
    Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

    The overall run time complexity should be O(log (m+n)).

    

    Example 1:

    Input: nums1 = [1,3], nums2 = [2]
    Output: 2.00000
    Explanation: merged array = [1,2,3] and median is 2.
    Example 2:

    Input: nums1 = [1,2], nums2 = [3,4]
    Output: 2.50000
    Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
    
    */
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            return FindMedianSortedArrays(nums2, nums1);
        }

        int m = nums1.Length, n = nums2.Length;
        int left = 0, right = m;

        while (left <= right)
        {
            int partitionA = (left + right) / 2;
            int partitionB = (m + n + 1) / 2 - partitionA;

            int maxLeftA =
                (partitionA == 0) ? int.MinValue : nums1[partitionA - 1];
            int minRightA =
                (partitionA == m) ? int.MaxValue : nums1[partitionA];
            int maxLeftB =
                (partitionB == 0) ? int.MinValue : nums2[partitionB - 1];
            int minRightB =
                (partitionB == n) ? int.MaxValue : nums2[partitionB];

            if (maxLeftA <= minRightB && maxLeftB <= minRightA)
            {
                if ((m + n) % 2 == 0)
                {
                    return (Math.Max(maxLeftA, maxLeftB) +
                            Math.Min(minRightA, minRightB)) /
                           2.0;
                }
                else
                {
                    return Math.Max(maxLeftA, maxLeftB);
                }
            }
            else if (maxLeftA > minRightB)
            {
                right = partitionA - 1;
            }
            else
            {
                left = partitionA + 1;
            }
        }

        return 0.0;
    }

}
