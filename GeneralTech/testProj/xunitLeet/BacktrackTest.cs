
using System.Runtime.CompilerServices;
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

}

