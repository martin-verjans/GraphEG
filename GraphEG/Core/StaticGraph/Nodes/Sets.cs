using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class StaticGraphNodeSet<T> : NodeSet<INode>, IStaticGraphNodeSet<T> where T : IStaticGraphNode
    {
        public StaticGraphNodeSet() : base() { }
        public StaticGraphNodeSet(IEnumerable<T> items) : base(items.Cast<INode>()) { }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return Items.Cast<T>().GetEnumerator();
        }
    }
    [Serializable]
    public class ClueSet : StaticGraphNodeSet<IClue>, IClueSet
    {
        public ClueSet(IEnumerable<IClue> items) : base(items)
        {
        }
    }
    [Serializable]
    public class MetaSet : StaticGraphNodeSet<IMeta>, IMetaSet
    {
        public MetaSet(IEnumerable<IMeta> items) : base(items)
        {
        }
    }
    [Serializable]
    public class PuzzleSet : StaticGraphNodeSet<IPuzzle>, IPuzzleSet
    {
        public PuzzleSet(IEnumerable<IPuzzle> items) : base(items)
        {
        }
    }
    [Serializable]
    public class RoleSet : StaticGraphNodeSet<IRole>, IRoleSet
    {
        public RoleSet(IEnumerable<IRole> items) : base(items)
        {
        }
    }
    [Serializable]
    public class RoomSet : StaticGraphNodeSet<IRoom>, IRoomSet
    {
        public RoomSet(IEnumerable<IRoom> items) : base(items)
        {
        }
    }
    [Serializable]
    public class SkillSet : StaticGraphNodeSet<ISkill>, ISkillSet
    {
        public SkillSet(IEnumerable<ISkill> items) : base(items)
        {
        }
    }
}
