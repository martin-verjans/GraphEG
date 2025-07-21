using System;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class PuzzleRole : StaticGraphEdge<IRole, IPuzzle>, IPuzzleRole
    {
        public PuzzleRole(IRole origin, IPuzzle destination) : this(NameGenerator.GenerateName("W"), "requires", origin, destination) { }
        public PuzzleRole(string name, string label, IRole origin, IPuzzle destination) : base(label, name, origin, destination) { }
    }
}
