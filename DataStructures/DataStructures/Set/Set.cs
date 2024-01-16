using DataStructures.HashTable;

namespace DataStructures.Set;

public class Set<T>
{
    private HashSet<T> items;

    public Set()
    {
        items = new HashSet<T>();
    }

    public void Add(T item)
    {
        items.Add(item);
    }

    public bool Contains(T item)
    {
        return items.Contains(item);
    }

    public void Remove(T item)
    {
        items.Remove(item); 
    }

    public void Display()
    {
        Console.WriteLine("Set: ");
        foreach (var item in items)
        {
            Console.WriteLine($"{item}");   
        }

        Console.WriteLine();
    }
}