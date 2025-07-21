using GraphEG.Core.Graph;
using System.Collections.Generic;

namespace GraphEG.Core.StaticGraph
{
    public interface IStaticGraphNode : INode 
    {
        bool Validate(IStaticGraph graph, List<string> errors);
    }
    public interface IClue : IStaticGraphNode
    {
        object Value { get; }
        bool CanBeCarried { get; }
    }

    public interface IMeta : IStaticGraphNode
    {
        IMetaFunction MetaFunction { get; }
    }

    public interface IPuzzle : IStaticGraphNode
    {
    }

    public interface IRole : IStaticGraphNode
    {
        int PuzzleNumber { get; }
    }

    public interface IRoom : IStaticGraphNode
    {

    }

    public interface ISkill : IStaticGraphNode
    {
        string Description { get; }
    }
}
