using GraphEG.Core.Graph;
using QuikGraph;
using QuikGraph.Graphviz;
using QuikGraph.Graphviz.Dot;
using System;
using System.Linq;

namespace GraphEG.EscapeGame.Graph
{
    public class RawGraphDisplay : GraphDisplay
    {
        public RawGraphDisplay(GraphDisplayOptions options) : base(options)
        {
        }

        public override void FormatEdge(object sender, FormatEdgeEventArgs<INode, GraphicalEdge> e)
        {
        }

        public override void FormatVertex(object sender, FormatVertexEventArgs<INode> e)
        {
            GraphvizVertex formatter = e.VertexFormat;
            INode node = e.Vertex;

            formatter.Label = node.Name;
            FormatVetexAccordingToType(formatter, node);
        }

        public override void FormatCluster(object sender, FormatClusterEventArgs<INode, GraphicalEdge> e)
        {

        }

        protected override IEdgeListGraph<INode, GraphicalEdge> InternalRefreshGraph()
        {
            var displayGraph = new BidirectionalGraph<INode, GraphicalEdge>();
            displayGraph.AddVertexRange(Graph.Nodes);
            displayGraph.AddEdgeRange(Graph.Edges.Select(e => new GraphicalEdge(e)));
            return displayGraph;
        }
    }
}
