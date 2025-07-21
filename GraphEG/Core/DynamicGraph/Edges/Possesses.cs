using GraphEG.Core.StaticGraph;
using System;

namespace GraphEG.Core.DynamicGraph
{
    [Serializable]
    public class Possesses : DynamicEdge<IPlayer, ISkill>, IPossesses
    {
        public Possesses(IPlayer origin, ISkill destination) 
            : this("possesses", NameGenerator.GenerateName("D"), origin, destination)
        {
        }

        private Possesses(string label, string name, IPlayer origin, ISkill destination)
            :base(label, name, origin, destination)
        {

        }

        public override object Clone()
        {
            return new Possesses(Label, Name, Origin, Destination);
        }
    }
}
