namespace Leet;

public class ArrowShot
{
    public int FindMinArrowShots(int[][] points)
    {
        var numOfBalloon = points.Length;
        if (numOfBalloon == 0)
            return 0;
        Array.Sort(points, (e1, e2) =>
        {
            if (e1[1] == e2[1]) return 0;
            else if (e1[1] < e2[1]) return -1;
            return 1;
        });
        int arrow = 1;
        int currEnd = points[0][1];
        for (var i = 0; i < points.Length; i++)
        {
            if (currEnd < points[i][0])
            {
                arrow++;
                currEnd = points[i][1];
            }
        }
        return arrow;
        /*
        Leet 452. Minimum Number of Arrows to Burst Balloons
        sort points by x
        for each point by the order (order by start point) take end point and see what baloons end point of the tested is greated then start 
        */
    }
}
