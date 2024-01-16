using DataStructures.LinkedLists;

namespace DataStructures.Queue;

public class Queue<T>
{
    private Node<T> head;
    private Node<T> tail;

    public void Enqueue(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (IsEmpty(tail))
        {
            head = newNode;
            tail = newNode;
        }

        tail.Next = newNode;
        tail = newNode;
    }

    public T Dequeue()
    {
        if (IsEmpty(head))
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T data = head.Data;
        head = head.Next;

        if (IsEmpty(head))
        {
            tail = null;
        }

        return data;
    }

    public T Peek()
    {
        if (IsEmpty(head))
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return head.Data;
    }

    private bool IsEmpty(Node<T> node)
    {
        return node == null;
    }
}