using GraphEG.Core.DynamicGraph;
using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class MetaExit : MetaFunction
    {
        public MetaExit()
            : base("exit", 1, true)
        {

        }
        protected override void Action(IDynamicGraph graph)
        {
            IEnumerable<Room> exitRooms = graph.StaticGraph.Edges.OfType<MetaLink>().Where(e => e.Origin == MetaNode).Select(e => (Room)e.Destination);
            IEnumerable<ContainsPlayer> playerLocations = graph.Edges.OfType<ContainsPlayer>();

            RemovePlayersInExitRoom(graph, exitRooms, playerLocations);
        }

        private void RemovePlayersInExitRoom(IDynamicGraph graph, IEnumerable<Room> exitRooms, IEnumerable<ContainsPlayer> playerLocations)
        {
            foreach (ContainsPlayer edge in playerLocations.ToList())
            {
                RemovePlayerIfInExitRoom(graph, exitRooms, edge);
            }
        }

        private void RemovePlayerIfInExitRoom(IDynamicGraph graph, IEnumerable<Room> exitRooms, ContainsPlayer edge)
        {
            IPlayer p = edge.Destination;
            if (IsPlayerInExitRoom(exitRooms, edge))
            {
                RemovePlayer(graph, p);
                Log($"Player {p} has left the game");
            }
        }

        private void RemovePlayer(IDynamicGraph graph, IPlayer p)
        {
            IEnumerable<IEdge<INode>> edges = graph.Edges.Where(e => e.Origin.Equals(p) || e.Destination.Equals(p)).ToList();
            foreach (IEdge<INode> toRemove in edges)
            {
                graph.RemoveEdge(toRemove);
            }
            p.Exit();
        }

        private bool IsPlayerInExitRoom(IEnumerable<Room> exitRooms, ContainsPlayer edge)
        {
            return exitRooms.Contains(edge.Origin);
        }

        protected override bool Condition(IDynamicGraph graph)
        {
            return true;
        }
    }
}
