using System;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class StartingPosition : StaticGraphEdge<IRole, IRoom>, IStartingPosition
    {
        public StartingPosition(IRole origin, IRoom destination)
            : this(NameGenerator.GenerateName("W"), "starts in", origin, destination)
        { }

        public StartingPosition(string name, string label, IRole origin, IRoom destination)
            : base(label, name, origin, destination)
        { }
    }
}
