using System;

namespace DataStructures
{
    public class EmptyNode<T> : Node<T> where T : IComparable<T>
    {
        public override int BalanceFactor
        {
            get
            {
                return 0;
            }
        }

        public override int Height
        {
            get
            {
                return -1;
            }
        }

        public override Node<T> LeftNode
        {
            get
            {
                throw new NotSupportedException();
            }

            internal set
            {
                throw new NotSupportedException();
            }
        }

        public override Node<T> Parent { get; internal set; }

        public override Node<T> RightNode
        {
            get
            {
                throw new NotSupportedException();
            }

            internal set
            {
                throw new NotSupportedException();
            }
        }

        public override T Value
        {
            get
            {
                return default(T);
            }
            protected set
            {
                throw new NotSupportedException();
            }
        }

        public override Node<T> Add(Node<T> node)
        {
            return node;
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }

        public override void InOrderTraversal(Action<Node<T>> actionOnNode)
        {
            // do nothing for empty node
        }

        public override void PreOrderTraversal(Action<Node<T>> actionOnNode)
        {
            // do nothing for empty node
        }

        public override void PostOrderTraversal(Action<Node<T>> actionOnNode)
        {
            // do nothing for empty node
        }
    }
}
