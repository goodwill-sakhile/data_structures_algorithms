// LowestCommonAncestor implementation in C#
using System;

namespace BinaryTreeLCA
{
    public class Node
    {
        public int Data;
        public Node Left, Right;

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

        // Function to find Lowest Common Ancestor
        public Node LowestCommonAncestor(Node root, Node p, Node q)
        {
            if (root == null || root == p || root == q)
                return root;

            Node left = LowestCommonAncestor(root.Left, p, q);
            Node right = LowestCommonAncestor(root.Right, p, q);

            if (left != null && right != null)
                return root;

            return left ?? right;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            /*
                  3
                 / \
                5   1
               / \ / \
              6  2 0  8
                / \
               7   4
            */

            tree.Root = new Node(3);
            tree.Root.Left = new Node(5);
            tree.Root.Right = new Node(1);
            tree.Root.Left.Left = new Node(6);
            tree.Root.Left.Right = new Node(2);
            tree.Root.Right.Left = new Node(0);
            tree.Root.Right.Right = new Node(8);
            tree.Root.Left.Right.Left = new Node(7);
            tree.Root.Left.Right.Right = new Node(4);

            Node p = tree.Root.Left;             // Node 5
            Node q = tree.Root.Left.Right.Right; // Node 4

            Node lca = tree.LowestCommonAncestor(tree.Root, p, q);

            Console.WriteLine($"Lowest Common Ancestor of {p.Data} and {q.Data} is: {lca.Data}");
        }
    }
}
