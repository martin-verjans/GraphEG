using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class Puzzle : Node, IPuzzle
    {
        public int PuzzleNumber { get; }
        public Puzzle() : this(NameGenerator.GenerateName("Z"), NameGenerator.GetCounter("Z") - 1) { }
        private Puzzle(string name, int puzzleNumber) : base(name)
        {
            PuzzleNumber = puzzleNumber;
        }

        public bool Validate(IStaticGraph graph, List<string> errors)
        {
            bool validated = true;
            //A Valid puzzle must
            /*
             * Offer at least one reward (outgoing edge)
             * be located in one room or be the reward of a puzzle
             * possess at least one role
             */
            if (!graph.Edges.Where(e => e.Origin == this).Any())
            {
                errors.Add($"Puzzle {Name} must offer at least one reward");
                validated = false;
            }
            if (
                graph.Edges.OfType<PuzzleLocation>().Where(e => e.Destination == this).Count() != 1
                &&
                graph.Edges.OfType<PuzzleRewardsPuzzle>().Where(e => e.Destination == this).Count() != 1)
            {
                errors.Add($"Puzzle {Name} is not reachable from anywhere");
                validated = false;
            }
            if (!graph.Edges.OfType<PuzzleRole>().Where(e => e.Destination == this).Any())
            {
                errors.Add($"Puzzle {Name} must have at least one role connected");
                validated = false;
            }
            return validated;
        }
    }
}
