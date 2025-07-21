using GraphEG.Core.DynamicGraph;
using GraphEG.Core.Graph;
using GraphEG.Core.StaticGraph;
using GraphEG.EscapeGame.Graph.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.EscapeGame.Graph
{
    [Serializable]
    public class GraphDisplayOptions
    {
        public Dictionary<Type, NodeFormatting> NodeFormattingOptions { get; set; } = new Dictionary<Type, NodeFormatting>();
        public bool UseRawDisplay { get; set; } = false;
        public bool UseColors { get; set; } = true;
        public bool UseShapes { get; set; } = true;

        public NodeFormatting GetFormattingOptions(INode node)
        {
            return NodeFormattingOptions.FirstOrDefault(kvp => kvp.Value.IsNodeMatchingFormatting(node)).Value;
        }

        public static GraphDisplayOptions Default
        {
            get
            {
                GraphDisplayOptions options = new GraphDisplayOptions();
                options.NodeFormattingOptions.Add(typeof(IRoom), new RoomFormat());
                options.NodeFormattingOptions.Add(typeof(IPuzzle), new PuzzleFormat());
                options.NodeFormattingOptions.Add(typeof(IClue), new ClueFormat());
                options.NodeFormattingOptions.Add(typeof(IRole), new RoleFormat());
                options.NodeFormattingOptions.Add(typeof(IMeta), new MetaFormat());
                options.NodeFormattingOptions.Add(typeof(ISkill), new SkillFormat());
                options.NodeFormattingOptions.Add(typeof(IPlayer), new PlayerFormat());
                return options;
            }
        }
    }
}
