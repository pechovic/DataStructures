using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Test
{
    [TestClass]
    public class EmptyNodeTest
    {

        [TestMethod]
        public void Add_Returns_The_Same()
        {
            var node = new EmptyNode<int>();

            var nodeToInsert = new AvlTreeNode<int>(6);
            var actual = node.Add(nodeToInsert);

            Assert.AreEqual(nodeToInsert, actual);
        }
    }
}
