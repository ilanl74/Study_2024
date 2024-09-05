using System;
using FluentAssertions;
using Leet;

namespace xunitLeet;

public class TwoDArrayTest
{
    [Theory]
    [MemberData(nameof(NumIslandsData))]
    public void NumIslandsTest
    (
        char[][] grid,
        int exp
    )
    {
        TwoDArray tda = new();
        var res = tda.NumIslands(grid);
        Assert.Equal(exp, res);
    }
    public static IEnumerable<object[]> NumIslandsData()
    {
        // yield return new object[] { new char[][] { ['1', '1', '1', '1', '0'], ['1', '1', '0', '1', '0'], ['1', '1', '0', '0', '0'], ['0', '0', '0', '0', '0'] }, 1 };
        // yield return new object[] { new char[][] { ['1', '1', '0', '0', '0'], ['1', '1', '0', '0', '0'], ['0', '0', '1', '0', '0'], ['0', '0', '0', '1', '1'] }, 3 };
        yield return new object[] { new char[][] { ['1', '1', '1'], ['0', '1', '0'], ['1', '1', '1'] }, 1 };
    }

    [Theory]
    [MemberData(nameof(MergeData))]
    public void MergeTest
   (
       int[][] input,
       int[][] exp
   )
    {
        TwoDArray d = new();
        var res = d.Merge(input);
        Assert.Equal(exp, res);
    }

    public static IEnumerable<object[]> MergeData()
    {
        yield return new object[] { new int[][] { [1, 3], [2, 6], [8, 10], [15, 18] }, new int[][] { [1, 6], [8, 10], [15, 18] } };
    }


    [Theory]
    [MemberData(nameof(RotateTestData))]
    public void RotateTest
    (
        int[][] matrix,
        int[][] exp
    )
    {
        TwoDArray d = new();
        d.Rotate(matrix);
        matrix.Should().BeEquivalentTo(exp);

    }
    public static IEnumerable<object[]> RotateTestData()
    {
        yield return new object[] { new int[][] { [1, 2, 3], [4, 5, 6], [7, 8, 9] }, new int[][] { [7, 4, 1], [8, 5, 2], [9, 6, 3] } };
        yield return new object[] { new int[][] { [5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16] }, new int[][] { [15, 13, 2, 5], [14, 3, 4, 1], [12, 6, 8, 9], [16, 7, 10, 11] } };
    }
}
