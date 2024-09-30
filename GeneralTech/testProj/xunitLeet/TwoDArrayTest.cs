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

    [Theory]
    [MemberData(nameof(SearchMatrixTestData))]
    public void SearchMatrixTest
    (
        int[][] matrix,
        int target,
        bool exp
    )
    {
        TwoDArray arr = new();
        var res = arr.SearchMatrix(matrix, target);
        Assert.Equal(exp, res);
    }
    public static IEnumerable<object[]> SearchMatrixTestData()
    {

        yield return new object[] { new int[][] { [1] }, 3, false };
    }

    [Theory]
    [MemberData(nameof(TwoDWordSearchData))]
    public void TwoDWordSearch
    (
        char[][] matrix,
        string word,
        bool exp
    )
    {
        TwoDArray arr = new();
        var res = arr.Exist(matrix, word);
        Assert.Equal(res, exp);
    }
    public static IEnumerable<object[]> TwoDWordSearchData()
    {
        yield return new object[] { new char[][] { ['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E'] }, "ABCCED", true };
        yield return new object[] { new char[][] { ['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E'] }, "ABCB", false };
        yield return new object[] { new char[][] { ['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E'] }, "SEE", true };
    }


    [Theory]
    [MemberData(nameof(GetMinimumRangeOfAllArrayTestData))]
    public void GetMinimumRangeOfAllArrayTest
    (
        int[][] input,
        (int, int) exp
    )
    {
        TwoDArray arr = new();
        var res = arr.GetMinimumRangeOfAllArray(input);
        Assert.Equal(res, exp);
    }
    public static IEnumerable<object[]> GetMinimumRangeOfAllArrayTestData()
    {
        yield return new object[] { new int[][] { [0, 2, 3, 4, 20], [5, 6, 7], [10, 11, 12, 13, 14] }, (4, 10) };
    }
}
