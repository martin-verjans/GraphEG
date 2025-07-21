using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.Graph
{
    [Serializable]
    public class GraphItemSet<T> : IGraphItemSet<T> where T : IGraphItem
    {
        protected List<T> Items { get; }
        internal protected GraphItemSet()
        {
            Items = new List<T>();
        }
        internal protected GraphItemSet(IEnumerable<T> items)
        {
            //Items = new List<T>(items);
            //Items = items.ToList();
            Items = new List<T>();
            foreach (T item in items)
            {
                Items.Add(item);
            }
        }

        public override int GetHashCode()
        {
            return Items.Count;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return obj is GraphItemSet<T> set ? this.SequenceEqual(set) : base.Equals(obj);
        }

        public static bool operator ==(GraphItemSet<T> lhs, GraphItemSet<T> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(GraphItemSet<T> lhs, GraphItemSet<T> rhs)
        {
            return !lhs.Equals(rhs);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
