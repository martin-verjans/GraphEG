using System;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class PuzzleLocation : StaticGraphEdge<IRoom, IPuzzle>, IPuzzleLocation
    {
        public PuzzleLocation(IRoom origin, IPuzzle destination) : this(NameGenerator.GenerateName("W"), "is located", origin, destination) { }
        public PuzzleLocation(string name, string label, IRoom origin, IPuzzle destination) : base(label, name, origin, destination) { }
    }
}
