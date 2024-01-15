namespace DataStructures.List;

using System;
using System.Runtime.InteropServices;

public class List<T> where T : IComparable<T>
{
    private T[] items;
    private int nextIndex;

    public List(int initialCapacity)
    {
        items = new T[initialCapacity];
        nextIndex = 0;
    }

    public void AddElement(T value)
    {
        if (nextIndex >= items.Length)
        {
            Array.Resize(ref items, items.Length * 2);
        }

        items[nextIndex] = value;
        nextIndex++;
    }

    public T GetElement(int index)
    {
        if (index < 0 || index > items.Length)
        {
            throw new IndexOutOfRangeException("This Index is out of range");
        }

        return items[index];
    }

    public void Sort()
    {
    }

    public void QuickSort(T[] array, int low, int high)
    {
        if (low < high)
        {
            int mid = Partition(array, low, high);

            QuickSort(array, low, mid - 1);
            QuickSort(array, mid + 1, high);
        }
    }

    private static int Partition(T[] array, int low, int high)
    {
        var mid = (low + high) / 2;

        T pivot = MedianOfThree(array[low], array[mid], array[high]);

        int i = low - 1;

        for (int j = low; j <= high - 1; j++)
        {
            if (array[j].CompareTo(pivot) <= 0)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);
        return i + 1;
    }

    private static void Swap(T[] array, int i, int j)
    {
        (array[i], array[j]) = (array[j], array[i]);
    }

    private static T MedianOfThree(T a, T b, T c)
    {
        if ((b.CompareTo(a) <= 0 && a.CompareTo(c) <= 0) || (c.CompareTo(a) <= 0 && a.CompareTo(b) <= 0))
        {
            return a;
        }
        else if ((a.CompareTo(b) <= 0 && b.CompareTo(c) <= 0) || (c.CompareTo(b) <= 0) && b.CompareTo(a) <= 0)
        {
            return b;
        }
        else
        {
            return c;
        }
    }
}