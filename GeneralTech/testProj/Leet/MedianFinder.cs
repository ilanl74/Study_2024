using System;

namespace Leet;
//Leet 295. Find Median from Data Stream
//this was implemented with sorted list and a tweak for the equal keys
//it is probably better to solve this Leet with 2 priorityQueue High and Low and balance them in their count 
/*

The median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value, and the median is the mean of the two middle values.

For example, for arr = [2,3,4], the median is 3.
For example, for arr = [2,3], the median is (2 + 3) / 2 = 2.5.
Implement the MedianFinder class:

MedianFinder() initializes the MedianFinder object.
void addNum(int num) adds the integer num from the data stream to the data structure.
double findMedian() returns the median of all elements so far. Answers within 10-5 of the actual answer will be accepted.

Example 1:

Input
["MedianFinder", "addNum", "addNum", "findMedian", "addNum", "findMedian"]
[[], [1], [2], [], [3], []]
Output
[null, null, null, 1.5, null, 2.0]

Explanation
MedianFinder medianFinder = new MedianFinder();
medianFinder.addNum(1);    // arr = [1]
medianFinder.addNum(2);    // arr = [1, 2]
medianFinder.findMedian(); // return 1.5 (i.e., (1 + 2) / 2)
medianFinder.addNum(3);    // arr[1, 2, 3]
medianFinder.findMedian(); // return 2.0
*/
public class MedianFinder
{

    SortedList<int, int> Content;

    class DuplicateComparer : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            var diff = x.CompareTo(y);
            return (diff == 0) ? 1 : diff;

        }
    }
    public MedianFinder()
    {
        Content = new SortedList<int, int>(new DuplicateComparer());
    }

    public void AddNum(int num)
    {
        Content.Add(num, num);

    }

    public double FindMedian()
    {
        if (Content.Count == 0)
            return 0;
        if (Content.Count == 1)
            return Content.First().Value;
        if (Content.Count % 2 == 0)
        {

            var f = Content.Count / 2;
            return ((double)(Content.GetValueAtIndex(f - 1) + Content.GetValueAtIndex(f))) / 2;
        }
        else return Content.GetValueAtIndex(Content.Count / 2);
    }

}
