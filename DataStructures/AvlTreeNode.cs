using System;

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
                    return EmptyLeaf.Instance;
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
                    return EmptyLeaf.Instance;
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
            // add only on root node
            GetRoot().AddInternal(node);
        }

        private void AddInternal(AvlTreeNode<T> node)
        {
            if (Value.CompareTo(node.Value) > 0)
            {
                if (LeftNode is EmptyLeaf)
                {
                    LeftNode = node;
                    Balance();
                    return;
                }

                LeftNode.AddInternal(node);
            }
            else
            {
                if (RightNode is EmptyLeaf)
                {
                    RightNode = node;
                    Balance();
                    return;
                }

                RightNode.AddInternal(node);
            }
        }

        public void Remove(AvlTreeNode<T> node)
        {
            GetRoot().RemoveInternal(node);
        }

        private void RemoveInternal(AvlTreeNode<T> node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns EmptyLeaf if the item was not found.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public AvlTreeNode<T> Find(T value)
        {
            if (this is EmptyLeaf)
            {
                return EmptyLeaf.Instance;
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
        
        #region EmptyLeaf

        /// <summary>
        /// Null object pattern for simple writing.
        /// </summary>
        public class EmptyLeaf : AvlTreeNode<T>
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

            private static EmptyLeaf _instance = new EmptyLeaf();
            public static EmptyLeaf Instance
            {
                get
                {
                    return _instance;
                }
            }

            private EmptyLeaf()
            {
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
