using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace DataStructures.BinaryTrees;

public class BinaryTree<T> where T : IComparable<T>
{
    private BinaryNode<T> Root { get; set; }

    public BinaryTree()
    {
        Root = null;
    }

    public void Insert(T data)
    {
        Root = InsertRec(Root, data);
    }

    private BinaryNode<T> InsertRec(BinaryNode<T> root, T data)
    {
        if (root == null)
        {
            return new BinaryNode<T>(data);
        }

        if (Comparer<T>.Default.Compare(data, root.Data) < 0)
        {
            root.Left = InsertRec(root.Left, data);
        }
        else if (Comparer<T>.Default.Compare(data, root.Data) > 0)
        {
            root.Right = InsertRec(root.Right, data);
        }

        return root;
    }

    public bool Search(T data)
    {
        return SearchRec(Root, data);
    }

    private bool SearchRec(BinaryNode<T> root, T data)
    {
        if (root == null)
        {
            return false;
        }

        if (Comparer<T>.Default.Compare(data, root.Data) == 0)
        {
            return true;
        }
        else if (Comparer<T>.Default.Compare(data, root.Data) < 0)
        {
            return SearchRec(root.Left, data);
        }
        else
        {
            return SearchRec(root.Right, data);
        }
    }

    public void InOrderTraversal()
    {
        InOrderTraversalRec(Root);
        Console.WriteLine();
    }
    
    private void InOrderTraversalRec(BinaryNode<T> root)
    {
        if (root != null)
        {
            InOrderTraversalRec(root.Left);
            Console.WriteLine($"{root.Data}");
            InOrderTraversalRec(root.Right);
        }
        
    }

    public void PostOrderTraversal()
    {
        PostOrderTraversalRec(Root);
        Console.WriteLine();
    }

    private void PostOrderTraversalRec(BinaryNode<T> root)
    {
        if (root != null)
        {
            PostOrderTraversalRec(root.Left);
            PostOrderTraversalRec(root.Right);
            Console.WriteLine($"{root.Data}");
        }
    }

    public void PreOrderTraversal()
    {
        PreOrderTraversalRec(Root);
        Console.WriteLine();
    }

    private void PreOrderTraversalRec(BinaryNode<T> root)
    {
        if (root != null)
        {
            Console.WriteLine($"{root.Data}");
            PreOrderTraversalRec(root.Left);
            PreOrderTraversalRec(root.Right);
        }
    }

}