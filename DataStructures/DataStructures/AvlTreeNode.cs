using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class AvlTreeNode<T> : Node<T>
        where T : IComparable<T>
    {
        
        public override T Value { get; protected set; }

        private Node<T> _leftNode;
        public override Node<T> LeftNode
        {
            get
            {
                return _leftNode;
            }
            internal set
            {
                _leftNode = value;
                _leftNode.Parent = this;
            }
        }

        private Node<T> _rightNode;
        public override Node<T> RightNode
        {
            get
            {
                return _rightNode;
            }
            internal set
            {
                _rightNode = value;
                _rightNode.Parent = this;
            }
        }

        public override Node<T> Parent { get; internal set; }

        /// <summary>
        /// Classic hight of the node.
        /// </summary>
        public override int Height
        {
            get
            {
                return Math.Max(
                        LeftNode.Height,
                        RightNode.Height
                    ) + 1;
            }
        }

        public override int BalanceFactor
        {
            get
            {
                return LeftNode.Height - RightNode.Height;
            }
        }

        public AvlTreeNode()
        {
            InitializeChildNodes();
        }

        public AvlTreeNode(T value)
        {
            Value = value;
            InitializeChildNodes();
        }

        private void InitializeChildNodes()
        {
            LeftNode = new EmptyNode<T>();
            RightNode = new EmptyNode<T>();
        }

        #region Insert/Delete

        public override Node<T> Add(Node<T> node)
        {
            if (this > node)
            {
                LeftNode = LeftNode.Add(node);
            }
            else
            {
                RightNode = RightNode.Add(node);
            }

            return this;
        }

        public override void Remove()
        {

        }

        #endregion
    }
}
