using System;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class PuzzleRewardsPuzzle : StaticGraphEdge<IPuzzle, IPuzzle>, IPuzzleRewardsPuzzle
    {
        public PuzzleRewardsPuzzle(IPuzzle origin, IPuzzle destination) : this(NameGenerator.GenerateName("W"), "rewards", origin, destination) { }
        public PuzzleRewardsPuzzle(string name, string label, IPuzzle origin, IPuzzle destination) : base(label, name, origin, destination) { }
    }
}
