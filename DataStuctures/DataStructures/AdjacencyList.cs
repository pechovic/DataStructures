using System.Collections.Generic;

namespace DataStructures
{
    public class AdjacencyList<TKey, TValue> : Dictionary<TKey, List<TValue>>
    {
        public void Add(TKey key, TValue value)
        {
            if (base.ContainsKey(key))
                base[key].Add(value);
            else
                base.Add(key, new List<TValue> { value });
        }
    }
}
