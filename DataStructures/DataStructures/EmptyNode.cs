using System;

namespace DataStructures
{
    public class EmptyNode<T> : Node<T> where T : IComparable<T>
    {
        public override int Balance
        {
            get
            {
                return 0;
            }
        }

        public override int Height
        {
            get
            {
                return -1;
            }
        }
        
        public override T Value
        {
            get
            {
                return default(T);
            }
        }
    }
}
