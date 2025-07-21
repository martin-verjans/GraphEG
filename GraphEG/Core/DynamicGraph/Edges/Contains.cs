using GraphEG.Core.StaticGraph;
using System;

namespace GraphEG.Core.DynamicGraph
{
    [Serializable]
    public class ContainsPlayer : DynamicEdge<IRoom, IPlayer>, IContainsPlayer
    {
        public ContainsPlayer(IRoom origin, IPlayer destination) 
            : this("contains", NameGenerator.GenerateName("D"), origin, destination)
        {
        }

        private ContainsPlayer(string label, string name, IRoom origin, IPlayer destination)
            : base(label, name, origin, destination)
        {

        }

        public override object Clone()
        {
            return new ContainsPlayer(Label, Name, Origin, Destination);
        }
    }

    [Serializable]
    public class ContainsClue : DynamicEdge<IRoom, IClue>, IContainsClue
    {
        public ContainsClue(IRoom origin, IClue destination)
            : this("contains", NameGenerator.GenerateName("D"), origin, destination)
        {
        }

        private ContainsClue(string label, string name, IRoom origin, IClue destination)
            : base(label, name, origin, destination)
        {

        }

        public override object Clone()
        {
            return new ContainsClue(Label, Name, Origin, Destination);
        }
    }

    [Serializable]
    public class ContainsPuzzle : DynamicEdge<IRoom, IPuzzle>, IContainsPuzzle
    {
        public ContainsPuzzle(IRoom origin, IPuzzle destination)
            : this("contains", NameGenerator.GenerateName("D"), origin, destination)
        {
        }

        private ContainsPuzzle(string label, string name, IRoom origin, IPuzzle destination)
            : base(label, name, origin, destination)
        {

        }

        public override object Clone()
        {
            return new ContainsPuzzle(Label, Name, Origin, Destination);
        }
    }

    [Serializable]
    public class ContainsRole: DynamicEdge<IRoom, IRole>, IContainsRole
    {
        public ContainsRole(IRoom origin, IRole destination)
            : this("contains", NameGenerator.GenerateName("D"), origin, destination)
        {
        }

        private ContainsRole(string label, string name, IRoom origin, IRole destination)
            : base(label, name, origin, destination)
        {

        }

        public override object Clone()
        {
            return new ContainsRole(Label, Name, Origin, Destination);
        }
    }
}
