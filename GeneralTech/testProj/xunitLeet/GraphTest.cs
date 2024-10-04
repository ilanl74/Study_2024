
using System.Text.Json;
using System.Text.Json.Nodes;
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

    [Theory]
    [MemberData(nameof(CloneGraphData))]
    public void CloneGraphTest
    (
        Graph.Node input,
        Graph.Node clone
    )
    {
        Graph graph = new();
        var res = graph.CloneGraph(input);
        Assert.Equal(JsonSerializer.Serialize(clone), JsonSerializer.Serialize(res));
    }
    public static IEnumerable<object[]> CloneGraphData()
    {
        Graph.Node node1 = new(1);
        Graph.Node node2 = new(2);
        Graph.Node node3 = new(3);
        Graph.Node node4 = new(4);
        node1.neighbors.Add(node2);
        node1.neighbors.Add(node4);
        node2.neighbors.Add(node1);
        node2.neighbors.Add(node3);
        node3.neighbors.Add(node2);
        node3.neighbors.Add(node4);
        node4.neighbors.Add(node1);
        node4.neighbors.Add(node3);


        yield return new object[] { node1, node1 };
    }
}
