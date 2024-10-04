using System;
using System.Collections;

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

    //Leet  152. Maximum Product Subarray
    /*
    Example 1:

    Input: nums = [2,3,-2,4]
    Output: 6
    Explanation: [2,3] has the largest product 6.
    Example 2:

    Input: nums = [-2,0,-1]
    Output: 0
    Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
 
    get the maximum multiplication sub array
    */
    public int MaxProduct(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int max_so_far = nums[0];
        int min_so_far = nums[0];
        int result = max_so_far;

        for (int i = 1; i < nums.Length; i++)
        {
            int curr = nums[i];
            int oldMax = max_so_far;
            int oldMin = min_so_far;
            max_so_far = Math.Max(
                curr,
                Math.Max(oldMax * curr, oldMin * curr)
            );
            min_so_far = Math.Min(
                curr,
                Math.Min(oldMax * curr, oldMin * curr)
            );

            // Update the result with the maximum product found so far
            result = Math.Max(max_so_far, result);
        }

        return result;
    }

    /*
    Leet 215. Kth Largest Element in an Array
    Given an integer array nums and an integer k, return the kth largest element in the array.

    Note that it is the kth largest element in the sorted order, not the kth distinct element.

    Can you solve it without sorting?

    

    Example 1:

    Input: nums = [3,2,1,5,6,4], k = 2
    Output: 5
    Example 2:

    Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
    Output: 4

    the trick is finding the min max 
    then in an arry count the number of occurences 
    */
    public int FindKthLargest(int[] nums, int k)
    {
        int min = int.MaxValue;
        int max = int.MinValue;
        for (int i = 0; i < nums.Length; i++)
        {
            min = Math.Min(min, nums[i]);
            max = Math.Max(max, nums[i]);
        }
        int counterLen = max - min + 1;
        int[] counter = new int[counterLen];
        for (int i = 0; i < nums.Length; i++)
        {
            counter[nums[i] - min]++;
        }
        int pCounter = counterLen - 1;
        int reminder = k;
        while (pCounter >= 0)
        {
            reminder -= counter[pCounter];
            if (reminder <= 0)
                break;
            pCounter--;
        }
        return pCounter + min;

    }

    //Leet 5. Longest Palindromic Substring
    /*
    Given a string s, return the longest palindromic substring in s.
    Example 1:

    Input: s = "babad"
    Output: "bab"
    Explanation: "aba" is also a valid answer.
    Example 2:

    Input: s = "cbbd"
    Output: "bb"
    */

    public string LongestPalindrome(string s)
    {
        (int len, int l, int r) best = new(1, 0, 0);
        for (var i = 1; i < s.Length; i++)
        {
            var lenOdd = Expand(s, i, i);

            if (lenOdd.len == Math.Max(lenOdd.len, best.len))
                best = lenOdd;

            var lenEven = Expand(s, i - 1, i);
            if (lenEven.len == Math.Max(lenEven.len, best.len))
            {
                best = lenEven;
            }



        }
        return s.Substring(best.l, best.len);
    }
    private (int len, int l, int r) Expand(string s, int l, int r)
    {
        bool revertLastMove = false;
        while (l >= 0 && r < s.Length && s[l] == s[r])
        {
            revertLastMove = true;
            l--;
            r++;
        }
        return revertLastMove ? (r - l - 1, l + 1, r - 1) : (r - l - 1, l, r);
    }

    /*
    Leet 3. Longest Substring Without Repeating Characters
    Given a string s, find the length of the longest 
    substring
    without repeating characters.

    

    Example 1:

    Input: s = "abcabcbb"
    Output: 3
    Explanation: The answer is "abc", with the length of 3.
    Example 2:

    Input: s = "bbbbb"
    Output: 1
    Explanation: The answer is "b", with the length of 1.
    Example 3:

    Input: s = "pwwkew"
    Output: 3
    Explanation: The answer is "wke", with the length of 3.
    Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
    */
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length < 2)
            return s.Length;
        int max = 1;
        int l = 0;
        int[] chars = new int[26];
        int curr = 0;
        Array.Fill(chars, -1);
        for (var i = 0; i < s.Length; i++)
        {
            if (chars[s[i] - 'a'] >= 0)
            {

                max = Math.Max(curr, max);

                var lastSeen = chars[s[i] - 'a'];
                for (var j = l; j < lastSeen + 1; j++)
                {
                    chars[s[j] - 'a'] = -1;
                }
                l = lastSeen + 1;
                chars[s[i] - 'a'] = i;
            }
            else
            {
                chars[s[i] - 'a'] = i;
                curr++;
            }
        }
        max = Math.Max(curr, max);
        return max;
    }

    public int LengthOfLongestSubstring1(string s)
    {
        int maxLen = 0;
        Dictionary<char, int> hash = new(26);
        int l = 0;

        for (var r = 0; r < s.Length; r++)
        {
            if (hash.ContainsKey(s[r]))
            {
                l = Math.Max(l, hash[s[r]]);
            }
            maxLen = Math.Max(maxLen, r - l + 1);
            hash[s[r]] = r + 1;
        }

        return maxLen;
    }

    /*
    Leet 33. Search in Rotated Sorted Array
    Example 1:

    Input: nums = [4,5,6,7,0,1,2], target = 0
    Output: 4
    Example 2:

    Input: nums = [4,5,6,7,0,1,2], target = 3
    Output: -1
    Example 3:

    Input: nums = [1], target = 0
    Output: -1

    first I will find the rotation point 
    then I will execute binary search 
    */
    public int RotatedSearch(int[] nums, int target)
    {
        int l = 0;
        int r = nums.Length - 1;
        if (r == 0)
        {
            return nums[r] == target ? 0 : -1;
        }
        var rotation = -1;
        //find rotation point 
        while (l < r)
        {
            var mid = (l + r) / 2;
            if (nums[mid] > nums[nums.Length - 1])
            {
                l = mid + 1;
            }
            else
            {
                r = mid;
            }
        }
        rotation = Math.Max(l, 0);

        var uRotation = BinSearch(nums, rotation, nums.Length - 1, target);
        var aRotation = BinSearch(nums, 0, rotation - 1, target);
        if (uRotation == -1)
            return aRotation;
        if (aRotation == -1)
            return uRotation;
        return -1;



    }
    private int BinSearch(int[] nums, int l, int r, int target)
    {
        while (l <= r)
        {
            var mid = (l + r) / 2;

            if (nums[mid] == target)
                return mid;
            else if (nums[mid] < target)
                l = mid + 1;
            else
                r = mid - 1;

        }
        return -1;
    }
    /*

        Leet 347. Top K Frequent Elements
        Example 1:

        Input: nums = [1,1,1,2,2,3], k = 2
        Output: [1,2]
        Example 2:

        Input: nums = [1], k = 1
        Output: [1]
    */
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> map = new();
        for (var i = 0; i < nums.Length; i++)
        {
            if (map.ContainsKey(nums[i]))
            {
                map[nums[i]]++;
            }
            else
                map[nums[i]] = 1;
        }
        List<(int f, int i)> fn = new();
        foreach (var kv in map)
        {
            fn.Add((kv.Value, kv.Key));
        }
        fn.Sort((e1, e2) => e2.f - e1.f);
        int[] ans = new int[k];
        for (var i = 0; i < k; i++)
        {
            ans[i] = fn[i].i;
        }
        return ans;
    }




    //Leet 300. Longest Increasing Subsequence
    /*
    Given an integer array nums, return the length of the longest strictly increasing subsequence
    
    Example 1:
    Input: nums = [10,9,2,5,3,7,101,18]
    Output: 4
    Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.
    Example 2:

    Input: nums = [0,1,0,3,2,3]
    Output: 4
    Example 3:

    Input: nums = [7,7,7,7,7,7,7]
    Output: 1
    */
    //dp approach n^2
    public int DPLengthOfLIS(int[] nums)
    {
        int[] ans = new int[nums.Length];
        Array.Fill(ans, 1);
        for (var i = 1; i < ans.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    ans[i] = Math.Max(ans[i], ans[j] + 1);
                }
            }

        }
        return ans.Max();
    }
    // binary 
    public int LengthOfLIS(int[] nums)
    {
        List<int> ans = new(nums.Length)
        {
            nums[0]
        };
        for (var i = 1; i < nums.Length; i++)
        {
            if (ans[ans.Count - 1] < nums[i])
            {
                ans.Add(nums[i]);
            }
            else
            {
                var pos = BSearch(ans, nums[i]);
                ans[pos] = nums[i];
            }
        }
        return ans.Count;
    }
    private int BSearch(List<int> list, int target)
    {
        int l = 0;
        int r = list.Count - 1;

        while (l < r)
        {
            var m = (l + r) / 2;
            if (list[m] == target)
                return m;
            if (list[m] < target)
                l = m + 1;
            else
                r = m;
        }
        return l;
    }

    //Leet 128. Longest Consecutive Sequence
    /*
    Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
    You must write an algorithm that runs in O(n) time.

    Example 1:
    Input: nums = [100,4,200,1,3,2]
    Output: 4
    Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.

    Example 2:
    Input: nums = [0,3,7,2,5,8,4,6,0,1]
    Output: 9
    */
    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 1)
            return 1;
        HashSet<int> map = new(nums);
        int ans = 0;
        foreach (var num in map)
        {
            if (!map.Contains(num - 1))
            {
                var currCounter = 1;
                var tmp = num + 1;
                while (map.Contains(tmp))
                {
                    currCounter++;
                    tmp++;
                }
                ans = Math.Max(ans, currCounter);
            }
        }
        return ans;
    }

    //Leet 88. Merge Sorted Array
    /*
    You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.

    Merge nums1 and nums2 into a single array sorted in non-decreasing order.

    The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.

    Example 1:
    Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
    Output: [1,2,2,3,5,6]
    Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
    The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.

    Example 2:
    Input: nums1 = [1], m = 1, nums2 = [], n = 0
    Output: [1]
    Explanation: The arrays we are merging are [1] and [].
    The result of the merge is [1].
    
    Example 3:
    Input: nums1 = [0], m = 0, nums2 = [1], n = 1
    Output: [1]
    Explanation: The arrays we are merging are [] and [1].
    The result of the merge is [1].
    Note that because m = 0, there are no elements in nums1. The 0 is only there to ensure the merge result can fit in nums1.
    
    */
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        // Set p1 and p2 to point to the end of their respective arrays.
        int p1 = m - 1;
        int p2 = n - 1;
        // And move p backward through the array, each time writing
        // the smallest value pointed at by p1 or p2.
        for (int p = m + n - 1; p >= 0; p--)
        {
            if (p2 < 0)
            {
                break;
            }

            if (p1 >= 0 && nums1[p1] > nums2[p2])
            {
                nums1[p] = nums1[p1--];
            }
            else
            {
                nums1[p] = nums2[p2--];
            }
        }
    }

    //Leet 189. Rotate Array
    /*
    Example 1:

    Input: nums = [1,2,3,4,5,6,7], k = 3
    Output: [5,6,7,1,2,3,4]
    Explanation:
    rotate 1 steps to the right: [7,1,2,3,4,5,6]
    rotate 2 steps to the right: [6,7,1,2,3,4,5]
    rotate 3 steps to the right: [5,6,7,1,2,3,4]
    Example 2:

    Input: nums = [-1,-100,3,99], k = 2
    Output: [3,99,-1,-100]
    Explanation: 
    rotate 1 steps to the right: [99,-1,-100,3]
    rotate 2 steps to the right: [3,99,-1,-100]

    Input: nums = [-1,-100,3,99], k = 10
    Output: [3,99,-1,-100]
    
    */
    public void Rotate(int[] nums, int k)
    {
        int len = nums.Length;
        int start = len - k;
        int end = len - 1;
        if (len < k)
        {
            Rotate(nums, k % len);
            return;
        }

        var prefix = nums[start..len];
        for (var i = end; i + 1 > k; i--)
        {
            nums[i] = nums[i - k];
        }
        for (var i = 0; i < prefix.Length; i++)
        {
            nums[i] = prefix[i];
        }
    }

    /*
    Leet 918. Maximum Sum Circular Subarray
    Given a circular integer array nums of length n, return the maximum possible sum of a non-empty subarray of nums.
    
    Example 1:
    Input: nums = [1,-2,3,-2]
    Output: 3
    Explanation: Subarray [3] has maximum sum 3.

    Example 2:
    Input: nums = [5,-3,5]
    Output: 10
    Explanation: Subarray [5,5] has maximum sum 5 + 5 = 10.

    Example 3:
    Input: nums = [-3,-2,-3]
    Output: -2
    Explanation: Subarray [-2] has maximum sum -2.

    the solution is based on removing the minimum sub array
    and a special case where all the nums are negative 
    */

    public int maxSubarraySumCircular(int[] nums)
    {
        int curMax = 0;
        int curMin = 0;
        int maxSum = nums[0];
        int minSum = nums[0];
        int totalSum = 0;

        foreach (int num in nums)
        {
            // Normal Kadane's
            curMax = Math.Max(curMax, 0) + num;
            maxSum = Math.Max(maxSum, curMax);

            // Kadane's but with min to find minimum subarray
            curMin = Math.Min(curMin, 0) + num;
            minSum = Math.Min(minSum, curMin);

            totalSum += num;
        }

        if (totalSum == minSum)// this is where all the nums are negative 
        {
            return maxSum;
        }

        return Math.Max(maxSum, totalSum - minSum);// this is the normal case 
    }

    /*
    Leet 162. Find Peak Element
    A peak element is an element that is strictly greater than its neighbors.
    Given a 0-indexed integer array nums, find a peak element, and return its index. If the array contains multiple peaks, return the index to any of the peaks.
    You may imagine that nums[-1] = nums[n] = -∞. In other words, an element is always considered to be strictly greater than a neighbor that is outside the array.
    You must write an algorithm that runs in O(log n) time.

    Example 1:
    Input: nums = [1,2,3,1]
    Output: 2
    Explanation: 3 is a peak element and your function should return the index number 2.

    Example 2:
    Input: nums = [1,2,1,3,5,6,4]
    Output: 5
    Explanation: Your function can return either index number 1 where the peak element is 2, or index number 5 where the peak element is 6.
    
    */
    public int FindPeakElement(int[] nums)
    {
        return Search(nums, 0, nums.Length - 1);
    }

    public int Search(int[] nums, int l, int r)
    {
        if (l == r)
            return l;
        int mid = (l + r) / 2;
        if (nums[mid] > nums[mid + 1])
            return Search(nums, l, mid);
        return Search(nums, mid + 1, r);
    }

    //Leet 153. Find Minimum in Rotated Sorted Array
    /*
    Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,2,4,5,6,7] might become:
    [4,5,6,7,0,1,2] if it was rotated 4 times.
    [0,1,2,4,5,6,7] if it was rotated 7 times.
    Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].
    Given the sorted rotated array nums of unique elements, return the minimum element of this array.
    You must write an algorithm that runs in O(log n) time.

    Example 1:
    Input: nums = [3,4,5,1,2]
    Output: 1
    Explanation: The original array was [1,2,3,4,5] rotated 3 times.

    Example 2:
    Input: nums = [4,5,6,7,0,1,2]
    Output: 0
    Explanation: The original array was [0,1,2,4,5,6,7] and it was rotated 4 times.

    Example 3:
    Input: nums = [11,13,15,17]
    Output: 11
    Explanation: The original array was [11,13,15,17] and it was rotated 4 times. 
    */
    public int FindMin(int[] nums)
    {
        int l = 0;
        int r = nums.Length - 1;

        var rotation = -1;
        //find rotation point 
        while (l < r)
        {
            var mid = (l + r) / 2;
            if (nums[mid] > nums[nums.Length - 1])
            {
                l = mid + 1;
            }
            else
            {
                r = mid;
            }
        }
        rotation = Math.Max(l, 0);

        return nums[rotation];
    }
}
