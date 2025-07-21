using System;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class Door : StaticGraphEdge<IRoom, IRoom>, IDoor
    {
        public Door(IRoom origin, IRoom destination)
            : this(NameGenerator.GenerateName("W"), "leads to", origin, destination)
        { }

        public Door(string name, string label, IRoom origin, IRoom destination)
            : base(label, name, origin, destination)
        { }
    }
}
