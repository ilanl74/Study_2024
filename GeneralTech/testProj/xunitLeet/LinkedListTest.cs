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

    [Theory]
    [MemberData(nameof(AddTwoNumbersTestData))]
    public void AddTwoNumbersTest
    (
        ListNode l1,
        ListNode l2,
        ListNode exp
    )
    {
        LinkedList list = new();
        var res = list.AddTwoNumbers(l1, l2);
        exp.Should().BeEquivalentTo(res);

    }
    public static IEnumerable<object[]> AddTwoNumbersTestData()
    {
        yield return new object[] {
            new ListNode()
                { val = 1, next = new()
                { val = 2, next = new()
                { val = 3, next = new()
                { val = 4, next = new()
                { val = 5 } } } } } ,

            new ListNode()
                { val = 1, next = new()
                { val = 2, next = new()
                { val = 3, next = new()
                { val = 5 } } } } ,
             new ListNode()
                { val = 2, next = new()
                { val = 4, next = new()
                { val = 6, next = new()
                { val = 9, next = new()
                { val = 5 } } } } }

                 };
        yield return new object[] {


            new ListNode()
                { val = 1, next = new()
                { val =9, next = new()
                { val = 3, next = new()
                { val = 5 } } } } ,
            new ListNode()
                { val = 8, next = new()
                { val = 2, next = new()
                { val = 3, next = new()
                { val = 4, next = new()
                { val = 5 } } } } } ,
             new ListNode()
                { val = 9, next = new()
                { val = 1, next = new()
                { val = 7, next = new()
                { val = 9, next = new()
                { val = 5 } } } } }

                 };
    }


    [Theory]
    [MemberData(nameof(ReverseKGroupTestData))]
    public void ReverseKGroupTest
    (
        ListNode head,
        int k,
ListNode exp
    )
    {
        LinkedList list = new();
        var res = list.ReverseKGroup(head, k);
        res.Should().BeEquivalentTo(exp);
    }
    public static IEnumerable<object[]> ReverseKGroupTestData()
    {
        yield return new object[]{new ListNode()
                { val = 1, next = new()
                { val =9, next = new()
                { val = 3, next = new()
                { val = 5 } } } },2,new ListNode()
                { val = 9, next = new()
                { val =1, next = new()
                { val = 5, next = new()
                { val = 3 } } } }};
    }
}
