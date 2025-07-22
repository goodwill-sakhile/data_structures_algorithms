// BinarySearchTreeOperations implementation in C#
using System;

namespace BinarySearchTreeApp
{
    public class Node
    {
        public int Data;
        public Node Left, Right;

        public Node(int item)
        {
            Data = item;
            Left = Right = null;
        }
    }

    public class BinarySearchTree
    {
        public Node Root;

        public BinarySearchTree()
        {
            Root = null;
        }

        // Insert operation
        public void Insert(int data)
        {
            Root = InsertRec(Root, data);
        }

        private Node InsertRec(Node root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }

            if (data < root.Data)
                root.Left = InsertRec(root.Left, data);
            else if (data > root.Data)
                root.Right = InsertRec(root.Right, data);

            return root;
        }

        // Search operation
        public bool Search(int key)
        {
            return SearchRec(Root, key) != null;
        }

        private Node SearchRec(Node root, int key)
        {
            if (root == null || root.Data == key)
                return root;

            if (key < root.Data)
                return SearchRec(root.Left, key);

            return SearchRec(root.Right, key);


