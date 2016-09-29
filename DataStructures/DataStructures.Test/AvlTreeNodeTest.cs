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
            Assert.AreEqual(0, rootNode.BalanceFactor);
        }

        [TestMethod]
        public void Insert_Height_Ok()
        {
            var rootNode = Get12345Tree();
            Assert.AreEqual(2, rootNode.Height);
        }

        [TestMethod]
        public void Add_InOrderTraversal_Sorted_Order()
        {
            var rootNode = Get12345Tree();

            StringBuilder sb = new StringBuilder();
            rootNode.InOrderTraversal(n => { sb.Append(n.Value.ToString()); });

            Assert.AreEqual("12345", sb.ToString());
        }


        private Node<int> Get12345Tree()
        {
            var tree = new AvlTreeNode<int>(1);
            tree.Add(new AvlTreeNode<int>(2));
            tree.Add(new AvlTreeNode<int>(3));
            tree.Add(new AvlTreeNode<int>(4));
            tree.Add(new AvlTreeNode<int>(5));

            return tree.GetRoot();
        }
    }
}
