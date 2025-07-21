using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class Skill : Node, ISkill
    {
        public string Description { get; }
        public Skill(string description) : this(description, NameGenerator.GenerateName("S"))
        { }

        public Skill(string description, string name) : base(name)
        {
            Description = description;
        }

        public bool Validate(IStaticGraph graph, List<string> errors)
        {
            //a skill is valid in any case
            //even if not used
            return true;
        }
    }
}
