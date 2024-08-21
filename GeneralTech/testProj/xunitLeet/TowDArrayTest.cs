using System;
using Leet;

namespace xunitLeet;

public class TowDArrayTest
{
    [Theory]
    [MemberData(nameof(MergeData))]
    public void MergeTest
    (
        int[][] input,
        int[][] exp
    )
    {
        TowDimantionArray d = new();
        var res = d.Merge(input);
        Assert.Equal(exp, res);
    }

    public static IEnumerable<object[]> MergeData()
    {
        yield return new object[] { new int[][] { [1, 3], [2, 6], [8, 10], [15, 18] }, new int[][] { [1, 6], [8, 10], [15, 18] } };
    }
}
