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
}
