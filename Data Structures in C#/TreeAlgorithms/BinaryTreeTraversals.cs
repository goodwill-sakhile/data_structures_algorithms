// BinaryTreeTraversals implementation in C#
using System;
using System.Collections.Generic;

namespace BinaryTreeTraversals
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

        // InOrder Traversal (Left, Root, Right)
        public void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                Console.Write(root.Data + " ");
                InOrder(root.Right);
            }
        }

        // PreOrder Traversal (Root, Left, Right)
        public void PreOrder(Node root)
        {
            if (root != null)
            {
                Console.Write(root.Data + " ");
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }

        // PostOrder Traversal (Left, Right, Root)
        public void PostOrder(Node root)
        {
            if (root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                Console.Write(root.Data + " ");
            }
        }

        // LevelOrder Traversal (Breadth-First)
        public void LevelOrder(Node root)
        {
            if (root == null) return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enque
