using System;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class RequiredSkill : StaticGraphEdge<ISkill, IRole>, IRequiredSkill
    {
        public RequiredSkill(Skill origin, Role destination)
            : this(NameGenerator.GenerateName("W"), "requires", origin, destination)
        { }

        public RequiredSkill(string name, string label, ISkill origin, IRole destination)
            : base(label, name, origin, destination)
        { }
    }
}
