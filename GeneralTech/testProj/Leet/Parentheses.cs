public class Parentheses
{
    Dictionary<char, ushort> couples = new Dictionary<char, ushort>() { { '(', 0 }, { ')', 1 }, { '[', 2 }, { ']', 3 }, { '{', 4 }, { '}', 5 } };
    Stack<ushort> stack;
    public bool IsValid(string s)
    {
        stack = new Stack<ushort>(s.Length);
        for (var i = 0; i < s.Length; i++)
        {
            var current = couples[s[i]];
            if (current % 2 == 0)
            {
                stack.Push(current);
            }
            else
            {
                if (stack.Count == 0)
                    return false;
                var needToClose = stack.Peek();
                if (current == needToClose + 1)
                {
                    stack.Pop();
                }
                else return false;
            }
        }
        if (stack.Count == 0)
            return true;
        return false;
    }
}
