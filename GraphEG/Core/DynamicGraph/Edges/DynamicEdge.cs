using GraphEG.Core.Graph;
using System;

namespace GraphEG.Core.DynamicGraph
{
    [Serializable]
    public abstract class DynamicEdge<TOrigin, TDestination> : Edge<INode>, IDynamicEdge<TOrigin, TDestination>
        where TOrigin : INode
        where TDestination : INode
    {
        public DynamicEdge(string label, string name, INode origin, INode destination) : base(label, name, origin, destination)
        {
        }

        public new TOrigin Origin => (TOrigin)base.Origin;

        public new TDestination Destination => (TDestination)base.Destination;

        public abstract object Clone();
    }
}
