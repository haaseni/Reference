using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            Random r = new Random(DateTime.Now.Millisecond);
            string trace = string.Empty; 

            for (int i = 0; i < 5;i++)
            {
                int randomInt = r.Next(1, 500);
                tree.Insert(randomInt);
                trace += randomInt + " ";
            }

            Console.WriteLine("Max: " + tree.FindMax());
            Console.WriteLine("Min: " + tree.FindMin());
            Console.WriteLine("Trace: " + trace);
            Console.WriteLine("Tree: " + tree);
            Console.ReadLine();
        }
    }

    public class Node<T>
    {        
        public T Value;
        public Node<T> Left;
        public Node<T> Right;
                
        public Node(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string nodeString = "\n{[" + Value + "]";

            if (Left == null && Right == null)
            {
                nodeString += " (leaf)";
            }

            if (Left != null)
            {
                nodeString += "        Left: " + Left.ToString();
            }
            
            if (Right != null)
            {
                nodeString += "                Right: " + Right.ToString();
            }            
            nodeString += "}";

            return nodeString;
        }       
    }

    public class BinarySearchTree<T>
    {
        public Node<T> Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
        }



        public void MakeEmpty()
        {
            Root = null;
        }

        public bool IsEmpty()
        {
            return Root == null;
        }

        private T ValueAt(Node<T> node)
        {
            return node == null ? default(T) : node.Value;
        }

        public void Insert(T value)
        {
            Root = Insert(value, Root);
        }

        protected Node<T> Insert(T value, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(value);
            }
            else if ((value as IComparable).CompareTo(node.Value) < 0)
            {
                node.Left = Insert(value, node.Left);
            }
            else if ((value as IComparable).CompareTo(node.Value) > 0)
            {
                node.Right = Insert(value, node.Right);
            }
            else
            {
                throw new Exception("Duplicate Item");
            }

            return node;
        }

        public void Remove(T value)
        {
            Root = Remove(value, Root);
        }

        public Node<T> Remove(T value, Node<T> node)
        {
            if (value == null)
            {
                throw new Exception("Item Not Found");
            }
            else if ((value as IComparable).CompareTo(node.Value) < 0)
            {
                node.Left = Remove(value, node.Left);
            }
            else if ((value as IComparable).CompareTo(node.Value) < 0)
            {
                node.Right = Remove(value, node.Right);
            }
            else if (node.Left != null && node.Right != null)
            {
                node.Value = FindMin(node.Right).Value;
                node.Right = RemoveMin(node.Right);
            }
            else
            {
                node = (node.Left != null) ? node.Left : node.Right;
            }

            return node;
        }

        public void RemoveMin()
        {
            Root = RemoveMin(Root);
        }

        public Node<T> RemoveMin(Node<T> node)
        {
            if (node == null)
            {
                throw new Exception("Item Not Found");
            }
            else if (node.Left != null)
            {
                node.Left = RemoveMin(node.Left);
                return node;
            }
            else
            {
                return node.Right;
            }
        }

        public T Find(T value)
        {
            return ValueAt(Find(value, Root));
        }

        public Node<T> Find(T value, Node<T> node)
        {
            while (node != null)
            {
                if ((value as IComparable).CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else if ((value as IComparable).CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    return node;
                }
            }

            return null;
        }

        public T FindMin()
        {
            return ValueAt(FindMin(Root));
        }

        public Node<T> FindMin(Node<T> node)
        {
            if (node != null)
            {
                while (node.Left != null)
                {
                    node = node.Left;
                }
            }

            return node;
        }

        public T FindMax()
        {
            return ValueAt(FindMax(Root));
        }

        public Node<T> FindMax(Node<T> node)
        {
            if (node != null)
            {
                while (node.Right != null)
                {
                    node = node.Right;
                }
            }

            return node;
        }

        public override string ToString()
        {
            return Root.ToString();
        }
    }
}
