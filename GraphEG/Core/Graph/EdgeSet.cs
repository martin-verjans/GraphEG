using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.Graph
{
    [Serializable]
    public class EdgeSet<T> : GraphItemSet<T>, IEdgeSet<T> where T : IEdge<INode>
    {
        public EdgeSet() : base() { }
        public EdgeSet(IEnumerable<T> edges) : base(edges) { }

        public void AddEdge(T edge)
        {
            Items.Add(edge);
        }

        public void RemoveNode(INode removed)
        {
            IEnumerable<T> toRemove = Items.Where(edge => edge.Origin == removed || edge.Destination == removed).ToList();
            foreach (T edge in toRemove)
            {
                Items.Remove(edge);
            }
        }

        public void RemoveEdge(T toRemove)
        {
            Items.Remove(toRemove);
        }
    }
}
