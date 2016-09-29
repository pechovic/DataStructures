using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public abstract class Node<T>
        where T : IComparable<T>
    {
        public abstract T Value { get; protected set; }

        public abstract Node<T> LeftNode { get; internal set; }

        public abstract Node<T> RightNode { get; internal set; }

        public abstract Node<T> Parent { get; internal set; }

        /// <summary>
        /// Classic hight of the node.
        /// </summary>
        public virtual int Height
        {
            get
            {
                return Math.Max(
                        LeftNode.Height,
                        RightNode.Height
                    ) + 1;
            }
        }

        public abstract int BalanceFactor { get; }

        public Node()
        {
        }

        public Node(T value)
        {
            Value = value;
        }

        public Node<T> GetRoot()
        {
            if (Parent == null)
            {
                return this;
            }

            return Parent.GetRoot();
        }

        #region Traversal
        
        public virtual void InOrderTraversal(Action<Node<T>> actionOnNode)
        {
            LeftNode.InOrderTraversal(actionOnNode);
            actionOnNode(this);
            RightNode.InOrderTraversal(actionOnNode);
        }

        public virtual void PreOrderTraversal(Action<Node<T>> actionOnNode)
        {
            actionOnNode(this);
            LeftNode.InOrderTraversal(actionOnNode);
            RightNode.InOrderTraversal(actionOnNode);
        }

        public virtual void PostOrderTraversal(Action<Node<T>> actionOnNode)
        {
            LeftNode.InOrderTraversal(actionOnNode);
            RightNode.InOrderTraversal(actionOnNode);
            actionOnNode(this);
        }

        #endregion

        #region Add/Delete

        public abstract Node<T> Add(Node<T> node);

        public abstract void Remove();

        #endregion

        #region Equality

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

        #endregion
    }
}
