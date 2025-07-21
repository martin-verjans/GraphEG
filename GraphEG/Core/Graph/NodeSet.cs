using System;
using System.Collections.Generic;

namespace GraphEG.Core.Graph
{
    [Serializable]
    public class NodeSet<T> : GraphItemSet<T>, INodeSet<T> where T : INode
    {
        internal protected NodeSet() : base() { }
        internal protected NodeSet(IEnumerable<T> nodes) : base(nodes) { }

        internal void AddNode(T node)
        {
            Items.Add(node);
        }

        internal void RemoveNode(T node)
        {
            Items.Remove(node);
        }
    }
}
