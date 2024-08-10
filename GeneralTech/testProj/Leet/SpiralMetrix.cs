

namespace Leet;

public class SpiralMetrix
{
    enum Direction
    {
        Right,
        Down,
        Left,
        Up
    }
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var rows = matrix.Length;
        var colls = matrix[0].Length;
        List<int> ans = new(rows * colls);

        int row = 0;
        int coll = 0;
        Direction dir = Direction.Right;
        int loopNum = 0;
        while (ans.Count < rows * colls)
        {
            ans.Add(matrix[row][coll]);

            switch (dir)
            {
                case Direction.Right:
                    if (!IsValidMove(row, coll + 1, dir, rows, colls, loopNum))
                        dir = dir++;
                    else
                        coll++;
                    break;
                case Direction.Down:
                    if (!IsValidMove(row + 1, coll, dir, rows, colls, loopNum))
                        dir = dir++;
                    else
                        row++;
                    break;
                case Direction.Left:
                    if (!IsValidMove(row, coll - 1, dir, rows, colls, loopNum))
                        dir = dir++;
                    else
                        coll--;
                    break;
                case Direction.Up:
                    if (!IsValidMove(row - 1, coll, dir, rows, colls, loopNum))
                        dir = dir++;
                    else
                        loopNum++;
                    row--;
                    break;
            }
        }
        return ans;
    }



    private bool IsValidMove(int row, int coll, Direction dir, int rows, int colls, int loopNum)
    {
        if (!(row < rows) || !(coll < colls))
            return false;
        switch (dir)
        {
            case Direction.Right:
                return coll < (colls - loopNum);
            case Direction.Down:
                return row < (rows - loopNum);
            case Direction.Left:
                return coll > loopNum;
            case Direction.Up:
                return row > loopNum + 1;
        }
        return true;
    }
}
