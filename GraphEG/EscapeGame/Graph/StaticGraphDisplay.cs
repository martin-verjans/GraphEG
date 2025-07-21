using GraphEG.Core.Graph;
using GraphEG.Core.StaticGraph;
using GraphEG.EscapeGame.Graph;
using QuikGraph;
using QuikGraph.Graphviz;
using QuikGraph.Graphviz.Dot;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.EscapeGame
{
    public class StaticGraphDisplay : GraphDisplay
    {
        public StaticGraphDisplay(GraphDisplayOptions options) : base(options)
        {
            Errors = new List<string>();
        }

        public new IStaticGraph Graph => (IStaticGraph)base.Graph;
        public List<string> Errors { get; set; }

        public override void FormatEdge(object sender, FormatEdgeEventArgs<INode, GraphicalEdge> e)
        {
            base.FormatEdge(sender, e);

            GraphicalEdge edge = e.Edge;
            GraphvizEdge formatter = e.EdgeFormat;
            if (edge.Edge is Door door)
            {
                formatter.Weight = 100;
                formatter.Length = 2;
                Door backwardEdge = Graph.Edges
                    .OfType<Door>()
                    .FirstOrDefault(ed => ed.Origin == door.Destination && ed.Destination == door.Origin);

                if (backwardEdge != null)
                {
                    if (backwardEdge.Id < edge.Edge.Id)
                    {
                        formatter.Style = GraphvizEdgeStyle.Invis;
                        formatter.IsConstrained = false;
                        return;
                    }
                    formatter.Direction = GraphvizEdgeDirection.Both;
                }

                formatter.Style = GraphvizEdgeStyle.Dashed;
                if (Options.UseColors)
                    formatter.StrokeColor = GraphvizColor.Green;
                return;
            }
            if (edge.Edge is PuzzleRewardsRoom)
            {
                formatter.Weight = 100;
                formatter.Length = 2;
                formatter.Style = GraphvizEdgeStyle.Dashed;
                if (Options.UseColors)
                    formatter.StrokeColor = GraphvizColor.Green;
                return;
            }
            if (edge.Edge is MetaLink)
            {
                formatter.Style = GraphvizEdgeStyle.Solid;
                formatter.Direction = GraphvizEdgeDirection.Both;
                return;
            }
            IRoom destinationRoom = Graph.GetItemLocation(edge.Target);
            IRoom originRoom = Graph.GetItemLocation(edge.Source);
            if (destinationRoom != null && originRoom != null && destinationRoom != originRoom)
            {
                formatter.IsConstrained = false;
            }
        }

        public override void FormatVertex(object sender, FormatVertexEventArgs<INode> e)
        {
            base.FormatVertex(sender, e);

            IStaticGraphNode node = (IStaticGraphNode)e.Vertex;
            GraphvizVertex formatter = e.VertexFormat;

            if (node is Meta meta)
            {
                if (meta.MetaFunction is MetaVictory)
                {
                    formatter.Label = "Entry";
                }
            }

            if (!node.Validate(Graph, Errors))
            {
                formatter.Style = GraphvizVertexStyle.Bold;
                formatter.StrokeColor = GraphvizColor.Red;
                formatter.FontColor = GraphvizColor.Red;
            }
        }

        public override void FormatCluster(object sender, FormatClusterEventArgs<INode, GraphicalEdge> e)
        {
            base.FormatCluster(sender, e);

            Room r = e.Cluster.Vertices.OfType<Room>().First();
            if (!r.Validate(Graph, new List<string>()))
            {
                e.GraphFormat.FontColor = GraphvizColor.Red;
                //e.GraphFormat.BackgroundColor = GraphvizColor.Red;
            }
        }

        protected override IEdgeListGraph<INode, GraphicalEdge> InternalRefreshGraph()
        {
            Errors.Clear();
            ClusteredAdjacencyGraph<INode, GraphicalEdge> displayGraph = (ClusteredAdjacencyGraph<INode, GraphicalEdge>)base.InternalRefreshGraph();
            UpdateMetaVictoryLinks(displayGraph);
            return displayGraph;
        }

        private void UpdateMetaVictoryLinks(ClusteredAdjacencyGraph<INode, GraphicalEdge> displayGraph)
        {
            IMeta victoryNode = Graph.Nodes.OfType<Meta>().Where(m => m.MetaFunction is MetaVictory).FirstOrDefault();
            if (victoryNode is null)
            {
                return;
            }
            IEnumerable<Role> starts = Graph.Edges.OfType<StartingPosition>().Where(sp => sp.Origin.Name != "L0").Select(sp => (Role)sp.Origin);
            foreach(Role start in starts)
            {
                displayGraph.AddEdge(new GraphicalEdge(new MetaLink(victoryNode, start)));
            }
        }
    }
}
