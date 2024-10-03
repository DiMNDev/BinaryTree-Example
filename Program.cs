// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

public class Node
{
    public int Data;
    public Node? Left;
    public Node? Right;
    public Node(int Data)
    {
        this.Data = Data;
        Left = null;
        Right = null;
    }
}

public class BestBinaryTree
{
    public Node? Root;
    public BestBinaryTree() { }

    public void InsertNode(int value)
    {
        Root = InsertNode(Root!, new Node(value));
    }
    public Node InsertNode(Node currentNode, Node data)
    {
        // Set at Root
        if (currentNode == null)
        {
            currentNode = data;
            return data;
        }
        // Check left
        if (data.Data < currentNode.Data)
        {
            currentNode.Left = InsertNode(currentNode.Left, data);
        }
        // Check right
        else if (data.Data > currentNode.Data)
        {
            currentNode.Right = InsertNode(currentNode.Right, data);
        }
        return currentNode;
    }

    public void ClearTree()
    {
        Root = null;
    }

    public Node FindMin(Node currentNode)
    {
        while (currentNode.Left != null)
        {
            currentNode = currentNode.Left;
        }
        return currentNode;
    }
    public Node FindMax(Node currentNode)
    {
        while (currentNode.Right != null)
        {
            currentNode = currentNode.Right;
        }
        return currentNode;
    }

    public BestBinaryTree(Node node)
    {
        Root = node;
    }

    #region Traversal Types

    // In-Order (LNR) Left, Node, Right
    public void InOrderTraversal(Node node)
    {
        if (node == null)
        {
            return;
        }

        InOrderTraversal(node.Left);
        Console.WriteLine(node.Data + " ");
        InOrderTraversal(node.Right);
    }

    // Pre-Order (NLR) Node, Left, Right
    public void PreOrderTraversal(Node node)
    {
        if (node == null)
        {
            return;
        }

        Console.WriteLine(node.Data + " ");
        PreOrderTraversal(node.Left);
        PreOrderTraversal(node.Right);
    }

    // Post-Order (LRN) Left, Right, Node
    public void PostOrderTraversal(Node node)
    {
        if (node == null)
        {
            return;
        }

        PostOrderTraversal(node.Left);
        PostOrderTraversal(node.Right);
        Console.WriteLine(node.Data + " ");
    }
    // Level-Order Level by Level, left-right

    public void LevelOrderTraversal(Node root)
    {
        if (root == null) return;

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            Console.WriteLine(current.Data + " ");

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }
            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }
    }

    #endregion

    public void DescendingTraversal(Node node)
    {
        if (node == null)
        {
            return;
        }

        DescendingTraversal(node.Right!);
        Console.WriteLine(node.Data + " ");
        DescendingTraversal(node.Left!);
    }

    public int GetHeight(Node node)
    {
        if (node == null)
        {
            return -1;
        }

        return Math.Max(GetHeight(node.Left!), GetHeight(node.Right!)) + 1;
    }

    public bool TreeIsBalanced()
    {
        int LeftHeight = GetHeight(Root!.Left!);
        int RightHeight = GetHeight(Root.Right!);
        Console.WriteLine($"Left: {LeftHeight}");
        Console.WriteLine($"Right: {RightHeight}");

        if (LeftHeight - RightHeight >= -1 && LeftHeight - RightHeight <= 1) return true;
        return false;
    }
}

class Program
{
    static void Main()
    {
        Console.Clear();
        BestBinaryTree tree = new BestBinaryTree();

        tree.InsertNode(5);
        tree.InsertNode(4);
        tree.InsertNode(3);
        tree.InsertNode(6);
        tree.InsertNode(8);
        tree.InsertNode(7);
        tree.InsertNode(9);
        tree.InsertNode(2);

        tree.InOrderTraversal(tree.Root!);
        tree.DescendingTraversal(tree.Root!);

        int height = tree.GetHeight(tree.Root!);
        Console.WriteLine($"Height: {height}");
        bool Balanced = tree.TreeIsBalanced();
        Console.WriteLine($"Balanced: {Balanced}");
        tree.LevelOrderTraversal(tree.Root!);
    }
}