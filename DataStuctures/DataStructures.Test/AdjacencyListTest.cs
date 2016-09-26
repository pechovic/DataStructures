using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Test
{
    [TestClass]
    public class AdjacencyListTest
    {
        [TestMethod]
        public void Add_Test_Ok()
        {
            AdjacencyList<int, string> adjList = new AdjacencyList<int, string>();

            adjList.Add(1, "aaa");
            adjList.Add(2, "bbb");
            adjList.Add(1, "ccc");

            Assert.AreEqual("aaaccc", string.Join("", adjList[1]));
            Assert.AreEqual("bbb", string.Join("", adjList[2]));
        }
    }
}
