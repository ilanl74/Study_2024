// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Console.WriteLine(LeetMath.GetDigit(5847,0));
// Console.WriteLine("give me a number I will tell you how much digit it have");
// var num = Console.ReadLine();
// Console.WriteLine($"num of digit {LeetMath.NumOfDigits(int.Parse(num))}");
// Console.WriteLine($"num is IsPalindrome {Palindrome.IsPalindrome(int.Parse(num))}");
// var roman = new Roman();
// Console.WriteLine("give me a roman num I shell disifer it");
// var romanStr = Console.ReadLine();
// Console.WriteLine($"in decimal this is {roman.RomanToInt( romanStr)}");
//Console.WriteLine($"longets prefix in [\"flower\",\"flow\",\"flight\"] is {new Prefix().LongestCommonPrefix(["flower","flow","flight"])}");
Console.WriteLine("Merge two sorted lists ");
Console.WriteLine();
var m = new MergeSortedList();
var sortedList = m.MergeTwoLists(new ListNode(1,new ListNode(2,new ListNode(4))),new ListNode(1,new ListNode(3,new ListNode(4))));
while(sortedList.next != null)
{
    Console.Write(sortedList.val+",");
    sortedList = sortedList.next;
}

