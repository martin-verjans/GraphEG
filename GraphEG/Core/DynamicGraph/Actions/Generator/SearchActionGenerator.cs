using GraphEG.Core.StaticGraph;
using System;

namespace GraphEG.Core.DynamicGraph.Actions.Generator
{
    /// <summary>
    /// Generate a search action for every player in its room
    /// </summary>
    [Serializable]
    public class SearchActionGenerator : ActionGenerator
    {
        protected override void GenerateActions()
        {
            foreach (IPlayer player in Graph.InGamePlayers())
            {
                IRoom playerLocation = Graph.GetPlayerLocation(player);
                if (playerLocation == null)
                    continue;
                Actions.Add(new Search(player, playerLocation));
            }
        }
    }
}
