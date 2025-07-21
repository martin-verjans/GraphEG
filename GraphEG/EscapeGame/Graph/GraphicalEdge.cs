using GraphEG.Core.Graph;

namespace GraphEG.EscapeGame.Graph
{
    public class GraphicalEdge : QuikGraph.IEdge<INode>
    {
        public INode Source => Edge.Origin;

        public INode Target => Edge.Destination;

        public IEdge<INode> Edge { get; }


        public GraphicalEdge(IEdge<INode> edge)
        {
            Edge = edge;
        }
    }
}
