using System;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class ClueLocation : StaticGraphEdge<IRoom, IClue>, IClueLocation
    {
        public ClueLocation(IRoom origin, IClue destination)
            : this(NameGenerator.GenerateName("W"), "is located", origin, destination)
        { }

        public ClueLocation(string name, string label, IRoom origin, IClue destination)
            : base(label, name, origin, destination)
        { }
    }
}
