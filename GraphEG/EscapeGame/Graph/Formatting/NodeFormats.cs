using GraphEG.Core.DynamicGraph;
using GraphEG.Core.StaticGraph;
using QuikGraph.Graphviz.Dot;

namespace GraphEG.EscapeGame.Graph.Formatting
{
    public class RoomFormat : NodeFormatting<IRoom>
    {
        public RoomFormat()
        {
            Shape = GraphvizVertexShape.Rectangle;
            Color = GraphvizColor.Green;
        }
    }

    public class PuzzleFormat : NodeFormatting<IPuzzle>
    {
        public PuzzleFormat()
        {
            Shape = GraphvizVertexShape.Diamond;
            Color = GraphvizColor.Orange;
        }
    }

    public class ClueFormat : NodeFormatting<IClue>
    {
        public ClueFormat()
        {
            Shape = GraphvizVertexShape.Octagon;
            Color = GraphvizColor.Purple;
        }
    }

    public class RoleFormat  : NodeFormatting<IRole>
    {
        public RoleFormat()
        {
            Shape = GraphvizVertexShape.InvTriangle;
            Color = GraphvizColor.Brown;
        }
    }

    public class MetaFormat : NodeFormatting<IMeta>
    {
        public MetaFormat()
        {
            Shape = GraphvizVertexShape.Circle;
            Color = GraphvizColor.Cyan;
        }
    }

    public class SkillFormat : NodeFormatting<ISkill>
    {
        public SkillFormat()
        {
            Shape = GraphvizVertexShape.Circle;
            Color = GraphvizColor.Teal;
        }
    }

    public class PlayerFormat : NodeFormatting<IPlayer>
    {
        public PlayerFormat()
        {
            Shape = GraphvizVertexShape.DoubleCircle;
            Color = GraphvizColor.Blue;
        }
    }
}
