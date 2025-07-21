using GraphEG.Core.StaticGraph;
using System;
using System.Linq;

namespace GraphEG.Core.DynamicGraph.Actions
{
    [Serializable]
    public class PickUp : PlayerAction
    {
        public IClue Clue { get; }

        public override string Name => $"Pickup({Player}, {Clue})";

        public PickUp(IPlayer player, IClue clue) : base(player)
        {
            Clue = clue;
        }
        protected override void InternalExecute()
        {
            AddEdge(new CarriesClue(Player, Clue));
            RemoveEdge(Graph.Edges.OfType<IContainsClue>().First(c => c.Destination == Clue));
        }

        public override string ToString()
        {
            if (!Executed)
            {
                return $"Player {Player} can pick-up Clue {Clue}";
            }
            return $"Player {Player} picked up Clue {Clue}";
        }
    }
}
