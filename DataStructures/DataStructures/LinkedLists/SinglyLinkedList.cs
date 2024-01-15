namespace DataStructures.LinkedLists;

public class SinglyLinkedList<T>
{
    private Node<T> head;

    public void AddNode(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (head == null)
        {
            head = newNode;
        }

        Node<T> current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newNode;
    }

    public void DisplayElements()
    {
        Node<T> current = head;
        while (current.Next != null)
        {
            Console.WriteLine($"{current.Data} -> ");
            current = current.Next;
        }

        Console.WriteLine("End!");
    }

    public void RemoveNode(T data)
    {
        if (head == null)
        {
            throw new ArgumentException("List is empty.");
        }

        if (head.Equals(data))
        {
            head = head.Next;
        }

        Node<T> current = head;
        while (current.Next != null && !current.Next.Equals(data))
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    public void InsertNodeAtPosition(T data, int position)
    {
        Node<T> newNode = new Node<T>(data);

        if (position <= 0)
        {
            newNode.Next = head;
            head = newNode;
        }

        Node<T> current = head;
        for (int i = 0; i < position-1 && current!=null; i++)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            newNode.Next = current.Next;
            current.Next = newNode;
        }
    }
}