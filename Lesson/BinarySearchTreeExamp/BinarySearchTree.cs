using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeExamp.CustomBTS
{
    enum TraversalOrder
    {
        InOrder,
        PreOrder,
        PostOrder
    }

    class BinarySearchTree<T> where T : IComparable<T>
    {
        class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Data { get; set; }
            public Node(T value)
            {
                Data = value;
            }
        }
        Node Root { get; set; }
        bool IsEmpty => Root is null;
        public void Insert(T value)
        {
            Node Insert(Node root)
            {
                if (root is null) root = new Node(value);
                else
                {
                    if (root.Data.CompareTo(value) > 0) root.Left = Insert(root.Left);
                    else root.Right = Insert(root.Right);
                }
                return root;
            }
            Root = IsEmpty ? new Node(value) : Insert(Root);
        }
        public bool Delete(T value)
        {
            Node tmp = Root,parent = Root;
            while(tmp != null)
            {
                if (tmp.Data.Equals(value))
                {
                    /*Case 1: Leaf*/
                    if (tmp.Left is null && tmp.Right is null)
                    {
                        if(parent.Left == tmp)
                        {
                            parent.Left = null;
                        }
                        else
                        {
                            parent.Right = null;
                        }
                    }
                    /*Case 2: One Child*/
                    //left
                    else if (tmp.Left != null && tmp.Right is null)
                    {
                        if (parent.Right == tmp)
                        {
                            parent.Right = tmp.Left;
                        }
                        else
                        {
                            parent.Left = tmp.Left;
                        }
                    }
                    //right
                    else if(tmp.Left is null && tmp.Right != null)
                    {
                        if (parent.Right == tmp)
                        {
                            parent.Right = tmp.Right;
                        }
                        else
                        {
                            parent.Left = tmp.Right;
                        }
                    }
                    /*Case 3: Two childeren*/
                    else
                    {
                        //Node replacement = FindNode(tmp.Right);
                        //if (parent.Left == tmp)
                        //{
                        //    tmp.Data = replacement.Data;
                        //}
                    }
                }
                tmp = tmp.Data.CompareTo(value) > 0 ? tmp.Left : tmp.Right;
            }
            return false;
            //Node Delete(Node parent)
            //{
            //    if (parent is null) return parent;

            //    if (parent.Data.CompareTo(value) > 0) parent.Left = Delete(parent.Left);
            //    else if (parent.Data.CompareTo(value) < 0) parent.Right = Delete(parent.Right);

            //    else
            //    {
            //        if (parent.Left is null) return parent.Right;
            //        else if (parent.Right is null) return parent.Left;
            //    }
            //    return parent;
            //}
            //if (IsEmpty) return false;
            //if (!Find(value)) return false;
            //Delete(Root);
            //return true;
        }

        Node FindNode(Node root)
        {
            Node tmpCurr = root;
            while (tmpCurr.Left != null)
            {
                tmpCurr = tmpCurr.Left;
            }
            return tmpCurr;
        }

        public bool Find(T searchTerm)
        {
            bool Find(Node root)
            {
                if (root is null) return false;
                if (root.Data.Equals(searchTerm)) return true;
                return (root.Data.CompareTo(searchTerm) > 0) ? Find(root.Left) : Find(root.Right);
            }
            return Find(Root);
        }
        public int Depth => MaxDepth(Root);
        int MaxDepth(Node parent) => parent is null ? 0 : Math.Max(MaxDepth(parent.Left), MaxDepth(parent.Right)) + 1;
        public void Traverse(TraversalOrder order, Action<T> action)
        {
            switch (order)
            {
                case TraversalOrder.InOrder:
                    TraverseInOrder(Root, action);
                    break;
                case TraversalOrder.PreOrder:
                    TraversePreOrder(Root, action);
                    break;
                case TraversalOrder.PostOrder:
                    TraversePostOrder(Root, action);
                    break;
            }
        }
        void TraverseInOrder(Node root, Action<T> action)
        {
            void TraverseInOrder(Node parent)
            {
                if (parent is null) return;
                if (parent.Left != null) TraverseInOrder(parent.Left);
                action(parent.Data);
                if (parent.Right != null) TraverseInOrder(parent.Right);
            }
            TraverseInOrder(root);
        }
        void TraversePreOrder(Node root, Action<T> action)
        {
            void TraversePreOrder(Node parent)
            {
                if (parent is null) return;
                action(parent.Data);
                if (parent.Left != null) TraversePreOrder(parent.Left);
                if (parent.Right != null) TraversePreOrder(parent.Right);
            }
            TraversePreOrder(root);
        }
        void TraversePostOrder(Node root, Action<T> action)
        {
            void TraversePostOrder(Node parent)
            {
                if (parent is null) return;
                if (parent.Left != null) TraversePostOrder(parent.Left);
                if (parent.Right != null) TraversePostOrder(parent.Right);
                action(parent.Data);
            }
            TraversePostOrder(root);
        }
    }
}
