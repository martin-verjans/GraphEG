namespace GraphEG.Core.Graph
{
    //public interface IEdge : IGraphItem
    //{
    //    INode OriginNode { get; }
    //    INode DestinationNode { get; }
    //}

    public interface IEdge<TNode> : IGraphItem
        where TNode : INode
    {
        TNode Origin { get; }
        TNode Destination { get; }

        string Label { get; }
    }
}
