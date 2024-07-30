// See https://aka.ms/new-console-template for more information
using Leet;

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
// Console.WriteLine("Merge two sorted lists ");
// Console.WriteLine();
// var m = new MergeSortedList();
//var sortedList = m.MergeTwoLists(new ListNode(1,new ListNode(2,new ListNode(4))),new ListNode(1,new ListNode(3,new ListNode(4))));
// while(sortedList.next != null)
// {
//     Console.Write(sortedList.val+",");
//     sortedList = sortedList.next;
// }
//SortedArrayDuplicate duplicate = new();
// var a = duplicate.RemoveDuplicates(new int[]{1,2,3,3,4,4,5,6,7});
// var b = duplicate.RemoveDuplicates(new int[]{1,3,3,3,4,4,5,6,7});
// var c = duplicate.RemoveDuplicates(new int[]{1,1,3,3,4,4,4,6,7});
//var d = duplicate.RemoveDuplicates(new int[]{1,1,2});

//Console.WriteLine($"a={a},b={b},c={c},d={d}");

//RemoveElementInArray remove = new();
// var a = remove.RemoveElement(new int[]{3,1,2,3,3,4,4,5,2,3,6,7,3},3);
// Console.WriteLine($"a={a}");
// FirstOccurrence first = new();
// var a = first.StrStr("mississippi","pi");
// Console.WriteLine($"a={a}");

// Binary search = new();
// var a = search.SearchInsert(new int[]{1,3,5,6},7);
// Console.WriteLine($"a={a}");
// var b = search.SearchInsert(new int[]{1,3,5,6},2);
// Console.WriteLine($"b={b}");
// var c = search.SearchInsert(new int[]{1,3,5,6},5);
// Console.WriteLine($"c={c}");
// AddOne one = new();
// var res  = one.PlusOne(new int[]{8,9,9,9});
// Console.WriteLine();
// foreach(var d in res)
// {
//     Console.WriteLine($"{d},");
// }
AddBinary b = new();
var ans = b.Action("11","1");
Console.WriteLine(ans);


