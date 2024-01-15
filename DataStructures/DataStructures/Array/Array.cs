namespace DataStructures.Array;

public class Array<T> where T : IComparable<T>
{
    private T[] items;
    private int nextIndex;

    public Array(int size)
    {
        items = new T[size];
        nextIndex = 0;
    }

    public T GetElement(int index)
    {
        if (index < 0 || index >= nextIndex)
        {
            throw new IndexOutOfRangeException();
        }

        return items[index];
    }

    public void SetElement(int index, T value)
    {
        if (index < 0 || index > items.Length)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        items[index] = value;
    }

    public void AddElement(T value)
    {
        if (nextIndex >= items.Length)
        {
            throw new IndexOutOfRangeException("Array is full.");
        }

        items[nextIndex] = value;
        nextIndex++;
    }

    public int Length
    {
        get { return nextIndex; }
    }

    public void Sort()
    {
        QuickSort(items, 0, nextIndex - 1);
    }

    private void QuickSort(T[] array, int low, int high)
    {
        if (low < high)
        {
            int mid = Partition(array, low, high);
            
            QuickSort(array,low,mid-1);
            QuickSort(array,mid+1,high);
        }
    }

    private int Partition(T[] array, int low, int high)
    {
        int mid = (low + high) / 2;

        T pivot = MedianOfThree(array[low], array[mid], array[high]);

        int i = low - 1;

        for (int j = low; j <= high-1; j++)
        {
            if (array[j].CompareTo(pivot) <= 0)
            {
                i++;

                (array[i], array[j]) = (array[j], array[i]);
            }
        }

        (array[i + 1], array[high]) = (array[high], array[i + 1]);

        return i + 1;
    }

    private T MedianOfThree(T a, T b, T c)
    {
        if ((b.CompareTo(a) <= 0 && a.CompareTo(c) <= 0) || (c.CompareTo(a) <= 0 && a.CompareTo(b) <= 0))
        {
            return a;
        }
        else if ((a.CompareTo(b) <= 0 && b.CompareTo(c) <= 0) || (c.CompareTo(b) <= 0 && b.CompareTo(a) <= 0))
        {
            return b;
        }
        else
        {
            return c;
        }
    }

    public static void Reverse<T>(T[] array)
    {
        int left=0;
        int right = array.Length - 1;

        while (left<right)
        {
            (array[left], array[right]) = (array[right], array[left]);

            left++;
            right--;
        }
    }
}