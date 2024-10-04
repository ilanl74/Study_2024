using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

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
    /*
    Leet 74. Search a 2D Matrix
    You are given an m x n integer matrix matrix with the following two properties:

    Each row is sorted in non-decreasing order.
    The first integer of each row is greater than the last integer of the previous row.
    Given an integer target, return true if target is in matrix or false otherwise.

    You must write a solution in O(log(m * n)) time complexity.

    Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
Output: true
Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
Output: false
    */
    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix.Length == 0)
            return false;
        var y = matrix.Length;
        var x = matrix[0].Length;
        return BinarySearchMatrix(matrix, target, x, 0, x * y - 1);
    }

    private bool BinarySearchMatrix(int[][] matrix, int target, int x, int l, int r)
    {
        while (l <= r)
        {
            (int y, int x) mid = ((r + l) / 2 / x, (r + l) / 2 % x);
            // if (mid.y > matrix.Length - 1)
            //     return false;
            if (matrix[mid.y][mid.x] == target)
            {
                return true;
            }
            else if (matrix[mid.y][mid.x] > target)
            {
                r = mid.y * x + mid.x - 1;
            }
            else
            {
                l = mid.y * x + mid.x + 1;
            }
        }
        return false;
    }
    /*
    Leet 79. Word Search
    fine a word in a matrix 
    Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
    Output: false
    Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
    Output: true
    Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
    Output: true
    */

    record struct Yx(int y, int x);
    public bool Exist(char[][] board, string word)
    {
        for (var i = 0; i < board.Length; i++)// looping from all the cells in the matrix 
        {
            for (var j = 0; j < board[0].Length; j++)
            {
                if (RecExist(board, word, 0, i, j))
                    return true;
            }
        }
        return false;

    }

    private bool RecExist(char[][] board, string word, int index, int y, int x)
    {
        if (x < 0 || y < 0 || y > board.Length - 1 || x > board[0].Length - 1) //out of the board
            return false;

        var tmp = board[y][x];
        if (index == word.Length)// word is found
            return true;
        if (board[y][x] == word[index]) // we check if there is a match of the investigated char and also we flag the char to prevent visiting the same cell twice 
        {
            board[y][x] = '#';
        }
        else
        {
            return false;
        }

        List<(int dy, int dx)> offsets = [(1, 0), (0, 1), (-1, 0), (0, -1)];

        foreach (var offset in offsets)// running all 4 directions 
        {
            if (RecExist(board, word, index + 1, y + offset.dy, x + offset.dx))
                return true;
        }


        board[y][x] = tmp;
        return false;

    }

    /*
   this one ìs to find minimum range that will contain at least 1 element from a k sorted arrays of numbers 
   the same question is the question of facilities in a boat and find the perfect place to stay so we will need the least moves to get to all the facilities 
   in the second version each facility is a list with flor location 
   the algorism is 
   1. sort the arrays if they are not sorted 
   2. start with index 0 of all the list and get the minimum 
   3. calculate the difference between the min and the max (of the location 0 which is the min of the specific list)
   4. after recording the deference move the pointer to the next element of the min found 
   5. continue until one of the list ends 
       0,2,3,4,20
       5,6,7
       10,11,12,13,14

       so we start with 0,5,10 and advance the pointer at 0 the range is 0...10
       next is 2,5,10 -> 3,5,10 -> 4,5,10 -> 20,5,10->20,6,10->20,7,10 then we should peek 7 next but there is none 
       the best is 4...10

       for the coding we can choose PriorityQueue (min-heap) that will get us the next min if we enqueue the numbers in the deferent arrays and will pop them in order ,
        for the max we dont need it we cna use current max an compare with the global max (since we switch the min all the time but we dont do it for the max )
   */

    public (int?, int?) GetMinimumRangeOfAllArray(int[][] nums)
    {

        PriorityQueue<(int elm, int list), int> q = new();
        var poniters = new int[nums.Length];
        int? max = int.MinValue;
        int best = int.MaxValue;
        (int?, int?) ans = default;
        while (true)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                if (poniters[i] > nums[i].Length - 1)
                    return ans;
                var elm = nums[i][poniters[i]];
                max = Math.Max(max.Value, elm);
                q.Enqueue((elm, i), elm);
            }
            var currMin = q.Dequeue();
            var currDeference = max!.Value - currMin.elm;
            best = Math.Min(best, currDeference);
            if (currDeference == best)
            {
                ans = (currMin.elm, max);
            }
            poniters[currMin.list]++;
        }




    }

    //Leet 130. Surrounded Regions
    /*
    You are given an m x n matrix board containing letters 'X' and 'O', capture regions that are surrounded:

    Connect: A cell is connected to adjacent cells horizontally or vertically.
    Region: To form a region connect every 'O' cell.
    Surround: The region is surrounded with 'X' cells if you can connect the region with 'X' cells and none of the region cells are on the edge of the board.
    A surrounded region is captured by replacing all 'O's with 'X's in the input matrix board.

    Example 1:
    Input: board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]
    Output: [["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]]

    Example 2:
    Input: board = [["X"]]
    Output: [["X"]]

    the solution has 3 steps 
    1 define the borders 
    2 flag E for the cells need to transform from O to X (the occupied ones )
    3 make the transformation 
    */

    public void XOccupation(char[][] board)
    {
        if (board == null || board.Length == 0)
        {
            return;
        }

        var numOfRows = board.Length;
        var numOfCols = board[0].Length;
        List<(int y, int x)> borders = new();
        //  define the borders
        for (int r = 0; r < numOfRows; ++r)
        {
            borders.Add((r, 0));
            borders.Add((r, numOfCols - 1));
        }

        for (int c = 0; c < numOfCols; ++c)
        {
            borders.Add((0, c));
            borders.Add((numOfRows - 1, c));
        }
        // flag E for the cells need to transform from O to X (the occupied ones )
        foreach (var pair in borders)
        {
            BFSxOccupation(board, pair.y, pair.x, numOfRows, numOfCols);
        }
        // make the transformation 
        for (int r = 0; r < numOfRows; ++r)
        {
            for (int c = 0; c < numOfCols; ++c)
            {
                if (board[r][c] == 'O')
                    board[r][c] = 'X';
                if (board[r][c] == 'E')
                    board[r][c] = 'O';
            }
        }
    }

    protected void BFSxOccupation(char[][] board, int r, int c, int numOfRows, int numOfCols)
    {
        Queue<(int y, int x)> queue = new();
        queue.Enqueue((r, c));
        while (queue.Count > 0)
        {
            var pair = queue.Dequeue();
            int row = pair.y, col = pair.x;
            if (board[row][col] != 'O')// if a cell was flagged E then we assume all is connected cells were as well so we continue 
                continue;
            board[row][col] = 'E';
            if (col < numOfCols - 1)
                queue.Enqueue((row, col + 1));
            if (row < numOfRows - 1)
                queue.Enqueue((row + 1, col));
            if (col > 0)
                queue.Enqueue((row, col - 1));
            if (row > 0)
                queue.Enqueue((row - 1, col));
        }
    }
}
