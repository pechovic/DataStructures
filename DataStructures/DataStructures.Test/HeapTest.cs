using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace DataStructures.Test
{
    [TestClass]
    public class HeapTest
    {
        [TestMethod]
        public void Inset_Integers_Ok()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max, HeapSize.VerySmall);

            heap.Insert(40);
            heap.Insert(3);
            heap.Insert(96);
            heap.Insert(11);
            
            Assert.AreEqual("96,11,40,3", string.Join(",", heap.ToArray()));
        }
    }
}
