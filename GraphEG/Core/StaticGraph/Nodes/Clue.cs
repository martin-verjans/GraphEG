using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class Clue : Node, IClue
    {
        public object Value { get; }
        public bool CanBeCarried { get; }

        public Clue(object value, bool canBeCarried, int puzzleNumber)
            : this(value, canBeCarried, NameGenerator.GenerateName($"C.{puzzleNumber}."))
        {

        }

        public Clue(object value, bool canBeCarried, string name)
            : base(name)
        {
            Value = value;
            CanBeCarried = canBeCarried;
        }

        public bool Validate(IStaticGraph graph, List<string> errors)
        {
            bool validated = true;
            /*
             * A clue must be :
             * - Linked to a role (and only one)
             * - Located in a room or be a puzzle reward (only one)
            */
            if (graph.Edges.OfType<RequiredClue>().Where(e => e.Origin == this).Count() != 1)
            {
                errors.Add($"Clue {Name} must be linked to only one role");
                validated = false;
            }
            if (graph.Edges.OfType<ClueLocation>().Cast<IStaticGraphEdge<IStaticGraphNode>>().Concat(graph.Edges.OfType<PuzzleRewardsClue>()).Where(e => e.Destination == this).Count() != 1)
            {
                errors.Add($"Clue {Name} must be linked to only one room");
                validated = false;
            }
            return validated;
        }
    }
}
