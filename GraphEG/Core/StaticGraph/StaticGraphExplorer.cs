using GraphEG.Core.Graph;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.StaticGraph
{
    public static class StaticGraphExplorer
    {
        public static IDictionary<IPuzzle, IEnumerable<IRoom>> GetRoomsForEachPuzzle(this IStaticGraph graph, IEnumerable<IPuzzle> puzzles)
        {
            return puzzles.ToDictionary(z => z, z => graph.GetRoleLocations(graph.GetRolesForPuzzle(z)));
        }
        public static IEnumerable<IRoom> GetRoleLocations(this IStaticGraph graph, IEnumerable<IRole> roles)
        {
            return graph.FindAllConnected(roles).OfType<IRoom>().Distinct();
        }
        public static IEnumerable<IRole> GetRolesForPuzzle(this IStaticGraph graph, IPuzzle puzzle)
        {
            return graph.FindAllConnected(puzzle).OfType<IRole>();
        }
        public static IEnumerable<IStartingPosition> GetStartingPositions(this IStaticGraph graph)
        {
            return graph.Edges.OfType<IStartingPosition>();
        }

        public static IRoom GetItemLocation(this IStaticGraph graph, INode node)
        {
            if (node is IRoom room) return room;
            if (node is IClue clue)
            {
                return graph.Edges
                    .OfType<IClueLocation>()
                    .FirstOrDefault(cl => cl.Destination == clue)
                    ?.Origin;
            }
            if (node is IPuzzle puzzle)
            {
                return graph.Edges
                    .OfType<IPuzzleLocation>()
                    .FirstOrDefault(cl => cl.Destination == puzzle)
                    ?.Origin;
            }
            if (node is IRole role)
            {
                return graph.Edges
                    .OfType<IRoleLocation>()
                    .FirstOrDefault(cl => cl.Destination == role)
                    ?.Origin;
            }
            return null;
        }
    }
}
