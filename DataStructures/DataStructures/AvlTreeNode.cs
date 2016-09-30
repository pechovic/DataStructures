﻿using System;

namespace DataStructures
{
    public class AvlTreeNode<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Indicates when balancing will occur.
        /// </summary>
        private const int _balancingThreshold = 1;

        public virtual int BalanceFactor
        {
            get
            {
                return RightNode.Height - LeftNode.Height;
            }
        }

        public virtual AvlTreeNode<T> Parent { get; internal set; }

        public virtual TreeState State
        {
            get
            {
                if (BalanceFactor > _balancingThreshold)
                {
                    return TreeState.RightHeavy;
                }
                else if ((BalanceFactor * -1) > _balancingThreshold)
                {
                    return TreeState.LeftHeavy;
                }

                return TreeState.Balanced;
            }
        }

        /// <summary>
        /// Identifies whether this node is the root node or not.
        /// </summary>
        public bool IsRootNode
        {
            get
            {
                return Parent == null;
            }
        }

        public T Value { get; protected set; }
        
        private AvlTreeNode<T> _leftNode;
        public AvlTreeNode<T> LeftNode
        {
            get
            {
                if (_leftNode == null)
                {
                    return new EmptyLeaf();
                }

                return _leftNode;
            }
            internal set
            {
                _leftNode = value;
                _leftNode.Parent = this;
            }
        }

        private AvlTreeNode<T> _rightNode;
        public AvlTreeNode<T> RightNode
        {
            get
            {
                if (_rightNode == null)
                {
                    return new EmptyLeaf();
                }

                return _rightNode;
            }
            internal set
            {
                _rightNode = value;
                _rightNode.Parent = this;
            }
        }

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

        public AvlTreeNode()
        {
        }

        public AvlTreeNode(T value)
        {
            Value = value;
        }

        public AvlTreeNode<T> GetRoot()
        {
            if (IsRootNode)
            {
                return this;
            }

            return Parent.GetRoot();
        }
       
        #region Add/Remove/Find

        public void Add(AvlTreeNode<T> node)
        {
            if (this > node)
            {
                if (LeftNode is EmptyLeaf)
                {
                    LeftNode = node;
                    Balance();
                    return;
                }

                LeftNode.Add(node);
            }
            else
            {
                if (RightNode is EmptyLeaf)
                {
                    RightNode = node;
                    Balance();
                    return;
                }

                RightNode.Add(node);
            }
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public AvlTreeNode<T> Find(T value)
        {
            if (this is EmptyLeaf)
            {
                return null;
            }

            if (Value.CompareTo(value) == 0)
            {
                return this;
            }

            if (Value.CompareTo(value) > 0)
            {
                return LeftNode.Find(value);
            }

            return RightNode.Find(value);
        }

        #endregion

        #region Balancing

        /// <summary>
        /// Decide what rotation to take on this tree and perform.
        /// </summary>
        public void Balance()
        {
            if (State == TreeState.RightHeavy)
            {
                if (RightNode.BalanceFactor < 0)
                {
                    LeftRightRotation();
                }
                else
                {
                    LeftRotation();
                }
            }
            else if (State == TreeState.LeftHeavy)
            {
                if (LeftNode.BalanceFactor > 0)
                {
                    RightLeftRotation();
                }
                else
                {
                    RightRotation();
                }
            }

            if (!IsRootNode)
            {
                Parent.Balance();
            }
        }

        private void LeftRotation()
        {
            var newLocalRoot = RightNode;
            ReplaceRoot(newLocalRoot);
            
            RightNode = newLocalRoot.LeftNode;

            newLocalRoot.LeftNode = this;
        }

        private void RightRotation()
        {
            var newLocalRoot = LeftNode;
            ReplaceRoot(newLocalRoot);
            
            LeftNode = newLocalRoot.RightNode;
            newLocalRoot.RightNode = this;
        }

        private void ReplaceRoot(AvlTreeNode<T> newRoot)
        {
            // if this isn't a root node, it has a parent
            if (!IsRootNode)
            {
                // determine which child of the Parent must be replaced
                if (Parent.LeftNode == this)
                {
                    Parent.LeftNode = newRoot;
                }
                else if (Parent.RightNode == this)
                {
                    Parent.RightNode = newRoot;
                }
                else
                {
                    throw new Exception("A problem with an algorithm?");
                }
            }
            else
            {
                // make it root of the whole tree
                newRoot.Parent = null;
            }
        }


        private void LeftRightRotation()
        {
            RightNode.RightRotation();
            LeftRotation();
        }

        private void RightLeftRotation()
        {
            LeftNode.LeftRotation();
            RightRotation();
        }

        #endregion

        #region Traversal

        public virtual void InOrderTraversal(Action<AvlTreeNode<T>> actionOnNode)
        {
            LeftNode.InOrderTraversal(actionOnNode);
            actionOnNode(this);

            if (RightNode != null)
            {
                RightNode.InOrderTraversal(actionOnNode);
            }
        }

        public virtual void PreOrderTraversal(Action<AvlTreeNode<T>> actionOnNode)
        {
            actionOnNode(this);
            LeftNode.PreOrderTraversal(actionOnNode);
            RightNode.PreOrderTraversal(actionOnNode);
        }

        public virtual void PostOrderTraversal(Action<AvlTreeNode<T>> actionOnNode)
        {
            LeftNode.PostOrderTraversal(actionOnNode);
            RightNode.PostOrderTraversal(actionOnNode);
            actionOnNode(this);
        }

        #endregion

        #region Equality

        public static bool operator <(AvlTreeNode<T> a, AvlTreeNode<T> b)
        {
            return a.Value.CompareTo(b.Value) < 0;
        }

        public static bool operator >(AvlTreeNode<T> a, AvlTreeNode<T> b)
        {
            return a.Value.CompareTo(b.Value) > 0;
        }

        public static bool operator ==(AvlTreeNode<T> a, AvlTreeNode<T> b)
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

        public static bool operator !=(AvlTreeNode<T> a, AvlTreeNode<T> b)
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

            AvlTreeNode<T> node = obj as AvlTreeNode<T>;
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
        public bool Equals(AvlTreeNode<T> node)
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

        public override string ToString()
        {
            return Value.ToString();
        }

        #region EmptyLeaf

        /// <summary>
        /// Null object pattern for simple writing.
        /// </summary>
        private class EmptyLeaf : AvlTreeNode<T>
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

            public override void InOrderTraversal(Action<AvlTreeNode<T>> actionOnNode)
            {
            }

            public override void PreOrderTraversal(Action<AvlTreeNode<T>> actionOnNode)
            {
            }

            public override void PostOrderTraversal(Action<AvlTreeNode<T>> actionOnNode)
            {
            }
        }

        #endregion

    }

    #region TreeState
    public enum TreeState
    {
        Balanced,
        LeftHeavy,
        RightHeavy
    }

    #endregion
}