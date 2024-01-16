using System.ComponentModel.DataAnnotations;

namespace DataStructures.Map;

public class Map<TKey, TValue>
{
    private Dictionary<TKey, TValue> items;

    public Map()
    {
        items = new Dictionary<TKey, TValue>();
    }

    private void Add(TKey key, TValue value)
    {
        items[key] = value;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        return items.TryGetValue(key, out value);
    }

    public bool ContainsKey(TKey key)
    {
        return items.ContainsKey(key);
    }

    public void Remove(TKey key)
    {
        items.Remove(key);
    }

    public void Display()
    {
        Console.WriteLine("Map: ");
        foreach (var pair in items)
        {
            Console.WriteLine($"{pair.Key} {pair.Value}");
        }
    }
}