using GraphEG.Core.StaticGraph;
using System;

namespace GraphEG.Core.DynamicGraph.Actions
{
    [Serializable]
    public class Memorize : PlayerAction
    {
        public IClue Clue { get; }

        public override string Name => $"Memorize({Player}, {Clue})";

        public Memorize(IPlayer player, IClue clue) : base(player)
        {
            Clue = clue;
        }
        protected override void InternalExecute()
        {
            AddEdge(new Knows(Player, Clue));
        }

        public override string ToString()
        {
            if (!Executed)
            {
                return $"Player {Player} can memorize Clue {Clue}";
            }
            return $"Player {Player} memorized Clue {Clue}";
        }
    }
}
