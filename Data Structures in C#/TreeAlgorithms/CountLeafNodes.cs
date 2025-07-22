// CountLeafNodes implementation in C#
using System;

namespace BinaryTreeLeafCounter
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

        // Count leaf nodes
        public int CountLeafNodes(Node node)
        {
            if (node == null)
                return 0;

            if (node.Left == null && node.Right == null)
                return 1;

            return CountLeafNodes(node.Left) + CountLeafNodes(node.Right);
        }
    }

    class Program
    {
        static void Main(string[] args)
