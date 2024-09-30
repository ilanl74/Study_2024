
using System.Runtime.CompilerServices;
using FluentAssertions;
using Leet;
namespace xunitLeet;
public class BacktrackTest
{
    [Theory]
    [MemberData(nameof(GetBoards))]
    // [InlineData(new int[1,1]{{0}},false)]
    // [InlineData(new int[1,2]{{0},{1}},false)]
    // [InlineData(new int[1,2]{{1},{1}},false)]
    public void MazeRunTest
    (
        int[,] input,
        bool exp
    )
    {
        BackTrack backTrack = new();
        var res = backTrack.RunMaze(input);
        Assert.Equal(exp, res);
    }
    public static IEnumerable<object[]> GetBoards()
    {
        yield return new object[] { new int[1, 1] { { 1 } }, true };
        yield return new object[] { new int[4, 6] { { 1, 1, 0, 0, 0, 1 }, { 1, 1, 0, 1, 1, 1 }, { 1, 1, 0, 1, 0, 1 }, { 1, 1, 1, 1, 0, 1 } }, true };
        yield return new object[] { new int[2, 1] { { 1 }, { 1 } }, true };
        yield return new object[] { new int[2, 1] { { 1 }, { 0 } }, false };

    }

    [Theory]
    [MemberData(nameof(LetterCombinationsTestData))]
    public void LetterCombinationsTest
    (
        string input,
        IList<string> exp
    )
    {
        BackTrack backTrack = new();
        var res = backTrack.LetterCombinations(input);
        res.Should().BeEquivalentTo(exp);
    }

    public static IEnumerable<object[]> LetterCombinationsTestData()
    {
        yield return new object[] { "23", new List<string>() { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" } };
    }

    [Theory]
    [MemberData(nameof(GetSubsetTestData))]
    public void GetSubsetTest
    (
        int[] arr,
        List<int[]> exp
    )
    {
        BackTrack back = new();
        var res = back.GetSubset(arr);
        res.Should().BeEquivalentTo(exp);
        var T = new List<int[]>() { new int[] { }, new int[] { 1, 2 } };

    }
    public static IEnumerable<object[]> GetSubsetTestData()
    {
        yield return new object[] { new int[] { 1, 2, 3 }, new List<int[]>() { new int[] { }, new int[] { 1 }, new int[] { 2 }, new int[] { 1, 2 }, new int[] { 3 }, new int[] { 1, 3 }, new int[] { 2, 3 }, new int[] { 1, 2, 3 } } };
    }
}

