using GraphEG.Core.StaticGraph;
using System;

namespace GraphEG.Core.DynamicGraph.Actions.Generator
{
    /// <summary>
    /// Generate actions for picking up, dropping and memorizing clues
    /// </summary>
    [Serializable]
    public class ClueActionGenerator : ActionGenerator
    {
        protected override void GenerateActions()
        {
            foreach (IPlayer player in Graph.InGamePlayers())
            {
                AddActionsForAvailableClues(player);
            }
        }

        private void AddActionsForAvailableClues(IPlayer player)
        {
            IRoom currentRoom = Graph.GetPlayerLocation(player);
            foreach (IClue c in Graph.GetAvailableClues(currentRoom))
            {
                AddActionForClue(player, c);
            }
            foreach (IClue c in Graph.CarriedClues(player))
            {
                Actions.Add(new Drop(player, c));
            }
        }

        private void AddActionForClue(IPlayer player, IClue c)
        {
            if (c.CanBeCarried)
            {
                Actions.Add(new PickUp(player, c));
                return;
            }
            if (!Graph.DoesPlayerKnowClue(player, c))
            {
                Actions.Add(new Memorize(player, c));
            }
        }
    }
}
