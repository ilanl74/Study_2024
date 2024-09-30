

namespace Leet;
//46. Permutations
public class Permutations
{
    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> ans = new List<IList<int>>(nums.Length);
        Backtrack(nums, ans, new List<int>(nums.Length));
        return ans;
    }

    private void Backtrack(int[] nums, IList<IList<int>> ans, List<int> curr)
    {
        if (curr.Count == nums.Length)
        {
            ans.Add(new List<int>(curr));
            return;
        }
        foreach (var i in nums)
        {
            if (!curr.Contains(i))// if we remove this if statement we will get non unique permutations with for 1,2,3 will be 27 options with 1,2,3 option at the index of 5
            {
                curr.Add(i);
                Backtrack(nums, ans, curr);
                curr.RemoveAt(curr.Count - 1);
            }

        }
    }
    //to do fix this by implementing the algo in the image //NextPermutation.jpg
    // steps are as follow 
    // 1. from right to left take the first number that is smaller then the one to his right (i)
    // 2. replace it with the first number (to his right) that is bigger then him but the the next one is smaller 
    // 3. reverse the order of the array to the left of i
    public int[] NextPermutation(int[] nums)// this solution is missing the reverse of the rest of the arr after replace single 
    {
        int? sw = default;
        int? j = default;
        for (var i = nums.Length - 1; i > 0; i--)
        {
            if (nums[i] > nums[i - 1])
            {
                sw = i - 1;
                break;
            }

        }

        if (sw.HasValue)
        {
            j = sw + 1;
            while (j < nums.Length - 1)
            {
                if (nums[j.Value] > nums[sw.Value])
                    j++;
                else
                {

                    break;
                }

            }
            j--;
            (nums[j.Value], nums[sw.Value]) = (nums[sw.Value], nums[j.Value]);
        }
        else//reverse the order of nums
        {
            var l = 0;// ;   
            var r = nums.Length - 1;
            // var mid = (l+r)/2;
            while (l <= r)
            {
                var tmpl = nums[l];
                var tmpr = nums[r];
                nums[l] = tmpr;
                nums[r] = tmpl;
                r--;
                l++;
            }
        }
        return nums;
    }
    //Leet 78. the subset - but this solution apply to permutation and combination 
    /*
    this is a more generic solution to Permutations / Combinations / Subsets
    for permutation we leave the number of element constant and the first stay 0 (order count)
    for set we need the loop over the num of elements and the first vary in a loop +1 the loop +1 will eliminate results with same element and deferent order
    for combination (order dont count and num of elements stay constant) 

    */
    public IList<IList<int>> Subsets(int[] nums)
    {
        List<IList<int>> ans = new();
        for (var i = 0; i < nums.Length + 1; ++i)
            RecSubset(nums, ans, new List<int>(), i, 0);
        return ans;
    }

    private void RecSubset(int[] nums, List<IList<int>> ans, List<int> list, int numOfElements, int first)
    {

        if (numOfElements == list.Count)
        {
            ans.Add(new List<int>(list));
        }
        for (var i = first; i < nums.Length; i++)
        //foreach (var item in nums)
        {

            if (!list.Contains(nums[i]))
            {
                list.Add(nums[i]);

                RecSubset(nums, ans, list, numOfElements, i + 1);
                list.RemoveAt(list.Count - 1);
            }
        }
    }

    //Leet 39. Combination Sum
    /*
    Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

    The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the 
    frequency
    of at least one of the chosen numbers is different.

    The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

    Example 1:
    Input: candidates = [2,3,6,7], target = 7
    Output: [[2,2,3],[7]]
    Explanation:
    2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
    7 is a candidate, and 7 = 7.
    These are the only two combinations.

    Example 2:
    Input: candidates = [2,3,5], target = 8
    Output: [[2,2,2,2],[2,3,3],[3,5]]
   
    Example 3:
    Input: candidates = [2], target = 1
    Output: []
    */
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var ans = new List<List<int>>(20);

        RecCombinationSum(candidates, target, ans, new(), 0, 0);

        return ans.Cast<IList<int>>().ToList();
    }

    private void RecCombinationSum(int[] candidate, int target, List<List<int>> ans, List<int> curr, int currSum, int first)
    {
        if (currSum == target)
        {
            ans.Add(new List<int>(curr));
            return;
        }
        if (currSum > target)
            return;
        for (int i = first; i < candidate.Length; i++)
        {
            curr.Add(candidate[i]);
            currSum += candidate[i];

            RecCombinationSum(candidate, target, ans, curr, currSum, i);//start i make sure that the list will not repeat themself 
            currSum -= candidate[i];

            curr.RemoveAt(curr.Count - 1);
        }
    }
}

