using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Test
{
    [TestClass]
    public class AvlTreeNodeTest
    {
        [TestMethod]
        public void Node_Less_Then_Test()
        {
            var node1 = new AvlTreeNode<int>(7);
            var node2 = new AvlTreeNode<int>(8);
            var node3 = new AvlTreeNode<int>(8);

            Assert.IsTrue(node1 < node2);
            Assert.IsFalse(node2 < node1);
            Assert.IsFalse(node2 < node3);
            Assert.IsFalse(node3 < node2);
        }

        [TestMethod]
        public void Node_Greater_Then_Test()
        {
            var node1 = new AvlTreeNode<int>(7);
            var node2 = new AvlTreeNode<int>(8);
            var node3 = new AvlTreeNode<int>(8);

            Assert.IsFalse(node1 > node2);
            Assert.IsTrue(node2 > node1);
            Assert.IsFalse(node2 > node3);
            Assert.IsFalse(node3 > node2);
        }

        [TestMethod]
        public void Node_Equal_Test()
        {
            var node1 = new AvlTreeNode<int>(7);
            var node2 = new AvlTreeNode<int>(8);
            var node3 = new AvlTreeNode<int>(8);

            Assert.IsFalse(node1 == node2);
            Assert.IsFalse(node2 == node1);
            Assert.IsTrue(node2 == node3);
            Assert.IsTrue(node3 == node2);
        }

        [TestMethod]
        public void Node_NotEqual_Test()
        {
            var node1 = new AvlTreeNode<int>(7);
            var node2 = new AvlTreeNode<int>(8);
            var node3 = new AvlTreeNode<int>(8);

            Assert.IsTrue(node1 != node2);
            Assert.IsTrue(node2 != node1);
            Assert.IsFalse(node2 != node3);
            Assert.IsFalse(node3 != node2);
        }

        [TestMethod]
        public void Add_RootNode_Ok()
        {
            var node = new AvlTreeNode<int>(1);
            node.Add(new AvlTreeNode<int>(2));

            Assert.AreEqual(new AvlTreeNode<int>(1), node.GetRoot());
            Assert.AreEqual(1, node.GetRoot().Height);
        }

        [TestMethod]
        public void Insert_Balance_0()
        {
            var rootNode = Get12345Tree();
            Assert.AreEqual(TreeState.Balanced, rootNode.State);
        }

        [TestMethod]
        public void Insert_Height_Ok()
        {
            var rootNode = Get12345Tree();
            Assert.AreEqual(2, rootNode.Height);
        }
        
        [TestMethod]
        public void RightRotation_Ok()
        {
            // on the following tree the right rotation will be performed
            var node = new AvlTreeNode<int>(5);
            node.Add(new AvlTreeNode<int>(4));
            node.Add(new AvlTreeNode<int>(3));
            
            Assert.AreEqual(new AvlTreeNode<int>(4), node.GetRoot());
            Assert.AreEqual(new AvlTreeNode<int>(3), node.GetRoot().LeftNode);
            Assert.AreEqual(new AvlTreeNode<int>(5), node.GetRoot().RightNode);
            Assert.AreEqual(1, node.GetRoot().Height);
        }

        [TestMethod]
        public void LeftRotation_Ok()
        {
            // on the following tree the right rotation will be performed
            var node = new AvlTreeNode<int>(1);
            node.Add(new AvlTreeNode<int>(2));
            node.Add(new AvlTreeNode<int>(3));

            Assert.AreEqual(new AvlTreeNode<int>(2), node.GetRoot());
            Assert.AreEqual(new AvlTreeNode<int>(1), node.GetRoot().LeftNode);
            Assert.AreEqual(new AvlTreeNode<int>(3), node.GetRoot().RightNode);
            Assert.AreEqual(1, node.GetRoot().Height);
        }

        [TestMethod]
        public void Add_Balance_Height_Find_Ok()
        {
            var rootNode = GetBigTree();
            
            Assert.AreEqual(9, rootNode.Height);
            Assert.IsNotNull(rootNode.Find(9));
            Assert.IsNotNull(rootNode.Find(998));
            Assert.IsNotNull(rootNode.Find(345));
            Assert.IsNotNull(rootNode.Find(789));
        }

        [TestMethod]
        public void RightLeftRotation_Ok()
        {
            var node = new AvlTreeNode<int>(3);
            node.GetRoot().Add(new AvlTreeNode<int>(1));
            node.GetRoot().Add(new AvlTreeNode<int>(2));

            Assert.AreEqual(new AvlTreeNode<int>(2), node.GetRoot());
            Assert.AreEqual(new AvlTreeNode<int>(1), node.GetRoot().LeftNode);
            Assert.AreEqual(new AvlTreeNode<int>(3), node.GetRoot().RightNode);
            Assert.AreEqual(1, node.GetRoot().Height);
        }

        private AvlTreeNode<int> Get12345Tree()
        {
            var tree = new AvlTreeNode<int>(1);
            tree.GetRoot().Add(new AvlTreeNode<int>(2));
            tree.GetRoot().Add(new AvlTreeNode<int>(3));
            tree.GetRoot().Add(new AvlTreeNode<int>(4));
            tree.GetRoot().Add(new AvlTreeNode<int>(5));

            return tree.GetRoot();
        }

        private AvlTreeNode<int> GetBigTree()
        {
            var tree = new AvlTreeNode<int>(1);
            for (int i = 2; i < 1000; i++)
            {
                tree.GetRoot().Add(new AvlTreeNode<int>(i));
            }

            return tree.GetRoot();
        }
    }
}
