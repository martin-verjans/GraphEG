using GraphEG.Core.StaticGraph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.DynamicGraph.Actions.Generator
{
    /// <summary>
    /// Generate actions when player(s) can attempt to solve a puzzle
    /// </summary>
    [Serializable]
    public class AttemptActionGenerator : ActionGenerator
    {
        protected override void GenerateActions()
        {
            Dictionary<IPuzzle, IEnumerable<IPlayer>> attempts = CreateAttemptMapping();
            foreach (KeyValuePair<IPuzzle, IEnumerable<IPlayer>> kvp in attempts)
            {
                CreateCombinationsForPuzzle(kvp);
            }
        }

        private void CreateCombinationsForPuzzle(KeyValuePair<IPuzzle, IEnumerable<IPlayer>> kvp)
        {
            IEnumerable<IEnumerable<IPlayer>> combinations = kvp.Value.Combinations();
            foreach (IEnumerable<IPlayer> playerList in combinations)
            {
                Actions.Add(new Attempt(playerList, kvp.Key));
            }
        }

        private Dictionary<IPuzzle, IEnumerable<IPlayer>> CreateAttemptMapping()
        {
            IEnumerable<IPuzzle> puzzles = Graph.GetAllUnsolvedPuzzles();
            IDictionary<IPuzzle, IEnumerable<IRoom>> rooms = Graph.StaticGraph.GetRoomsForEachPuzzle(puzzles);
            return rooms.ToDictionary(kvp => kvp.Key, kvp => Graph.GetPlayersInRooms(kvp.Value));
        }
    }
}
