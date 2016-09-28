using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Test
{
    [TestClass]
    public class AvlBstTest
    {
        [TestMethod]
        public void Insert_RootNode_Ok()
        {
            var tree = Get12345Tree();
            Assert.AreEqual(new Node<int>(3), tree.RootNode);
        }

        [TestMethod]
        public void Insert_Balance_0()
        {
            var tree = Get12345Tree();
            Assert.AreEqual(0, tree.RootNode.Balance);
        }

        [TestMethod]
        public void Insert_Height_Ok()
        {
            var tree = Get12345Tree();
            Assert.AreEqual(3, tree.RootNode.Height);
        }

        [TestMethod]
        public void Insert_InorderTraversal_Sorted_Order()
        {
            var tree = Get12345Tree();

            StringBuilder sb = new StringBuilder();
            tree.InorderTraversal(n => { sb.Append(n.Value.ToString()); });

            Assert.AreEqual("12345", sb.ToString());
        }

        private AvlBst<int> Get12345Tree()
        {
            AvlBst<int> tree = new AvlBst<int>();
            tree.Insert(new Node<int>(1));
            tree.Insert(new Node<int>(2));
            tree.Insert(new Node<int>(3));
            tree.Insert(new Node<int>(4));
            tree.Insert(new Node<int>(5));

            return tree;
        }
    }
}