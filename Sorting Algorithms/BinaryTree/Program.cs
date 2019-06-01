using System;

namespace BinaryTree
{
    class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public TNode Value
        {
            get;
            private set;
        }

        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }

        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }


        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }

        public int CompareNode(BinaryTreeNode<TNode> other)
        {
            return Value.CompareTo(other.Value);
        }

    }
       
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeNode<int> Node1 = new BinaryTreeNode<int>(5);
            BinaryTreeNode<int> Node2 = new BinaryTreeNode<int>(8);
            BinaryTreeNode<int> Node3 = new BinaryTreeNode<int>(3);

            if (Node1.CompareNode(Node2) >= 0)
            {
                Node1.Left = Node2;
            }
            else
            {
                Node1.Right = Node2;
            }

            if (Node1.CompareNode(Node3) >= 0)
            {
                Node1.Left = Node3;
            }
            else
            {
                Node1.Right = Node3;
            }
            Console.WriteLine("левый потомок узла 5: "+ Node1.Left.Value);
            Console.WriteLine("правый потомок узла 5: " + Node1.Right.Value);
        }
    }
}
