using System;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class PuzzleRewardsRoom : StaticGraphEdge<IPuzzle, IRoom>, IPuzzleRewardsRoom
    {
        public PuzzleRewardsRoom(IPuzzle origin, IRoom destination) : this(NameGenerator.GenerateName("W"), "rewards", origin, destination) { }
        public PuzzleRewardsRoom(string name, string label, IPuzzle origin, IRoom destination) : base(label, name, origin, destination) { }
    }
}
