using GraphEG.Core.StaticGraph;
using System;
using System.Linq;

namespace GraphEG.Core.DynamicGraph.Actions
{
    [Serializable]
    public class Drop : PlayerAction
    {
        public IClue Clue { get; }
        private IRoom room;

        public override string Name => $"Drop({Player}, {Clue})";

        public Drop(IPlayer player, IClue clue) : base(player)
        {
            Clue = clue;
        }
        protected override void InternalExecute()
        {
            room = Graph.Edges.OfType<IContainsPlayer>().First(cp => cp.Destination == Player).Origin;
            AddEdge(new ContainsClue(room, Clue));
            RemoveEdge(Graph.Edges.OfType<ICarriesClue>().First(c => c.Origin == Player && c.Destination == Clue));
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
