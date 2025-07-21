using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.DynamicGraph
{
    [Serializable]
    public class DynamicEdgeSet : EdgeSet<IEdge<INode>>, IEquatable<DynamicEdgeSet>, IDynamicEdgeSet<IDynamicEdge<INode>>
    {
        public DynamicEdgeSet() : base()
        {

        }

        public DynamicEdgeSet(IEnumerable<IEdge<INode>> edges)
            : base(edges)
        {

        }

        public DynamicEdgeSet(IEnumerable<IDynamicEdge<INode>> edges)
            : base(edges)
        {

        }

        public object Clone()
        {
            return new DynamicEdgeSet(((IDynamicEdgeSet<IDynamicEdge<INode>>)this).Select(e => (IDynamicEdge<INode>)e.Clone()));
        }

        public bool Equals(DynamicEdgeSet other)
        {
            return Items.SequenceEqual(other.Items);
        }

        public new IEnumerator<IDynamicEdge<INode>> GetEnumerator()
        {
            return Items.Cast<IDynamicEdge<INode>>().GetEnumerator();
        }
    }
}
