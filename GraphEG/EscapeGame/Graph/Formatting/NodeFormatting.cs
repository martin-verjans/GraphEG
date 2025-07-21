using GraphEG.Core.Graph;
using QuikGraph.Graphviz.Dot;
using System;

namespace GraphEG.EscapeGame.Graph.Formatting
{
    [Serializable]
    public abstract class NodeFormatting
    {
        public GraphvizVertexStyle Style { get; set; } = GraphvizVertexStyle.Unspecified;
        public GraphvizVertexShape Shape { get; set; } = GraphvizVertexShape.Unspecified;
        public string NodeName { get; set; } = string.Empty;
        public GraphvizColor Color { get; set; } = GraphvizColor.Black;
        public abstract bool IsNodeMatchingFormatting(INode node);
    }

    public class NodeFormatting<TNode> : NodeFormatting where TNode : INode
    {
        public override bool IsNodeMatchingFormatting(INode node)
        {
            return node is TNode;
        }
    }
}