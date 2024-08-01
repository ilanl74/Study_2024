using Leet;
using Xunit.Sdk;

namespace xunitLeet;

public class PermutationTest
{

    [Fact]
    public static void TestPassed()
    {
        int[] input = [1, 2, 3];
        IList<IList<int>> exp = GetData3();

        Permutations p = new();
        var res = p.Permute(input);
        Assert.Equal(6, res.Count());
    }

    public static IList<IList<int>> GetData3()
    {
        var exp = new List<IList<int>>
        {
            new List<int>() { 1, 2, 3 },
            new List<int>() { 1, 3, 2 },
            new List<int>() { 2, 1, 3 },
            new List<int>() { 2, 3, 1 },
            new List<int>() { 3, 1, 2 },
            new List<int>() { 3, 2, 1 }
        };
        return exp;

    }

}

