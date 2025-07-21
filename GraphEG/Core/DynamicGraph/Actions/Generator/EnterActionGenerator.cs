using GraphEG.Core.StaticGraph;
using System;

namespace GraphEG.Core.DynamicGraph.Actions.Generator
{
    /// <summary>
    /// Generate actions to enter the Escape Game
    /// </summary>
    [Serializable]
    internal class EnterActionGenerator : ActionGenerator
    {
        protected override void GenerateActions()
        {
            //if at least one player is connected only to skills, he didn't enter the game :
            // he can enter the game in the starting positions
            // the others can do nothing yet
            foreach (IPlayer p in Graph.Players)
            {
                CheckEnterForPlayer(p);
            }
        }

        private void CheckEnterForPlayer(IPlayer player)
        {
            if (!Graph.IsPlayerOutside(player) || player.HasExited) 
                return;
            foreach (IStartingPosition position in Graph.StaticGraph.GetStartingPositions())
            {
                GenerateEnterIfPlayerHasSkills(player, position);
            }
        }

        private void GenerateEnterIfPlayerHasSkills(IPlayer player, IStartingPosition position)
        {
            if (!Graph.DoesPlayerHaveSkills(player, position.Origin)) 
                return;
            Actions.Add(new Enter(player, position.Destination));
        }
    }
}
