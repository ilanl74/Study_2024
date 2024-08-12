using System;

namespace Leet;

public class LinkedList
{
    //Leet 141 linked list cycle 
    //First method is to put the nod in the dictionary<ListNode,bool> 
    // run through the linked list and if reference appear more then once it is a cycle

    //second method is to have fast and slow pointers 
    //the fast will move .Next.Next and the slow only .Next if there is a cycle they will end up poining to the same node
}
