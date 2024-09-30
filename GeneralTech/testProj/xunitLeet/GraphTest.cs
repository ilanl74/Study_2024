using System;
using FluentAssertions;
using Leet;

namespace xunitLeet;

public class GraphTest
{
    [Theory]
    [MemberData(nameof(FindOrderTestData))]
    public void FindOrderTest
    (
        int numOfCources,
        int[][] prerequisites,
        int[] exp

    )
    {
        Graph graph = new();
        var res = graph.FindOrder(numOfCources, prerequisites);
        res.Should().ContainInOrder(exp);
    }

    public static IEnumerable<object[]> FindOrderTestData()
    {
        yield return new object[] { 2, new int[][] { [1, 0] }, new int[] { 0, 1 } };
        yield return new object[] { 4, new int[][] { [3, 1], [2, 0], [1, 0], [3, 2] }, new int[] { 0, 2, 1, 3 } };
    }
}
