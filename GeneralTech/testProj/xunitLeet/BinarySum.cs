namespace xunitLeet;
using Leet;

public class BinarySum
{
    [Fact]
    public static void Sum_Test()
    {
        AddBinary b = new();
        var ans = b.Action("11", "1");
        Assert.Equal("100", ans);
    }
    [Theory]
    [InlineData(1, "11", "1", "100")]
    [InlineData(2, "0", "1", "1")]
    [InlineData(3, "0", "0", "0")]
    [InlineData(4, "1100", "111", "10011")]
    [InlineData(5, "11", "11", "110")]
    public static void SumB_Test
    (
        double order,
        string firstBinary,
        string secondBinary,
        string res
    )
    {
        AddBinary b = new();
        var ans = b.Action(firstBinary, secondBinary);
        Assert.Equal(res, ans);

    }
}