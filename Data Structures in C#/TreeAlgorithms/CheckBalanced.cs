// CheckBalanced implementation in C#
using System;

namespace BinaryTreeBalancedCheck
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

        // Main method to check if the tree is balanced
        public bool IsBalanced()
        {
            return CheckHeight(Root) != -1;
        }

        // Helper method that returns -1 if unbalanced, otherwise height
        private int CheckHeight(Node node)
        {
            if (node == null)
                return 0;

            int leftHeight = CheckHeight(node.Left);
            if (leftHeight == -1)
                return -1;

            int rightHeight = CheckHeight(node.Right);
            if (rightHeight == -1)
                return -1;

            if (Math.Abs(leftHeight - rightHe

