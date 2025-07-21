using GraphEG.Core.Graph;

namespace GraphEG.Core.StaticGraph
{
    public interface IStaticGraphNodeSet<TNode> : INodeSet<TNode> where TNode : IStaticGraphNode { }
    public interface IClueSet : IStaticGraphNodeSet<IClue> { }
    public interface IMetaSet : IStaticGraphNodeSet<IMeta> { }
    public interface IPuzzleSet : IStaticGraphNodeSet<IPuzzle> { }
    public interface IRoleSet : IStaticGraphNodeSet<IRole> { }
    public interface IRoomSet : IStaticGraphNodeSet<IRoom> { }
    public interface ISkillSet : IStaticGraphNodeSet<ISkill> { }
}
