using GraphEG.Core.StaticGraph;
using System;

namespace GraphEG.Core.DynamicGraph
{
    [Serializable]
    public class CarriesClue : DynamicEdge<IPlayer, IClue>, ICarriesClue
    {
        public CarriesClue(IPlayer origin, IClue destination) 
            : this("carries", NameGenerator.GenerateName("D"), origin, destination)
        {
        }
        private CarriesClue(string label, string name, IPlayer origin, IClue destination)
            : base(label, name, origin, destination)
        {

        }

        public override object Clone()
        {
            return new CarriesClue(Label, Name, Origin, Destination);
        }
    }

    [Serializable]
    public class CarriesPuzzle : DynamicEdge<IPlayer, IPuzzle>, ICarriesPuzzle
    {
        public CarriesPuzzle(IPlayer origin, IPuzzle destination)
            : this("carries", NameGenerator.GenerateName("D"), origin, destination)
        {
        }
        private CarriesPuzzle(string label, string name, IPlayer origin, IPuzzle destination)
            : base(label, name, origin, destination)
        {

        }

        public override object Clone()
        {
            return new CarriesPuzzle(Label, Name, Origin, Destination);
        }
    }
}
