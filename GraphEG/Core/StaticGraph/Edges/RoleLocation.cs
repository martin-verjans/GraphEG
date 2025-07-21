using System;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class RoleLocation : StaticGraphEdge<IRoom, IRole>, IRoleLocation
    {
        public RoleLocation(IRoom origin, IRole destination) : this(NameGenerator.GenerateName("W"), "is located", origin, destination) { }
        public RoleLocation(string name, string label, IRoom origin, IRole destination) : base(label, name, origin, destination) { }
    }
}
