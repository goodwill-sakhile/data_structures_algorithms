// InvertTree implementation in C#
using System;

namespace BinaryTreeInversion
{
    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;

        public Node(int data)
        {
            Data = data;
            Left = Right = null;
        }
    }

    public class BinaryTree
    {
        public Node Root;

        public BinaryTree()
        {
            Root = null;
        }

        // Invert the binary tree
        public Node Invert(Node node)
        {
            if (node == null)
                return null;

            // Recursively invert subtrees
            Node left = Invert(node.Left);
            Node right = Invert(node.Right);

            // Swap left and right
            node.Left = right;
            node.Right = left;

            return node;
        }

        // InOrder Traversal for displaying the tree
        public void InOrder(Node node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                Console.Write(node.Data + " ");
                InOrder(node.Right);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            // Sample Tree:
            //        1
            //       / \
            //      2   3
            //     / \
            //    4   5

            tree.Root = new Node(1);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(3);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);

            Console.WriteLine("Original Tree (InOrder):");
            tree.InOrder(tree.Root);

            tree.Invert(tree.Root);

            Console.WriteLine("\nInverted Tree (InOrder):");
            tree.InOrder(tree.Root);
        }
    }
}
