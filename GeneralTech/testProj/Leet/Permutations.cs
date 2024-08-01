
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
            if (!curr.Contains(i))
            {
                curr.Add(i);
                Backtrack(nums, ans, curr);
                curr.RemoveAt(curr.Count - 1);
            }

        }
    }
}
