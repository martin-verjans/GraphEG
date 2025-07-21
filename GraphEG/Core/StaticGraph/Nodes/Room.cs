using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class Room : Node, IRoom
    {
        public Room() : this(NameGenerator.GenerateName("R"))
        {            
        }

        public Room(string name) : base(name)
        {
        }

        public bool Validate(IStaticGraph graph, List<string> errors)
        {
            //A room is valid if it possesses any incoming edge (except for Meta links)
            if (graph.Edges.Any(e => e.Destination == this && (!(e is MetaLink))))
                return true;
            errors.Add($"Room {Name} is not reachable");
            return false;
        }
    }
}
