using Xunit;
using System.Collections.Generic;

namespace DataStructures.Test
{
    public class HeapTest
    {
        [Fact]
        public void Inset_Integers_Ok()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max, 10);

            heap.Insert(40);
            heap.Insert(3);
            heap.Insert(96);
            heap.Insert(11);
            
            Assert.Equal("96,11,40,3", string.Join(",", heap.ToArray()));
        }

        [Fact]
        public void Insert_MinOrder_Ok()
        {
            Heap<int> heap = new Heap<int>(HeapType.Min, 10);

            heap.Insert(4);
            heap.Insert(6);
            heap.Insert(1);
            heap.Insert(89);
            heap.Insert(45);
            heap.Insert(8);
            heap.Insert(2);
            heap.Insert(1);

            Assert.Equal("1,1,2,4,6,8,45,89", string.Join(",", EnumerateHeap(heap)));
        }

        [Fact]
        public void Insert_MaxOrder_Ok()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max, 20);

            heap.Insert(4);
            heap.Insert(6);
            heap.Insert(1);
            heap.Insert(89);
            heap.Insert(45);
            heap.Insert(8);
            heap.Insert(2);
            heap.Insert(1);

            Assert.Equal("89,45,8,6,4,2,1,1", string.Join(",", EnumerateHeap(heap)));
        }

        private IEnumerable<int> EnumerateHeap(Heap<int> heap)
        {
            List<int> result = new List<int>();
            while (heap.Count > 0)
            {
                result.Add(heap.RemoveRoot());
            }

            return result;
        }

    }
}
