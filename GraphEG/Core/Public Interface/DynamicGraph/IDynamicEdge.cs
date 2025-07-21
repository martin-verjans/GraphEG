using GraphEG.Core.Graph;
using System;

namespace GraphEG.Core.DynamicGraph
{
    public interface IDynamicEdge<TNode> : IEdge<INode>, ICloneable where TNode : INode
    {
        new TNode Origin { get; }
        new TNode Destination { get; }
    }

    public interface IDynamicEdge<TOrigin, TDestination> : IDynamicEdge<INode>
        where TOrigin : INode
        where TDestination : INode
    {
        new TOrigin Origin { get; }
        new TDestination Destination { get; }
    }
}
