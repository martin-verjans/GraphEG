using System.Collections.Generic;

namespace GraphEG.Core.Graph
{
    public interface IGraph
    {
        void Init();
        INodeSet<INode> Nodes { get; }
        IEdgeSet<IEdge<INode>> Edges { get; }
        void AddNode(INode node);
        void RemoveNode(INode node);
        void AddEdge(IEdge<INode> edge);
        void RemoveEdge(IEdge<INode> edge);
        IEnumerable<IGraphItem> FindAllConnected(IEnumerable<IGraphItem> items);
        IEnumerable<IGraphItem> FindAllConnected(IGraphItem item);
        IEnumerable<IGraphItem> FindAllConnected(INode node);
        IEnumerable<IGraphItem> FindAllConnected(IEdge<INode> edge);
    }

    public interface IGraph<TNodes, TEdges, TNodeSet, TEdgeSet> : IGraph
        where TNodes : INode
        where TEdges : IEdge<INode>
        where TNodeSet : INodeSet<TNodes>
        where TEdgeSet : IEdgeSet<TEdges>
    {
        new TNodeSet Nodes { get; }
        new TEdgeSet Edges { get; }
    }
}
