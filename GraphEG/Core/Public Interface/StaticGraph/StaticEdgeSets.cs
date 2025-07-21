using GraphEG.Core.Graph;

namespace GraphEG.Core.StaticGraph
{
    public interface IStaticGraphEdgeSet<TEdge> :
        IEdgeSet<TEdge>
        where TEdge : IStaticGraphEdge<IStaticGraphNode>
    { }

    //public interface IStaticGraphEdgeSet<TEdge, TOrigin, TDestination> :
    //    IStaticGraphEdgeSet<TEdge>,
    //    IEdgeSet<TEdge, TOrigin, TDestination>
    //    where TOrigin : IStaticGraphNode
    //    where TDestination : IStaticGraphNode
    //    where TEdge : IStaticGraphEdge<TOrigin, TDestination>
    //{ }

    public interface IClueLocationSet : IStaticGraphEdgeSet<IClueLocation> { }
    public interface IDoorSet : IStaticGraphEdgeSet<IDoor> { }
    public interface IMetaLinkSet : IStaticGraphEdgeSet<IMetaLink> { }
    public interface IPuzzleLocationSet : IStaticGraphEdgeSet<IPuzzleLocation> { }
    public interface IPuzzleRewardsClueSet : IStaticGraphEdgeSet<IPuzzleRewardsClue> { }
    public interface IPuzzleRewardsPuzzleSet : IStaticGraphEdgeSet<IPuzzleRewardsPuzzle> { }
    public interface IPuzzleRewardsRoomSet : IStaticGraphEdgeSet<IPuzzleRewardsRoom> { }
    public interface IPuzzleRoleSet : IStaticGraphEdgeSet<IPuzzleRole> { }
    public interface IRequiredClueSet : IStaticGraphEdgeSet<IRequiredClue> { }
    public interface IRequiredSkillSet : IStaticGraphEdgeSet<IRequiredSkill> { }
    public interface IRoleLocationSet : IStaticGraphEdgeSet<IRoleLocation> { }
    public interface IStartingPositionSet : IStaticGraphEdgeSet<IStartingPosition> { }
}
