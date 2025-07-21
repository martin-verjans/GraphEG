using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class StaticGraphEdgeSet<T> : EdgeSet<IEdge<INode>>, IStaticGraphEdgeSet<T> 
        where T : IStaticGraphEdge<IStaticGraphNode>
    {
        public StaticGraphEdgeSet() : base() { }
        public StaticGraphEdgeSet(IEnumerable<T> items) : base(items.Cast<IStaticGraphEdge<IStaticGraphNode>>()) { }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return Items.Cast<T>().GetEnumerator();
        }
    }
    [Serializable]
    public class ClueLocationSet : StaticGraphEdgeSet<IClueLocation>, IClueLocationSet
    {
        public ClueLocationSet(IEnumerable<IClueLocation> items) : base(items) { }
    }
    [Serializable]
    public class DoorSet : StaticGraphEdgeSet<IDoor>, IDoorSet
    {
        public DoorSet(IEnumerable<IDoor> items) : base(items) { }
    }
    [Serializable]
    public class MetaLinkSet : StaticGraphEdgeSet<IMetaLink>, IMetaLinkSet
    {
        public MetaLinkSet(IEnumerable<IMetaLink> items) : base(items) { }
    }
    [Serializable]
    public class PuzzleLocationSet : StaticGraphEdgeSet<IPuzzleLocation>, IPuzzleLocationSet
    {
        public PuzzleLocationSet(IEnumerable<IPuzzleLocation> items) : base(items) { }
    }
    [Serializable]
    public class PuzzleRewardsClueSet : StaticGraphEdgeSet<IPuzzleRewardsClue>, IPuzzleRewardsClueSet
    {
        public PuzzleRewardsClueSet(IEnumerable<IPuzzleRewardsClue> items) : base(items) { }
    }
    [Serializable]
    public class PuzzleRewardsPuzzleSet : StaticGraphEdgeSet<IPuzzleRewardsPuzzle>, IPuzzleRewardsPuzzleSet
    {
        public PuzzleRewardsPuzzleSet(IEnumerable<IPuzzleRewardsPuzzle> items) : base(items) { }
    }
    [Serializable]
    public class PuzzleRewardsRoomSet : StaticGraphEdgeSet<IPuzzleRewardsRoom>, IPuzzleRewardsRoomSet
    {
        public PuzzleRewardsRoomSet(IEnumerable<IPuzzleRewardsRoom> items) : base(items) { }
    }
    [Serializable]
    public class PuzzleRoleSet : StaticGraphEdgeSet<IPuzzleRole>, IPuzzleRoleSet
    {
        public PuzzleRoleSet(IEnumerable<IPuzzleRole> items) : base(items) { }
    }
    [Serializable]
    public class RequiredClueSet : StaticGraphEdgeSet<IRequiredClue>, IRequiredClueSet
    {
        public RequiredClueSet(IEnumerable<IRequiredClue> items) : base(items) { }
    }
    [Serializable]
    public class RequiredSkillSet : StaticGraphEdgeSet<IRequiredSkill>, IRequiredSkillSet
    {
        public RequiredSkillSet(IEnumerable<IRequiredSkill> items) : base(items) { }
    }
    [Serializable]
    public class RoleLocationSet : StaticGraphEdgeSet<IRoleLocation>, IRoleLocationSet
    {
        public RoleLocationSet(IEnumerable<IRoleLocation> items) : base(items) { }
    }
    [Serializable]
    public class StartingPositionSet : StaticGraphEdgeSet<IStartingPosition>, IStartingPositionSet
    {
        public StartingPositionSet(IEnumerable<IStartingPosition> items) : base(items) { }
    }
}
