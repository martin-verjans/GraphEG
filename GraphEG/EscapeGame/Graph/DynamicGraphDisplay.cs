using GraphEG.Core.DynamicGraph;
using GraphEG.Core.Graph;
using GraphEG.Core.StaticGraph;
using QuikGraph;
using QuikGraph.Graphviz;
using QuikGraph.Graphviz.Dot;
using System.Linq;

namespace GraphEG.EscapeGame.Graph
{
    public class DynamicGraphDisplay : GraphDisplay
    {
        public DynamicGraphDisplay(GraphDisplayOptions options) : base(options)
        {
        }

        public new IDynamicGraph Graph => (IDynamicGraph)base.Graph;

        public override void FormatEdge(object sender, FormatEdgeEventArgs<INode, GraphicalEdge> e)
        {
            base.FormatEdge(sender, e);

            GraphicalEdge edge = e.Edge;
            GraphvizEdge formatter = e.EdgeFormat;
            if (edge.Edge is LeadsTo door)
            {
                LeadsTo backwardEdge = Graph.Edges
                    .OfType<LeadsTo>()
                    .FirstOrDefault(ed => ed.Origin == door.Destination && ed.Destination == door.Origin);
                if (backwardEdge != null)
                {
                    if (backwardEdge.Id < edge.Edge.Id)
                    {
                        formatter.Style = GraphvizEdgeStyle.Invis;
                        return;
                    }
                    else 
                    {
                        formatter.Direction = GraphvizEdgeDirection.Both;
                    }
                }

                formatter.Style = GraphvizEdgeStyle.Dashed;
                formatter.StrokeColor = GraphvizColor.Green;
                return;
            }
        }

        public override void FormatVertex(object sender, FormatVertexEventArgs<INode> e)
        {
            base.FormatVertex(sender, e);
            if (!(e.Vertex is Player p))
            {
                return;
            }
            if (p.HasExited)
            {
                e.VertexFormat.Shape = GraphvizVertexShape.House;
            }
        }

        public override void FormatCluster(object sender, FormatClusterEventArgs<INode, GraphicalEdge> e)
        {
            base.FormatCluster(sender, e);
        }

        protected override IEdgeListGraph<INode, GraphicalEdge> InternalRefreshGraph()
        {
            var displayGraph = new ClusteredAdjacencyGraph<INode, GraphicalEdge>(new AdjacencyGraph<INode, GraphicalEdge>());
            displayGraph.AddVertexRange(Graph.Players.Concat(Graph.Nodes.OfType<Skill>().Concat(Graph.Nodes.Intersect(Graph.DiscoveredNodes))));
            displayGraph.AddEdgeRange(Graph.Edges.Select(e => new GraphicalEdge(e)));

            foreach (Room room in Graph.Nodes.OfType<Room>())
            {
                if (!Graph.DiscoveredNodes.Contains(room))
                    continue;
                var allItems = Graph.FindAllConnected(room);
                var nodes = allItems
                    .OfType<INode>()
                    .Where(n =>
                    {
                        if (n is Clue || n is Role || n is Player)
                            return true;
                        if (n is Puzzle)
                        {
                            if (Graph.Edges.Any(edge => edge.Origin.Equals(n) && edge.Destination.Equals(room)))
                                return false;
                            return true;
                        }
                        return false;
                    });
                //var edges = allItems
                //    .OfType<Core.Graph.IEdge<IStaticGraphNode>>()
                //    .Where(e => e is ClueLocation || e is RoleLocation || e is PuzzleLocation);
                var cluster = displayGraph.AddCluster();
                cluster.AddVertex(room);
                cluster.AddVertexRange(nodes);
            }

            return displayGraph;
        }
    }
}
