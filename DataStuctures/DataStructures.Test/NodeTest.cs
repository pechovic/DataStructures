using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Test
{
    [TestClass]
    public class NodeTest
    {

        [TestMethod]
        public void Node_Less_Then_Test()
        {
            Node<int> node1 = new Node<int>(7);
            Node<int> node2 = new Node<int>(8);
            Node<int> node3 = new Node<int>(8);

            Assert.IsTrue(node1 < node2);
            Assert.IsFalse(node2 < node1);
            Assert.IsFalse(node2 < node3);
            Assert.IsFalse(node3 < node2);
        }

        [TestMethod]
        public void Node_Greater_Then_Test()
        {
            Node<int> node1 = new Node<int>(7);
            Node<int> node2 = new Node<int>(8);
            Node<int> node3 = new Node<int>(8);

            Assert.IsFalse(node1 > node2);
            Assert.IsTrue(node2 > node1);
            Assert.IsFalse(node2 > node3);
            Assert.IsFalse(node3 > node2);
        }

        [TestMethod]
        public void Node_Equal_Test()
        {
            Node<int> node1 = new Node<int>(7);
            Node<int> node2 = new Node<int>(8);
            Node<int> node3 = new Node<int>(8);

            Assert.IsFalse(node1 == node2);
            Assert.IsFalse(node2 == node1);
            Assert.IsTrue(node2 == node3);
            Assert.IsTrue(node3 == node2);
        }

        [TestMethod]
        public void Node_NotEqual_Test()
        {
            Node<int> node1 = new Node<int>(7);
            Node<int> node2 = new Node<int>(8);
            Node<int> node3 = new Node<int>(8);

            Assert.IsTrue(node1 != node2);
            Assert.IsTrue(node2 != node1);
            Assert.IsFalse(node2 != node3);
            Assert.IsFalse(node3 != node2);
        }
    }
}
