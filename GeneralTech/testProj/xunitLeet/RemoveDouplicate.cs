using Leet;

namespace xunitLeet;

public class RemoveDouplicate
{
    //https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/
    // Leet 26
    [Theory]
    [InlineData(new int[] { 1, 1, 2, 3, 3 }, new int[] { 1, 2, 3 }, 3)]
    [InlineData(new int[] { }, new int[] { }, 0)]
    [InlineData(new int[] { -1, 0, 0, 5 }, new int[] { -1, 0, 5 }, 3)]
    [InlineData(new int[] { -1, 0, 0, 5, 5, 5 }, new int[] { -1, 0, 5 }, 3)]
    public static async void RemoveDouplicateFromSortedArray
    (
        int[] input,
        int[] expectedOutput,
        int len
    )
    {
        RemoveDouplicateInSortedArray remover = new();
        var (resLen, res) = remover.Run2(input);

        var ret = await Task.Run(() =>
        {
            for (var i = 0; i < resLen; i++)
            {
                if (expectedOutput[i] != res[i])
                    return false;
            }
            return true;
        });
        Assert.True(ret);
        Assert.Equal(len, resLen);
    }

    [Theory]
    [InlineData(new int[] { 1, 1, 2, 3, 3 }, new int[] { 1, 2, 3 }, 3)]
    [InlineData(new int[] { }, new int[] { }, 0)]
    [InlineData(new int[] { -1, 0, 0, 5 }, new int[] { -1, 0, 5 }, 3)]
    [InlineData(new int[] { -1, 0, 0, 5, 5, 5 }, new int[] { -1, 0, 5 }, 3)]
    public static async void RemoveDouplicateFromSortedArray2
    (
        int[] input,
        int[] expectedOutput,
        int len
    )
    {
        RemoveDouplicateInSortedArray remover = new();
        var (resLen, res) = remover.Run2(input);

        var ret = await Task.Run(() =>
        {
            for (var i = 0; i < resLen; i++)
            {
                if (expectedOutput[i] != res[i])
                    return false;
            }
            return true;
        });
        Assert.True(ret);
        Assert.Equal(len, resLen);
    }
    [Theory]
    [InlineData(new int[] { 1, 2, 3, -5, -1, 0 }, 3)]
    [InlineData(new int[] { 5, 3 }, 1)]
    [InlineData(new int[] { -1, 3, 4, -5 }, 3)]
    public static void FindPivot
    (
        int[] input,

        int pivot
    )
    {
        SearchInRotatedSortedArry_33 rotated = new();
        var res = rotated.FindPivot(input);
        Assert.Equal(pivot, res);

    }
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 5, 11, 120 }, 3, true)]
    [InlineData(new int[] { 2, 3 }, 1, false)]
    [InlineData(new int[] { -1, 3, 4, 5 }, 3, true)]
    public static void BinarySearchTest
    (
        int[] input,
        int target,
        bool exists
    )
    {
        SearchInRotatedSortedArry_33 rotated = new();
        var res = rotated.BinarySearch(input, 0, input.Length, target);
        Assert.Equal(exists, res);
    }
}
