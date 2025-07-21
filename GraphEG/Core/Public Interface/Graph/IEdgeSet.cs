namespace GraphEG.Core.Graph
{
    public interface IEdgeSet<T> : IGraphItemSet<T> where T : IEdge<INode> { }
}
