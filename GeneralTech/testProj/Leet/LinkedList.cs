using System;

namespace Leet;

public class LinkedList
{
    //Leet 141 linked list cycle 
    //First method is to put the nod in the dictionary<ListNode,bool> 
    // run through the linked list and if reference appear more then once it is a cycle

    //second method is to have fast and slow pointers 
    //the fast will move .Next.Next and the slow only .Next if there is a cycle they will end up poining to the same node

    //Leet 206 reverce linked list 
    /*
    the stop condition is clear to return the element that is null or the next of it equals null 
    progress is also clear 
    2 things to remember here 
    1. save the result of the recurcive result and asumming that you all the list is reversed we need to set the next 
    1.1 how to set the pointers 1->2->3 first we set 2->1 by curr.next.next = curr and then we set 1->null by curr.next =null 
    3 last we return the reversed list that we saved 
    */
    public ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;
        var p = ReverseList(head.next);
        head.next.next = head;
        head.next = null;
        return p;
    }
    //Leet 141 linked list cycle 
    //iterative solution 
    public ListNode reverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;
        while (curr != null)
        {
            ListNode nextTemp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextTemp;
        }
        return prev;
    }

    //19. Remove Nth Node From End of List
    /*
    Input: head = [1,2,3,4,5], n = 2
    Output: [1,2,3,5]
    Example 2:

    Input: head = [1], n = 1
    Output: []
    Example 3:

    Input: head = [1,2], n = 1
    Output: [1]
    */
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode counter = head;
        int count = 0;
        while (counter != null)
        {
            count++;
            counter = counter.next;
        }
        ListNode toDel = head;
        for (var i = 0; i < count - n - 1; i++)
        {
            toDel = toDel.next;
        }
        toDel.next = toDel.next.next;
        return head;
    }

    /*
    Leet 2. Add Two Numbers
    */
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        int carry = 0;
        ListNode ans = new(-1);
        var tmp = ans;
        while (l1 != null || l2 != null || carry > 0)
        {
            var l1Val = (l1 != null) ? l1.val : 0;
            var l2Val = (l2 != null) ? l2.val : 0;

            var val = l1Val + l2Val + carry;
            tmp.next = new ListNode(val % 10);
            if (val > 9)
            {
                carry = 1;
            }
            else
            {
                carry = 0;
            }
            l1 = l1?.next;
            l2 = l2?.next;
            tmp = tmp.next;
        }
        return ans.next;
    }

    //Leet 23. Merge k Sorted Lists
    /*
    You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.

    Merge all the linked-lists into one sorted linked-list and return it.

    Example 1:
    Input: lists = [[1,4,5],[1,3,4],[2,6]]
    Output: [1,1,2,3,4,4,5,6]
    Explanation: The linked-lists are:
    [
    1->4->5,
    1->3->4,
    2->6
    ]
    merging them into one sorted list:
    1->1->2->3->4->4->5->6
    
    Example 2:
    Input: lists = []
    Output: []
    
    Example 3:
    Input: lists = [[]]
    Output: []
    */
    public ListNode MergeKLists(ListNode[] lists)
    {
        int amount = lists.Length;
        int interval = 1;
        while (interval < amount)
        {
            for (int i = 0; i < amount - interval; i += interval * 2)
            {
                lists[i] = Merge2Lists(lists[i], lists[i + interval]);
            }

            interval *= 2;
        }

        return amount > 0 ? lists[0] : null;
    }

    private ListNode Merge2Lists(ListNode l1, ListNode l2)
    {
        ListNode head = new ListNode(0);
        ListNode point = head;
        while (l1 != null && l2 != null)
        {
            if (l1.val <= l2.val)
            {
                point.next = l1;
                l1 = l1.next;
            }
            else
            {
                point.next = l2;
                l2 = l1;
                l1 = point.next.next;
            }

            point = point.next;
        }

        if (l1 == null)
            point.next = l2;
        else
            point.next = l1;
        return head.next;
    }


    //Leet 25. Reverse Nodes in k-Group
    /*
    Given the head of a linked list, reverse the nodes of the list k at a time, and return the modified list.

    k is a positive integer and is less than or equal to the length of the linked list. If the number of nodes is not a multiple of k then left-out nodes, in the end, should remain as it is.

    You may not alter the values in the list's nodes, only nodes themselves may be changed.
    Input: head = [1,2,3,4,5], k = 2
    Output: [2,1,4,3,5]

    Input: head = [1,2,3,4,5], k = 3
    Output: [3,2,1,4,5]
    */
    public ListNode ReverseKGroup(ListNode head, int k)
    {

        int count = 0;
        ListNode ptr = head;
        while (count < k && ptr != null)
        {
            ptr = ptr.next;
            count++;
        }

        if (count == k)
        {
            ListNode reversedHead = ReverseKNodes(head, k);
            head.next = ReverseKGroup(ptr, k);
            return reversedHead;
        }

        return head;
    }
    private ListNode ReverseKNodes(ListNode head, int k)
    {


        var ptr = head;
        ListNode newHead = null;
        while (k > 0)
        {
            var nextNode = ptr.next;
            ptr.next = newHead;

            newHead = ptr;
            ptr = nextNode;

            k--;
        }

        return newHead;



    }
}
