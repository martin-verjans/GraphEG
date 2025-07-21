using GraphEG.Core.DynamicGraph;
using GraphEG.Core.Graph;

namespace GraphEG.EscapeGame.Graph
{
    public class GraphicalEdgeDynamic : QuikGraph.IEdge<INode>
    {
        public INode Source => Edge.Origin;

        public INode Target => Edge.Destination;

        public IDynamicEdge<INode> Edge { get; }


        public GraphicalEdgeDynamic(IDynamicEdge<INode> edge)
        {
            Edge = edge;
        }
    }
}
