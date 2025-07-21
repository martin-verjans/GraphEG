using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class Meta : Node, IMeta
    {
        public IMetaFunction MetaFunction { get; }

        public Meta(IMetaFunction metaFunction)
            : this(NameGenerator.GenerateName("I"), metaFunction) { }

        public Meta(string name, IMetaFunction metaFunction)
            : base(name)
        {
            MetaFunction = metaFunction;
            MetaFunction.MetaNode = this;
        }

        public bool Validate(IStaticGraph graph, List<string> errors)
        {
            if (MetaFunction.ToString() == "Exit")
            {
                if (graph.Edges.Any(e => e.Origin == this && e.Destination is Room))
                {
                    return true;
                }
                errors.Add($"Meta node {Name} must link to at least one room");
                return false;
            }
            return true;
        }

        public override string GenerateParameters()
        {
            return MetaFunction.GetType().Name;
        }
    }
}
