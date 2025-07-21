using GraphEG.Core.Graph;

namespace GraphEG.Core.StaticGraph
{
    public interface IStaticGraph : 
        IGraph<
            IStaticGraphNode, 
            IStaticGraphEdge<IStaticGraphNode>, 
            IStaticGraphNodeSet<IStaticGraphNode>, 
            IStaticGraphEdgeSet<IStaticGraphEdge<IStaticGraphNode>>
            >
    {
        IClueSet ClueSet { get; }
        IMetaSet MetaSet { get; }
        IPuzzleSet PuzzleSet { get; }
        IRoleSet RoleSet { get; }
        IRoomSet RoomSet { get; }
        ISkillSet SkillSet { get; }

        IClueLocationSet ClueLocationSet { get; }
        IDoorSet DoorSet { get; }
        IMetaLinkSet MetaLinkSet { get; }
        IPuzzleLocationSet PuzzleLocationSet { get; }
        IPuzzleRewardsClueSet PuzzleRewardsClueSet { get; }
        IPuzzleRewardsPuzzleSet PuzzleRewardsPuzzleSet { get; }
        IPuzzleRewardsRoomSet PuzzleRewardsRoomSet { get; }
        IPuzzleRoleSet PuzzleRoleSet { get; }
        IRequiredClueSet RequiredClueSet { get; }
        IRequiredSkillSet RequiredSkillSet { get; }
        IRoleLocationSet RoleLocationSet { get; }
        IStartingPositionSet StartingPositionSet { get; }

        void LinkNodes(IStaticGraphNode origin, IStaticGraphNode destination);
    }
}
