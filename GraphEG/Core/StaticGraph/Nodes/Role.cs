using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class Role : Node, IRole
    {

        public static Role GenerateGlobalStartingPosition()
        {
            return new Role("L0", 0);
        }

        public int PuzzleNumber { get; }

        public Role(int puzzleNumber) : this(NameGenerator.GenerateName($"L.{puzzleNumber}."), puzzleNumber) { }

        public Role() : this(NameGenerator.GenerateName("L"), 0) { }

        public Role(string name, int puzzleNumber) : base(name)
        {
            PuzzleNumber = puzzleNumber;
        }

        public bool Validate(IStaticGraph graph, List<string> errors)
        {
            //A role must have
            /*
             * if starting location :
             * One edge going to one room
             * No incoming edge (except skills)
             * 
             * if puzzle role :
             * One edge going to one puzzle
             * Be located in one room
             * 
             */
            if (PuzzleNumber > 0)
            {
                return ValidatePuzzleRole(graph, errors);
            }
            return ValidateStartingPosition(graph, errors);
        }

        private bool ValidateStartingPosition(IStaticGraph graph, List<string> errors)
        {
            bool validated = true;
            if (graph.Edges.OfType<StartingPosition>().Count(e => e.Origin == this) != 1)
            {
                errors.Add($"Role {Name} must link to one room");
                validated = false;
            }
            if (graph.Edges.Any(e => e.Destination == this && (!((e is RequiredSkill) || (e is MetaLink)))))
            {
                errors.Add($"Role {Name} must not receive links from nodes other than skills or meta");
                validated = false;
            }
            return validated;
        }

        private bool ValidatePuzzleRole(IStaticGraph graph, List<string> errors)
        {
            bool validated = true;
            if (graph.Edges.OfType<PuzzleRole>().Count(e => e.Origin == this) != 1)
            {
                errors.Add($"Role {Name} must link to one puzzle");
                validated = false;
            }
            if (graph.Edges.OfType<RoleLocation>().Count(e => e.Destination == this) != 1)
            {
                errors.Add($"Role {Name} must be located in one room");
                validated = false;
            }
            return validated;
        }
    }
}
