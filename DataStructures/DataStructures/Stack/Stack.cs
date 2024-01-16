using System.Reflection;
using DataStructures.LinkedLists;

namespace DataStructures.Stack;

public class Stack<T>
{
    private Node<T> top;

    public void Push(T data)
    {
        Node<T> newNode = new Node<T>(data);
        newNode.Next = top;
        top = newNode;
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }

        T data = top.Data;
        top = top.Next;
        return data;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return top.Data;
    }

    public bool IsEmpty()
    {
        return top == null;
    }
}