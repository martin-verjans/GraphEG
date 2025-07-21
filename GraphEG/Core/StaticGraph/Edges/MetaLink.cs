using System;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class MetaLink : StaticGraphEdge<IMeta, IStaticGraphNode>, IMetaLink
    {
        public MetaLink(IMeta origin, IStaticGraphNode destination)
            : this("meta", origin, destination)
        { }

        public MetaLink(string label, IMeta origin, IStaticGraphNode destination)
            : this(NameGenerator.GenerateName("W"), label, origin, destination)
        { }

        public MetaLink(string name, string label, IMeta origin, IStaticGraphNode destination)
            : base(label, name, origin, destination)
        { }
    }
}
