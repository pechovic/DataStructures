using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// AVL Binary Search Tree
    /// </summary>
    public class AvlBst<T> where T : IComparable<T>
    {
        private Node<T> _rootNode;

        public Node<T> RootNode {  get { return _rootNode; } }
        
        public AvlBst()
        {
            _rootNode = new EmptyNode<T>();
        }

        #region Insert

        public void Insert(Node<T> node)
        {
            Insert(ref _rootNode, node);
        }

        private void Insert(ref Node<T> current, Node<T> node)
        {
            if (current is EmptyNode<T>)
            {
                current = node;
                current.LeftNode = new EmptyNode<T>();
                current.RightNode = new EmptyNode<T>();
                return;
            }

            // go right or left depends on the weight
            if (current < node)
            {
                Insert(ref current.RightNode, node);
            }
            else
            {
                Insert(ref current.LeftNode, node);
            }
        }

        #endregion

        #region InorderTraversal

        public void InorderTraversal()
        {
            // no action performed on node during the traversal
            InorderTraversal(n => { });
        }

        public void InorderTraversal(Action<Node<T>> actionOnNode)
        {
            InorderTraversalInternal(RootNode, actionOnNode);
        }

        private void InorderTraversalInternal(Node<T> node, Action<Node<T>> actionOnNode)
        {
            if (node is EmptyNode<T>)
            {
                return;
            }

            InorderTraversalInternal(node.LeftNode, actionOnNode);
            actionOnNode(node);
            InorderTraversalInternal(node.RightNode, actionOnNode);
        }

        #endregion
    }
}