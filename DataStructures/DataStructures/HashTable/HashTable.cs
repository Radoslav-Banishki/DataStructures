namespace DataStructures.HashTable;

public class HashTable<TKey, TValue>
{
    private readonly int Capacity;
    private List<KeyValuePair<TKey, TValue>>[] buckets;

    public HashTable(int capacity)
    {
        capacity = Capacity;
        buckets = new List<KeyValuePair<TKey, TValue>>[capacity];
    }

    private int GetHashIndex(TKey key)
    {
        int hashCode = key.GetHashCode();
        return hashCode % Capacity;
    }

    private void Add(TKey key, TValue value)
    {
        int index = GetHashIndex(key);

        if (buckets[index] == null)
        {
            buckets[index] = new List<KeyValuePair<TKey, TValue>>();
        }

        foreach (var kvp in buckets[index])
        {
            if (EqualityComparer<TKey>.Default.Equals(kvp.Key, key))
            {
                throw new ArgumentException("Key already exists");
            }
        }
        
        buckets[index].Add(new KeyValuePair<TKey, TValue>(key,value));
    }

    private bool TryGetValue(TKey key, out TValue value)
    {
        int index = GetHashIndex(key);

        if (buckets[index] != null)
        {
            foreach (var kvp in buckets[index])
            {
                if (EqualityComparer<TKey>.Default.Equals(key))
                {
                    value = kvp.Value;
                    return true;
                }
            }
        }

        value = default(TValue);
        return false;
    }

    private void Remove(TKey key)
    {
        int index = GetHashIndex(key);

        if (buckets[index] != null)
        {
            buckets[index].RemoveAll(kvp => EqualityComparer<TKey>.Default.Equals(kvp.Key, key));
        }
    }
}