using GraphEG.Core.Graph;
using System;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class StaticGraphEdge<TOrigin, TDestination> : Edge<IStaticGraphNode>, IStaticGraphEdge<TOrigin, TDestination>
        where TOrigin : IStaticGraphNode
        where TDestination : IStaticGraphNode
    {
        public StaticGraphEdge(string label, string name, IStaticGraphNode origin, IStaticGraphNode destination) 
            : base(label, name, origin, destination)
        {
        }

        INode IEdge<INode>.Origin => Origin;

        new TOrigin Origin => (TOrigin)base.Origin;

        TOrigin IStaticGraphEdge<TOrigin, TDestination>.Origin => Origin;

        INode IEdge<INode>.Destination => Destination;

        new TDestination Destination => (TDestination)base.Destination;

        TDestination IStaticGraphEdge<TOrigin, TDestination>.Destination => Destination;
    }
}
