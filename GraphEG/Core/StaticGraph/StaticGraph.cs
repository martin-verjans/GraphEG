using System;
using System.Linq;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class StaticGraph : Graph.Graph, IStaticGraph
    {

        public StaticGraph() : base(new StaticGraphNodeSet<IStaticGraphNode>(), new StaticGraphEdgeSet<IStaticGraphEdge<IStaticGraphNode>>())
        {

        }

        public StaticGraph(StaticGraphNodeSet<IStaticGraphNode> nodes, StaticGraphEdgeSet<IStaticGraphEdge<IStaticGraphNode>> edges)
            : base(nodes, edges) { }

        public IClueSet ClueSet => new ClueSet(Nodes.OfType<IClue>());

        public IMetaSet MetaSet => new MetaSet(Nodes.OfType<IMeta>());

        public IPuzzleSet PuzzleSet => new PuzzleSet(Nodes.OfType<IPuzzle>());

        public IRoleSet RoleSet => new RoleSet(Nodes.OfType<IRole>());

        public IRoomSet RoomSet => new RoomSet(Nodes.OfType<IRoom>());

        public ISkillSet SkillSet => new SkillSet(Nodes.OfType<ISkill>());

        public IClueLocationSet ClueLocationSet => new ClueLocationSet(Edges.OfType<IClueLocation>());

        public IDoorSet DoorSet => new DoorSet(Edges.OfType<IDoor>());

        public IMetaLinkSet MetaLinkSet => new MetaLinkSet(Edges.OfType<IMetaLink>());

        public IPuzzleLocationSet PuzzleLocationSet => new PuzzleLocationSet(Edges.OfType<IPuzzleLocation>());

        public IPuzzleRewardsClueSet PuzzleRewardsClueSet => new PuzzleRewardsClueSet(Edges.OfType<IPuzzleRewardsClue>());

        public IPuzzleRewardsPuzzleSet PuzzleRewardsPuzzleSet => new PuzzleRewardsPuzzleSet(Edges.OfType<IPuzzleRewardsPuzzle>());

        public IPuzzleRewardsRoomSet PuzzleRewardsRoomSet => new PuzzleRewardsRoomSet(Edges.OfType<IPuzzleRewardsRoom>());

        public IPuzzleRoleSet PuzzleRoleSet => new PuzzleRoleSet(Edges.OfType<IPuzzleRole>());

        public IRequiredClueSet RequiredClueSet => new RequiredClueSet(Edges.OfType<IRequiredClue>());

        public IRequiredSkillSet RequiredSkillSet => new RequiredSkillSet(Edges.OfType<IRequiredSkill>());

        public IRoleLocationSet RoleLocationSet => new RoleLocationSet(Edges.OfType<IRoleLocation>());

        public IStartingPositionSet StartingPositionSet => new StartingPositionSet(Edges.OfType<IStartingPosition>());

        public new IStaticGraphNodeSet<IStaticGraphNode> Nodes => (IStaticGraphNodeSet<IStaticGraphNode>)base.Nodes;

        public new IStaticGraphEdgeSet<IStaticGraphEdge<IStaticGraphNode>> Edges => (IStaticGraphEdgeSet<IStaticGraphEdge<IStaticGraphNode>>)base.Edges;

        public void LinkNodes(IStaticGraphNode origin, IStaticGraphNode destination)
        {
            IStaticGraphEdge<IStaticGraphNode> edge = CreateEdge(origin, destination);
            AddEdge(edge);
        }

        private IStaticGraphEdge<IStaticGraphNode> CreateEdge(IStaticGraphNode origin, IStaticGraphNode destination)
        {
            if (origin is Room room)
            {
                if (destination is Room room2) { return new Door(room, room2); }
                if (destination is Clue clue2) { return new ClueLocation(room, clue2); }
                if (destination is Puzzle puzzle2) { return new PuzzleLocation(room, puzzle2); }
                if (destination is Role role2) { return new RoleLocation(room, role2); }
            }
            if (origin is Skill skill)
            {
                if (destination is Role role2) { return new RequiredSkill(skill, role2); }
            }
            if (origin is Clue clue)
            {
                if (destination is Role role2) { return new RequiredClue(clue, role2); }
            }
            if (origin is Role role)
            {
                if (destination is Puzzle puzzle2) { return new PuzzleRole(role, puzzle2); }
                if (destination is Room room2) { return new StartingPosition(role, room2); }
            }
            if (origin is Puzzle puzzle)
            {
                if (destination is Puzzle puzzle2) { return new PuzzleRewardsPuzzle(puzzle, puzzle2); }
                if (destination is Clue clue2) { return new PuzzleRewardsClue(puzzle, clue2); }
                if (destination is Room room2) { return new PuzzleRewardsRoom(puzzle, room2); }
            }
            if (origin is Meta meta)
            {
                return new MetaLink(meta.MetaFunction.FunctionName, meta, destination);
            }
            throw new Exception("This link is not allowed");
        }
    }
}
