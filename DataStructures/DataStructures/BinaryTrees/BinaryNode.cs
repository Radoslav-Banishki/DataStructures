namespace DataStructures.BinaryTrees;

public class BinaryNode<T> where T : IComparable<T>
{
    public T Data { get; set; }
    public BinaryNode<T> Left { get; set; }
    public BinaryNode<T> Right { get; set; }

    public BinaryNode(T data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}