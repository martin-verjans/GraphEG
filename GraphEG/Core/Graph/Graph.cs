using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.Graph
{
    [Serializable]
    public class Graph : IGraph
    {
        private readonly NodeSet<INode> nodes;
        private readonly EdgeSet<IEdge<INode>> edges;
        public INodeSet<INode> Nodes => nodes;
        public IEdgeSet<IEdge<INode>> Edges => edges;

        public NameGenerator NameGenerator { get; }

        public Graph(NodeSet<INode> nodes) : this(new NodeSet<INode>(), new EdgeSet<IEdge<INode>>()) { }

        protected Graph(NodeSet<INode> nodes, EdgeSet<IEdge<INode>> edges)
        {
            NameGenerator = new NameGenerator();
            this.nodes = nodes;
            this.edges = edges;
        }

        public void Init()
        {
            NameGenerator.Instance = NameGenerator;
        }

        public void AddNode(INode node)
        {
            nodes.AddNode(node);
        }

        public void AddEdge(IEdge<INode> edge)
        {
            edges.AddEdge(edge);
        }

        public void RemoveNode(INode node)
        {
            nodes.RemoveNode(node);
            edges.RemoveNode(node);
        }

        public void RemoveEdge(IEdge<INode> edge)
        {
            edges.RemoveEdge(edge);
        }

        public IEnumerable<IGraphItem> FindAllConnected(IEnumerable<IGraphItem> items)
        {
            IEnumerable<IGraphItem> result = new List<IGraphItem>(items);
            foreach (IGraphItem item in items)
            {
                result = result.Concat(FindAllConnected(item));
            }
            return result.Distinct();
        }

        public IEnumerable<IGraphItem> FindAllConnected(IGraphItem item)
        {
            if (item is INode node)
            {
                return FindAllConnected(node);
            }
            return FindAllConnected((IEdge<INode>)item);
        }

        public IEnumerable<IGraphItem> FindAllConnected(INode node)
        {
            IEnumerable<IGraphItem> result = Edges
                .Where(e => e.Origin.Equals(node) || e.Destination.Equals(node));
            result = result.Concat(Edges.Where(e => e.Origin.Equals(node)).Select(e => e.Destination));
            result = result.Concat(Edges.Where(e => e.Destination.Equals(node)).Select(e => e.Origin));
            result = result.Append(node);
            return result;
        }

        public IEnumerable<IGraphItem> FindAllConnected(IEdge<INode> edge)
        {
            return new List<IGraphItem>() { edge, edge.Origin, edge.Destination };
        }
    }
}
