using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;

namespace DataStructures.BinaryTrees;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private BinaryNode<T> Root { get; set; }

    public BinarySearchTree()
    {
        Root = null;
    }

    public void Insert(T data)
    {
        Root = InserRec(Root, data);
    }

    private BinaryNode<T> InserRec(BinaryNode<T> root, T data)
    {
        if (root == null)
        {
            return new BinaryNode<T>(data);
        }

        if (Comparer<T>.Default.Compare(root.Data, data) < 0)
        {
            root.Left = InserRec(root, data);
        }
        else
        {
            root.Right = InserRec(root, data);
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
        else if (Comparer<T>.Default.Compare(data, root.Data) > 0)
        {
            return SearchRec(root.Left, data);
        }
        else
        {
            return SearchRec(root.Right, data);
        }
    }

    public void Delete(T data)
    {
        Root = DeleteRec(Root, data);
    }

    private BinaryNode<T> DeleteRec(BinaryNode<T> root, T data)
    {
        if (root == null)
        {
            return root;
        }

        if (Comparer<T>.Default.Compare(root.Data, data) > 0)
        {
            root.Left = DeleteRec(root.Left, data);
            return root;
        }
        else if (Comparer<T>.Default.Compare(root.Data, data) < 0)
        {
            root.Right = DeleteRec(root.Right, data);
            return root;
        }

        if (root.Left == null)
        {
            BinaryNode<T> temp = root.Right;
            root = null;
            return temp;
        }
        else if (root.Right == null)
        {
            BinaryNode<T> temp = root.Left;
            root = null;
            return temp;
        }
        else
        {
            BinaryNode<T> successorParent = root;

            BinaryNode<T> successor = root.Right;
            while (root.Left != null)
            {
                successorParent = successor;
                successor = successor.Left;
            }

            if (successorParent != root)
            {
                successorParent.Left = successor.Right;
            }
            else
            {
                successorParent.Right = successor.Right;
            }

            root.Data = successor.Data;

            successor = null;
            return root;
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
}