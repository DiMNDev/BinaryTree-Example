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
    public void DescendingTraversal(Node node)
    {
        if (node == null)
        {
            return;
        }

        DescendingTraversal(node.Right);
        Console.WriteLine(node.Data + " ");
        DescendingTraversal(node.Left);
    }

    public int GetHeightFrom(Node node, Direction direction, int count)
    {
        if (node == null)
        {

            return count;
        }

        switch (direction)
        {
            case Direction.Left:
                return GetHeightFrom(node.Left, direction, ++count);
            case Direction.Right:
                return GetHeightFrom(node.Right, direction, ++count);
            default:
                return 0;
        }
    }

    public bool TreeIsBalanced()
    {
        if (GetHeightFrom(Root, Direction.Left, 0) - GetHeightFrom(Root, Direction.Right, 0) <= 1 && GetHeightFrom(Root, Direction.Left, 0) - GetHeightFrom(Root, Direction.Right, 0) >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

class Program
{
    static void Main()
    {
        BestBinaryTree tree = new BestBinaryTree();
        // tree.Root = new Node(5);
        // tree.Root.Left = new Node(3);
        // tree.Root.Left.Left = new Node(2);
        // tree.Root.Left.Right = new Node(4);
        // tree.Root.Right = new Node(6);
        // tree.Root.Right.Right = new Node(8);
        // tree.Root.Right.Right.Left = new Node(7);
        // tree.Root.Right.Right.Right = new Node(9);

        tree.InsertNode(5);
        tree.InsertNode(3);
        tree.InsertNode(2);
        tree.InsertNode(4);
        tree.InsertNode(6);
        tree.InsertNode(8);
        tree.InsertNode(7);
        tree.InsertNode(9);
        tree.InsertNode(19);

        tree.InOrderTraversal(tree.Root);
        tree.DescendingTraversal(tree.Root);

        int LeftHeight = tree.GetHeightFrom(tree.Root, Direction.Left, 0);
        Console.WriteLine($"LeftCount: {LeftHeight}");
        int RightHeight = tree.GetHeightFrom(tree.Root, Direction.Right, 0);
        Console.WriteLine($"RightCount: {RightHeight}");

        Console.WriteLine($"Tree is Balanced: {tree.TreeIsBalanced()}");
    }
}

public enum Direction
{
    Left,
    Right
}