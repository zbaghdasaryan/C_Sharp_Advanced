using System;

namespace SinglyList
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }
    class Program
    {
        static public void Print(Node node)
        {
            while (node != null)
            {
                Console.Write(node.Value+ " ");
                node = node.Next;
            }
        }
        static void Main(string[] args)
        {

            Node node1 = new Node()
            {
                Value = 1
            };
            Node node2 = new Node()
            {
                Value = 2
            }; 
            Node node3 = new Node()
            {
                Value = 3
            }; 
            Node node4 = new Node()
            {
                Value = 4
            }; 
            Node node5 = new Node()
            {
                Value = 5
            }; 

           
            node1.Next = node2;
           
            node2.Next = node3;
            
            node3.Next = node4;
           
            node4.Next = node5;

            Print(node1);
            Console.ReadKey();
        }
    }
}
