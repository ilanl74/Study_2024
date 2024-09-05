
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



}

