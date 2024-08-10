namespace xunitLeet;
using Leet;
public class SpiralMatrixTest
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public void Test
    (
        int[][] input,
        IList<int> exp
    )
    {
        SpiralMetrix matrix = new();
        var res = matrix.SpiralOrder(input);
    }
    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { new int[3][] { [1, 2, 3], [4, 5, 6], [7, 8, 9] }, new List<int> { 1, 2, 3, 6, 9, 8, 7, 4, 5 } };
    }

    //https://leetcode.com/problems/spiral-matrix/description/
    // leet 54
}
