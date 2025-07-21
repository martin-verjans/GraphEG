using GraphEG.Core.DynamicGraph;
using GraphEG.Core.Graph;
using GraphEG.Core.StaticGraph;
using GraphEG.EscapeGame.Graph.Formatting;
using QuikGraph;
using QuikGraph.Graphviz;
using QuikGraph.Graphviz.Dot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GraphEG.EscapeGame.Graph
{
    public class GraphDisplay
    {
        public GraphDisplayOptions Options { get; }
        public Image LastGeneratedImage { get; protected set; }
        public IGraph Graph { get; private set; }

        public GraphDisplay(GraphDisplayOptions options)
        {
            Options = options;
        }

        public virtual void FormatVertex(object sender, FormatVertexEventArgs<INode> e)
        {
            GraphvizVertex formatter = e.VertexFormat;
            INode node = e.Vertex;

            formatter.Label = node.Name;
            FormatVetexAccordingToType(formatter, node);

            if (node is IRoom)
            {
                formatter.Style = GraphvizVertexStyle.Invis;
                return;
            }
            if (node is IMeta m)
            {
                formatter.Label = $"{m.MetaFunction.FunctionName}";
            }
        }

        public virtual void FormatEdge(object sender, FormatEdgeEventArgs<INode, GraphicalEdge> e)
        {
            GraphicalEdge edge = e.Edge;
            GraphvizEdge formatter = e.EdgeFormat;
            if (edge.Target is IRoom || edge.Source is IRoom)
            {
                formatter.Style = GraphvizEdgeStyle.Invis;
                return;
            }
        }

        public virtual void FormatCluster(object sender, FormatClusterEventArgs<INode, GraphicalEdge> e)
        {
            var cluster = e.Cluster;
            var formatter = e.GraphFormat;
            Room r = cluster.Vertices.OfType<Room>().First();
            formatter.Label = r.Name;
            formatter.LabelJustification = GraphvizLabelJustification.L;
            formatter.LabelLocation = GraphvizLabelLocation.T;
            formatter.Name = r.Name;
            if (Options.UseColors)
            {
                NodeFormatting nodeFormat = Options.NodeFormattingOptions[typeof(IRoom)];
                formatter.FontColor = nodeFormat.Color;
            }
        }

        public void RefreshGraph(IGraph graph)
        {
            Graph = graph;
            IEdgeListGraph<INode, GraphicalEdge> displayGraph = InternalRefreshGraph();
            InternalDrawGraph(displayGraph);
        }

        protected void FormatVetexAccordingToType(GraphvizVertex vertexFormat, INode node)
        {
            NodeFormatting format = Options.GetFormattingOptions(node);
            if (format != null)
                FormatVetexAccordingToType(vertexFormat, format);
        }

        protected void FormatVetexAccordingToType(GraphvizVertex vertexFormat, NodeFormatting formatting)
        {
            vertexFormat.Style = formatting.Style;
            if (Options.UseShapes)
                vertexFormat.Shape = formatting.Shape;
            if (Options.UseColors)
                vertexFormat.StrokeColor = formatting.Color;
        }

        protected internal void InternalDrawGraph(IEdgeListGraph<INode, GraphicalEdge> displayGraph)
        {
            GraphvizAlgorithm<INode, GraphicalEdge> graphViz = new GraphvizAlgorithm<INode, GraphicalEdge>(displayGraph);
            graphViz.FormatVertex += FormatVertex;
            graphViz.FormatEdge += FormatEdge;
            graphViz.FormatCluster += FormatCluster;
            graphViz.GraphFormat.Ratio = GraphvizRatioMode.Compress;
            graphViz.GraphFormat.RankDirection = GraphvizRankDirection.LR;
            graphViz.GraphFormat.PageDirection = GraphvizPageDirection.LT;
            string output = graphViz.Generate(new FileDotEngine(), "graph");

            //"using" to release the handle on the picture
            using (Bitmap bmpTemp = new Bitmap("graph.png"))
            {
                LastGeneratedImage = new Bitmap(bmpTemp);
            }
        }

        protected virtual IEdgeListGraph<INode, GraphicalEdge> InternalRefreshGraph()
        {
            ClusteredAdjacencyGraph<INode, GraphicalEdge> displayGraph = new ClusteredAdjacencyGraph<INode, GraphicalEdge>(new AdjacencyGraph<INode, GraphicalEdge>());
            displayGraph.AddVertexRange(Graph.Nodes);
            displayGraph.AddEdgeRange(Graph.Edges.Select(e => new GraphicalEdge(e)));

            foreach (Room room in Graph.Nodes.OfType<Room>())
            {
                IEnumerable<INode> nodes = Graph.FindAllConnected(room)
                    .OfType<INode>()
                    .Where(n => IsNodeInsideRoom(n, room));
                ClusteredAdjacencyGraph<INode, GraphicalEdge> cluster = displayGraph.AddCluster();
                cluster.AddVertex(room);
                cluster.AddVertexRange(nodes);
            }

            return displayGraph;
        }

        private bool IsNodeInsideRoom(INode node, IRoom room)
        {
            if (node is IClue || node is IRole || node is IPlayer)
                return true;
            if (!(node is IPuzzle))
                return false;
            if (Graph.Edges.Any(edge => edge.Origin.Equals(node) && edge.Destination.Equals(room)))
                return false;
            return true;
        }
    }
}
