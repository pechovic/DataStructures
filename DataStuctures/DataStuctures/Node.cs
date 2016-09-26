using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node<T> where T : IComparable<T>
    {
        private readonly T _value;
        public T Value
        {
            get
            {
                return _value;
            }
        }

        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }

        /// <summary>
        /// Classic hight of the node.
        /// </summary>
        public int Height
        {
            get
            {
                return Math.Max(
                        LeftNode.Height,
                        RightNode.Height
                    ) + 1;
            }
        }

        public int Balance
        {
            get
            {
                return LeftNode.Height - RightNode.Height;
            }
        }

        public Node()
        {
        }

        public Node(T value)
        {
            _value = value;
        }

        public static bool operator <(Node<T> a, Node<T> b)
        {
            return a.Value.CompareTo(b.Value) < 0;
        }

        public static bool operator >(Node<T> a, Node<T> b)
        {
            return a.Value.CompareTo(b.Value) > 0;
        }

        public static bool operator ==(Node<T> a, Node<T> b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Value.CompareTo(b.Value) == 0;
        }

        public static bool operator !=(Node<T> a, Node<T> b)
        {
            return !(a == b);
        }


        /// <summary>
        /// Defining value identity.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Node<T> node = obj as Node<T>;
            if (node == null)
            {
                return false;
            }

            return Equals(node);
        }

        /// <summary>
        /// Defininig value identity
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Equals(Node<T> node)
        {
            if (node == null)
            {
                return false;
            }

            return Value.CompareTo(node.Value) == 0;
        }

        /// <summary>
        /// Identity drived by value. 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
