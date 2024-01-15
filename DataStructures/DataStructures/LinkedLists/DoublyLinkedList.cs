namespace DataStructures.LinkedLists;

public class DoublyLinkedList<T>
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

        newNode.Previous = current;
        current.Next = newNode;
    }

    public void DisplayList()
    {
        Node<T> current = head;
        while (current.Next != null)
        {
            Console.WriteLine($"Data {current.Data} -> ");
            current = current.Next;
        }
 
        Console.WriteLine("End!");
    }

    public void AddNodeAtPosition(T data, int position)
    {
        Node<T> newNode = new Node<T>(data);

        if (position <= 0)
        {
            newNode.Next = head;
            if (head != null)
            {
                head.Previous = newNode;
            }

            head = newNode;
        }

        Node<T> current = head;
        for (int i = 0; i < position - 1 && current != null; i++)
        {
            current = current.Next;
        }

        if (current != null)
        {
            newNode.Previous = current;
            newNode = current.Next;

            if (current.Next != null)
            {
                current.Next.Previous = newNode;
            }

            current.Next = newNode;
        }
    }

    public void RemoveNode(T data)
    {
        Node<T> current = head;
        while (current != null && !current.Data.Equals(data))
        {
            current = current.Next;
        }

        if (current != null)
        {
            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
        }

        if (current.Next != null)
        {
            current.Next.Previous = current.Previous;
        }

        if (current == head)
        {
            head = current.Next;
        }
    }

    private Node<T> GetLastNode()
    {
        Node<T> current = head;
        while (current != null && current.Next != null)
        {
            current = current.Next;
        }

        return current;
    }
}