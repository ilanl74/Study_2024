using System;
using Leet;
using FluentAssertions;

namespace xunitLeet;

public class LinkedListTest
{
    [Theory]
    [MemberData(nameof(RemoveNthFromEndTestData))]
    public void RemoveNthFromEnTest
    (
        ListNode head,
        int n,
        ListNode exp
    )
    {
        LinkedList list = new();
        var res = list.RemoveNthFromEnd(head, n);
        exp.Should().BeEquivalentTo(res);

    }
    public static IEnumerable<object[]> RemoveNthFromEndTestData()
    {
        yield return new object[] {
            new ListNode()
                { val = 1, next = new()
                { val = 2, next = new()
                { val = 3, next = new()
                { val = 4, next = new()
                { val = 5 } } } } } ,
                2,
            new ListNode()
                { val = 1, next = new()
                { val = 2, next = new()
                { val = 3, next = new()

                { val = 5 } } } }  };
    }
}
