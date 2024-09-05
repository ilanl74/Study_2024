using System;

namespace Leet;

public class TwoDArray
{
    /*
    Leet 200. Number of Islands
    Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

    An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

    

    Example 1:

    Input: grid = [
    ["1","1","1","1","0"],
    ["1","1","0","1","0"],
    ["1","1","0","0","0"],
    ["0","0","0","0","0"]
    ]
    Output: 1
    Example 2:

    Input: grid = [
    ["1","1","0","0","0"],
    ["1","1","0","0","0"],
    ["0","0","1","0","0"],
    ["0","0","0","1","1"]
    ]
    Output: 3
    */

    public int NumIslands(char[][] grid)
    {
        int numOfIslands = 0;

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    numOfIslands++;
                    BurnIsland(grid, i, j);
                }

            }
        }
        return numOfIslands;
    }

    private void BurnIsland(char[][] grid, int i, int j)
    {
        var xLen = grid.Length;
        var yLen = grid[0].Length;
        if (i > xLen - 1 || j > yLen - 1 || i < 0 || j < 0 || grid[i][j] == '0')
            return;
        grid[i][j] = '0';
        BurnIsland(grid, i + 1, j);
        BurnIsland(grid, i, j + 1);
        BurnIsland(grid, i - 1, j);
        BurnIsland(grid, i, j - 1);


    }

    /*
   Leet 56 merge interval
   Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.



   Example 1:

   Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
   Output: [[1,6],[8,10],[15,18]]
   Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].
   Example 2:

   Input: intervals = [[1,4],[4,5]]
   Output: [[1,5]]
   Explanation: Intervals [1,4] and [4,5] are considered overlapping.
   */
    public int[][] Merge(int[][] intervals)
    {

        var ints = intervals.OrderBy(e => e[0]).ThenByDescending(e => e[1]).ToArray();

        List<int[]> res = new List<int[]>(intervals.Length);

        for (var i = 0; i < ints.Length; i++)// (ints.MoveNext())
        {
            var cStart = ints[i][0];
            var cEnd = ints[i][1];

            while (i < ints.Length - 1 && cEnd >= ints[i + 1][0])
            {
                cEnd = Math.Max(cEnd, ints[i + 1][1]);
                i++;
            }

            res.Add([cStart, cEnd]);


        }
        return res.ToArray();


    }

    /*
    Leet 48. Rotate Image
    You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
    You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.
    Example 
    Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
    Output: [[7,4,1],[8,5,2],[9,6,3]]

    example 2 
    Input: matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
    Output: [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]
    
        */
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        for (int i = 0; i < (n + 1) / 2; i++)
        {
            for (int j = 0; j < n / 2; j++)
            {
                int temp = matrix[n - 1 - j][i];
                matrix[n - 1 - j][i] = matrix[n - 1 - i][n - j - 1];
                matrix[n - 1 - i][n - j - 1] = matrix[j][n - 1 - i];
                matrix[j][n - 1 - i] = matrix[i][j];
                matrix[i][j] = temp;
            }
        }
    }
}
