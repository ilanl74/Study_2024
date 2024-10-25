using System.Globalization;
using System.Security.Principal;

namespace Leet;

public class BackTrack
{
    //the maze is composed by 0,1 
    //you can only run on the 1
    // the function should return if we can get to the end cell 
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

        if (rows - 1 == row && colls - 1 == coll) // this is the end cell  
        {

            if (!IsValidStep(board, row, coll))
                return false;

            board[row, coll] = 2; // this is where we flag where we have been already 
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

            board[row, coll] = 1; // this is the backtrack 
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

    //Leet 17. Letter Combinations of a Phone Number
    // 2-> a,b,c
    // 3-> d,e,f
    // 4-> g,h,i
    // 5-> j,k,l
    // 6-> m,n,o
    // 7-> p,q,r,s
    // 8-> t,u,v
    // 9-> w,x,y,z
    public IList<string> LetterCombinations(string digits)
    {
        int size = (int)Math.Pow(digits.Length, 3);
        List<string> ans = new List<string>(size);
        Dictionary<int, char[]> map = new() { { 2, new char[] { 'a', 'b', 'c' } }, { 3, new char[] { 'd', 'e', 'f' } }, { 4, new char[] { 'g', 'h', 'i' } }, { 5, new char[] { 'j', 'k', 'l' } }, { 6, new char[] { 'm', 'n', 'o' } }, { 7, new char[] { 'p', 'q', 'r', 's' } }, { 8, new char[] { 't', 'u', 'v' } }, { 9, new char[] { 'w', 'x', 'y', 'z' } } };
        if (digits.Length == 0)
        {
            return ans;
        }
        RecLetterCombinations(digits, 0, ans, map);
        return ans;
    }

    private void RecLetterCombinations(string digits, int first, List<string> ans, Dictionary<int, char[]> map, string curr = "")
    {
        if (curr.Length == digits.Length)
        {
            ans.Add(curr);
            return;
        }

        for (var i = first; i < digits.Length; i++)
        {
            var d = digits[i] - '0';
            foreach (var c in map[d])
            {
                curr += c;
                RecLetterCombinations(digits, i + 1, ans, map, curr);
                curr = curr.Remove(curr.Length - 1);

            }
        }
    }


    public List<int[]> GetSubset1(int[] arr)
    {
        List<int[]> ans = new List<int[]>(arr.Length * arr.Length);

        for (var i = 0; i <= arr.Length; i++)
        {
            BackTrackSub(arr, ans, new List<int>(1), i, 0); // we control the number of items in the arr 
        }
        return ans;
    }
    private void BackTrackSub(int[] arr, List<int[]> ans, List<int> curr, int len, int index)
    {
        if (curr.Count == len)
        {
            ans.Add(curr.ToArray());
            return;
        }
        for (var i = index; i < arr.Length; i++)
        {
            curr.Add(arr[i]);
            BackTrackSub(arr, ans, curr, len, i + 1);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}
