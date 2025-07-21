using System;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class RequiredClue : StaticGraphEdge<IClue, IRole>, IRequiredClue
    {
        public RequiredClue(IClue origin, IRole destination)
            : this(NameGenerator.GenerateName("W"), "requires", origin, destination)
        { }

        public RequiredClue(string name, string label, IClue origin, IRole destination)
            : base(label, name, origin, destination)
        { }
    }
}
