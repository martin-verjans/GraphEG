using GraphEG.Core.StaticGraph;
using System;

namespace GraphEG.Core.DynamicGraph
{
    [Serializable]
    public class LeadsTo : DynamicEdge<IRoom, IRoom>, ILeadsTo
    {
        public LeadsTo(IRoom origin, IRoom destination)
            : this("leads to", NameGenerator.GenerateName("D"), origin, destination)
        {
        }

        private LeadsTo(string label, string name, IRoom origin, IRoom destination) 
            : base(label, name, origin, destination)
        {

        }

        public override object Clone()
        {
            return new LeadsTo(Label, Name, Origin, Destination);
        }
    }
}
