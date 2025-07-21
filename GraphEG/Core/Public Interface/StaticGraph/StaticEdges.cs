using GraphEG.Core.Graph;

namespace GraphEG.Core.StaticGraph
{
    public interface IStaticGraphEdge<TNode> : IEdge<INode> where TNode : INode 
    {
        new TNode Origin { get; }
        new TNode Destination { get; }
    }
    public interface IStaticGraphEdge<TOrigin, TDestination> : IStaticGraphEdge<IStaticGraphNode>
        where TOrigin : IStaticGraphNode
        where TDestination : IStaticGraphNode
    { 
        new TOrigin Origin { get; }
        new TDestination Destination { get; }
    }
    public interface IClueLocation : IStaticGraphEdge<IRoom, IClue> { }
    public interface IDoor : IStaticGraphEdge<IRoom, IRoom> { }
    public interface IMetaLink : IStaticGraphEdge<IMeta, IStaticGraphNode> { }
    public interface IPuzzleLocation : IStaticGraphEdge<IRoom, IPuzzle> { }
    public interface IPuzzleRewardsClue : IStaticGraphEdge<IPuzzle, IClue> { }
    public interface IPuzzleRewardsPuzzle : IStaticGraphEdge<IPuzzle, IPuzzle> { }
    public interface IPuzzleRewardsRoom : IStaticGraphEdge<IPuzzle, IRoom> { }
    public interface IPuzzleRole : IStaticGraphEdge<IRole, IPuzzle> { }
    public interface IRequiredClue : IStaticGraphEdge<IClue, IRole> { }
    public interface IRequiredSkill : IStaticGraphEdge<ISkill, IRole> { }
    public interface IRoleLocation : IStaticGraphEdge<IRoom, IRole> { }
    public interface IStartingPosition : IStaticGraphEdge<IRole, IRoom> { }
}
