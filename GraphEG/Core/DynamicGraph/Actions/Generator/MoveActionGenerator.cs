using GraphEG.Core.StaticGraph;
using System;

namespace GraphEG.Core.DynamicGraph.Actions.Generator
{
    /// <summary>
    /// Generate Move actions when player(s) can walk from one room into another.
    /// </summary>
    [Serializable]
    public class MoveActionGenerator : ActionGenerator
    {
        protected override void GenerateActions()
        {
            foreach (IPlayer player in Graph.InGamePlayers())
            {
                AddPossibleMovesForPlayer(player);
            }
        }

        private void AddPossibleMovesForPlayer(IPlayer player)
        {
            IRoom currentRoom = Graph.GetPlayerLocation(player);
            foreach (IRoom room in Graph.GetConnectedRooms(currentRoom))
            {
                Actions.Add(new Move(player, currentRoom, room));
            }
        }
    }
}
