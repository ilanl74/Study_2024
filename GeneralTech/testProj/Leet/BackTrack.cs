using System.Security.Principal;

namespace Leet;

public class BackTrack
{
    public bool RunMaze(int[,] board)
    {
        int moves = 0;
        var b = Maze(board, 0, 0, moves);
        return b;
    }
    private bool Maze(int[,] board, int row, int coll, int moves)
    {
        var rows = board.GetLength(0);
        var colls = board.GetLength(1);

        if (rows - 1 == row && colls - 1 == coll)
        {

            if (!IsValidStep(board, row, coll))
                return false;

            board[row, coll] = 2;
            return true;
        }

        if (IsValidStep(board, row, coll))
        {
            board[row, coll] = 2;
            moves++;
            if (Maze(board, row + 1, coll, moves))
                return true;
            if (Maze(board, row, coll + 1, moves))
                return true;
            if (Maze(board, row - 1, coll, moves))
                return true;
            if (Maze(board, row, coll - 1, moves))
                return true;

            board[row, coll] = 1;
            moves--;
        }

        return false;
    }

    private bool IsValidStep(int[,] board, int row, int coll)
    {
        if (row < 0 || coll < 0)
            return false;

        var rows = board.GetLength(0);
        var colls = board.GetLength(1);
        if (!(row < rows) || !(coll < colls))
            return false;
        return (board[row, coll] == 1);


    }
}
