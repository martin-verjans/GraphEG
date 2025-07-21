using System;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class PuzzleRewardsClue : StaticGraphEdge<IPuzzle, IClue>, IPuzzleRewardsClue
    {
        public PuzzleRewardsClue(IPuzzle origin, IClue destination) : this(NameGenerator.GenerateName("W"), "rewards", origin, destination) { }
        public PuzzleRewardsClue(string name, string label, IPuzzle origin, IClue destination) : base(label, name, origin, destination) { }
    }
}
