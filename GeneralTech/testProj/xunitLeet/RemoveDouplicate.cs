using Leet;

namespace xunitLeet;

public class RemoveDouplicate
{
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
}
