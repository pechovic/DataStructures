using System;

namespace DataStructures
{
    public class Heap<T> where T : IComparable<T>
    {
        private readonly HeapType _heapType;
        private readonly T[] _heap;
        private int _count;

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public Heap(HeapType heapType, ulong heapSize)
        {
            _heapType = heapType;
            _heap = new T[heapSize];
            _count = 0;
        }

        #region Public Methods

        public void Insert(T value)
        {
            Func<T, T, bool> comparison = _heapType == HeapType.Max ? (Func<T, T, bool>)MaxHeapCompare : MinHeapCompare;
    
            _heap[_count] = value;
            int i = _count;
            int parentIndex;
            while ((parentIndex = ((i - 1) / 2)) > -1 && comparison(_heap[parentIndex], _heap[i]))
            {
                T tmp = _heap[i];
                _heap[i] = _heap[parentIndex];
                _heap[parentIndex] = tmp;
                i = parentIndex;
            }

            _count++;
        }

        public T RemoveRoot()
        {
            Func<T, T, bool> comparison = _heapType == HeapType.Max ? (Func<T, T, bool>)MaxHeapCompare : MinHeapCompare;

            T removed = _heap[0];

            int lastIndex = _count - 1;
            _heap[0] = _heap[lastIndex];
            lastIndex--; // one element was removed

            int wrong = 0;
            int childIndex;
            while (
                    (childIndex = (2 * wrong + 1)) <= lastIndex &&
                    (comparison(_heap[wrong], _heap[childIndex]) || comparison(_heap[wrong], _heap[childIndex + 1]))
                  )
            {
                int swapIndex = comparison(_heap[childIndex], _heap[childIndex + 1])
                    ? childIndex + 1 : childIndex;

                T tmp = _heap[wrong];
                _heap[wrong] = _heap[swapIndex];
                _heap[swapIndex] = tmp;

                wrong = swapIndex;
            }

            _count--;
            return removed;
        }

        public T[] ToArray()
        {
            T[] result = new T[_count];
            for (int i = 0; i < _count; i++)
                result[i] = _heap[i];
            return result;
        }

        public T GetRoot()
        {
            return _heap[0];
        }

        #endregion

        #region Private Methods

        private bool MaxHeapCompare(T x, T y)
        {
            return x.CompareTo(y) < 0;
        }

        private bool MinHeapCompare(T x, T y)
        {
            return x.CompareTo(y) > 0;
        }

        #endregion
    }

    public enum HeapType
    {
        Max,
        Min
    }
}
