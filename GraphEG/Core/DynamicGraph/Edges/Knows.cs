using GraphEG.Core.StaticGraph;
using System;

namespace GraphEG.Core.DynamicGraph
{
    [Serializable]
    public class Knows : DynamicEdge<IPlayer, IClue>, IKnows
    {
        public Knows(IPlayer origin, IClue destination) 
            : this("knows", NameGenerator.GenerateName("D"), origin, destination)
        {
        }
        private Knows(string label, string name, IPlayer origin, IClue destination)
            : base(label, name, origin, destination)
        {

        }

        public override object Clone()
        {
            return new Knows(Label, Name, Origin, Destination);
        }
    }
}
