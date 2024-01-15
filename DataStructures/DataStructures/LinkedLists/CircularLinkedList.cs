namespace DataStructures.LinkedLists;

public class CircularLinkedList<T>
{
    private Node<T> head;

    public void AddNode(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (head == null)
        {
            head = newNode;
            head.Next = head;
        }

        Node<T> current = head;
        while (current.Next != head)
        {
            current = current.Next;
        }

        newNode.Next = head;
        current.Next = newNode;
    }

    public void DisplayList()
    {
        Node<T> current = head;
        while (current.Next != head)
        {
            Console.WriteLine($"Data {current.Data} -> ");
            current = current.Next;
        }

        Console.WriteLine("End.");
    }

    public void AddNodeAtPosition(T data, int position)
    {
        Node<T> newNode = new Node<T>(data);

        if (position <= 0)
        {
            head = newNode;
            if (head != null)
            {
                head.Previous = newNode;
            }
            head.Next = head;
        }

        Node<T> current = head;
        for (int i = 0; i < position-1 && current.Next!=head; i++)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        current.Next = newNode;
    }

    public void RemoveNode(T data)
    {
        if (head == null)
        {
            return;
        }

        Node<T> current = head;
        while (current.Next != head && !current.Next.Data.Equals(data))
        {
            current = current.Next;
        }

        if (current.Next.Data.Equals(data))
        {
            current.Next = current.Next.Next;
            if (current.Next == head)
            {
                head = current.Next.Next;
            }
        }
    }
}