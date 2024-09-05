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
}
