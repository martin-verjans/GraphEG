using GraphEG.Core.StaticGraph;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GraphEG.Core.DynamicGraph
{
    public static class DynamicGraphExplorer
    {
        public static IEnumerable<IPlayer> GetPlayersInRooms(this IDynamicGraph graph, IEnumerable<IRoom> rooms)
        {
            return graph.Edges
                .OfType<ContainsPlayer>()
                .Where(cp => rooms.Contains(cp.Origin))
                .Select(cp => cp.Destination)
                .OrderBy(player => player.Name);
        }
        public static IEnumerable<IPuzzle> GetAllUnsolvedPuzzles(this IDynamicGraph graph)
        {
            return graph.Nodes.
                OfType<IPuzzle>()
                .Where(z => graph.DiscoveredNodes.Contains(z));
        }

        public static IEnumerable<IClue> CarriedClues(this IDynamicGraph graph, IPlayer player)
        {
            return graph.FindAllConnected(player)
                .OfType<IClue>()
                .Where(c => c.CanBeCarried);
        }
        public static bool DoesPlayerKnowClue(this IDynamicGraph graph, IPlayer player, IClue clue)
        {
            return graph.Edges
                .OfType<IKnows>()
                .Any(k => k.Origin == player && k.Destination == clue);
        }

        public static IEnumerable<IClue> GetAvailableClues(this IDynamicGraph graph, IRoom room)
        {
            return graph.FindAllConnected(room)
                .OfType<IClue>();
        }

        public static IEnumerable<IRoom> GetConnectedRooms(this IDynamicGraph graph, IRoom room)
        {
            return graph.FindAllConnected(room)
                    .OfType<ILeadsTo>()
                    .Where(d => d.Origin == room)
                    .Select(d => d.Destination);
        }

        public static IEnumerable<IPlayer> InGamePlayers(this IDynamicGraph graph)
        {
            return graph.Players.Where(p => !p.HasExited);
        }

        public static bool IsPlayerOutside(this IDynamicGraph graph, IPlayer player)
        {
            return graph.GetPlayerLocation(player) is null;
        }

        public static IEnumerable<IRoom> GetAllPlayerLocations(this IDynamicGraph graph)
        {
            return graph.FindAllConnected(graph.Players)
                .OfType<IRoom>()
                .Distinct();
        }

        public static IRoom GetPlayerLocation(this IDynamicGraph graph, IPlayer player)
        {
            return graph.Edges
                .OfType<IContainsPlayer>()
                .FirstOrDefault(cp => cp.Destination == player)?.Origin;
        }

        public static IEnumerable<ISkill> GetPlayerSkills(this IDynamicGraph graph, IPlayer player)
        {
            return graph.Edges
                .OfType<IPossesses>()
                .Where(e => e.Origin == player)
                .Select(e => e.Destination);
        }

        public static bool DoesPlayerHaveSkills(this IDynamicGraph graph, IPlayer player, IRole role)
        {
            IEnumerable<ISkill> playerSkills = graph.GetPlayerSkills(player);
            IEnumerable<ISkill> requiredSkills = graph.StaticGraph.FindAllConnected(role).OfType<ISkill>();
            return requiredSkills.All(rs => playerSkills.Contains(rs));
        }
    }
}
