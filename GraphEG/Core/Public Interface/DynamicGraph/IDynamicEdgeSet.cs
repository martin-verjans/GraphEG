using GraphEG.Core.Graph;
using System;

namespace GraphEG.Core.DynamicGraph
{

    public interface IDynamicEdgeSet<TEdge> : IEdgeSet<TEdge>, ICloneable
    where TEdge : IDynamicEdge<INode>
    { }
}
