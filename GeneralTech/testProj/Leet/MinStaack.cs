using System;

namespace Leet;
/*
    Leet 155 minstack 
    Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

    Implement the MinStack class:

    MinStack() initializes the stack object.
    void push(int val) pushes the element val onto the stack.
    void pop() removes the element on the top of the stack.
    int top() gets the top element of the stack.
    int getMin() retrieves the minimum element in the stack.
    You must implement a solution with O(1) time complexity for each function.

    the trick is to use the data structure in the class and in push maintain a Tuple that has the value and the min until now (this will serve the GetMin function)
*/
public class MinStack
{

    Stack<(int val, int min)> s;

    public MinStack()
    {
        s = new();
    }

    public void Push(int val)
    {
        int min;
        if (!s.Any())
            min = val;
        else min = GetMin();
        min = Math.Min(val, min);
        s.Push((val, min));

    }

    public void Pop()
    {
        s.Pop();
    }

    public int Top()
    {
        return s.Peek().val;
    }

    public int GetMin()
    {
        return s.Peek().min;
    }
}

