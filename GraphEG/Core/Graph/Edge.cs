using System;

namespace GraphEG.Core.Graph
{
    [Serializable]
    public class Edge<TNode> : GraphItem, IEdge<TNode>
        where TNode : INode
    {
        public TNode Origin { get; }
        public TNode Destination { get; }

        public string Label { get; }

        internal Edge(string name, TNode origin, TNode destination)
            : this(name, name, origin, destination)
        {
        }

        public Edge(string label, string name, TNode origin, TNode destination)
            :base(name)
        {
            Origin= origin;
            Destination = destination;
            Label = label;
        }

        public override string ToString()
        {
            return $"{Name} - [{Origin.Name}] {Label} [{Destination.Name}]";
        }
    }
}
