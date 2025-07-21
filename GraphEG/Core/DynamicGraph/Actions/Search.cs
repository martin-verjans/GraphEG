using GraphEG.Core.Graph;
using GraphEG.Core.StaticGraph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.DynamicGraph.Actions
{
    [Serializable]
    public class Search : PlayerAction
    {
        public IRoom CurrentPlayerRoom { get; }
        private INode discovery;
        List<IDynamicEdge<INode>> possibleDiscoveries;

        public override string Name => $"Search({Player})";

        private string found = "";
        public Search(IPlayer player, IRoom currentPlayerRoom) : base(player)
        {
            CurrentPlayerRoom = currentPlayerRoom;
        }
        protected override void InternalExecute()
        {
            possibleDiscoveries = new List<IDynamicEdge<INode>>();
            CheckRoomsToDiscover();
            CheckPuzzlesToDiscover();
            CheckCluesToDiscover();
            DiscoverOne();
        }

        private void CheckCluesToDiscover()
        {
            IEnumerable<IClue> clues = Graph.StaticGraph.FindAllConnected(CurrentPlayerRoom).OfType<Clue>().Except(Graph.DiscoveredNodes).OfType<IClue>();
            foreach (IClue c in clues)
            {
                possibleDiscoveries.Add(new ContainsClue(CurrentPlayerRoom, c));
            }
        }

        private void CheckPuzzlesToDiscover()
        {
            IEnumerable<IPuzzle> puzzles = Graph.StaticGraph
                .FindAllConnected(CurrentPlayerRoom)
                .OfType<IPuzzleLocation>()
                .Select(e => e.Destination)
                .Except(Graph.DiscoveredNodes)
                .OfType<IPuzzle>();
            foreach (IPuzzle p in puzzles)
            {
                possibleDiscoveries.Add(new ContainsPuzzle(CurrentPlayerRoom, p));
            }
        }

        private void CheckRoomsToDiscover()
        {
            //We look in the static graph for all rooms connected to this one
            IEnumerable<IDoor> doors = Graph.StaticGraph.Edges.OfType<IDoor>();
            IEnumerable<IRoom> connectedRooms = Graph
                .FindAllConnected(CurrentPlayerRoom)
                .OfType<ILeadsTo>()
                .Where(door => door.Origin == CurrentPlayerRoom)
                .Select(door => door.Destination);
            IEnumerable<IRoom> discoveredRooms = Graph.DiscoveredNodes.OfType<IRoom>();
            foreach (IDoor door in doors)
            {
                if (door.Origin != CurrentPlayerRoom) continue;
                if (connectedRooms.Contains(door.Destination)) continue;
                //We need to add a passage between current room and destination
                possibleDiscoveries.Add(new LeadsTo(CurrentPlayerRoom, door.Destination));
            }
        }

        private void DiscoverOne()
        {
            IDynamicEdge<INode> discovery = possibleDiscoveries.FirstOrDefault();
            if (discovery is null) return;
            Discover(discovery);
        }

        private void Discover(IDynamicEdge<INode> discovery)
        {
            AddEdge(discovery);
            this.discovery = discovery.Destination;
            DiscoverNode(this.discovery);
            found = DiscoveryText(discovery);
        }

        private string DiscoveryText(IEdge<INode> discovery)
        {
            if (discovery is ILeadsTo door) { return $"a door to room {door.Destination}"; }
            if (discovery is IContainsPuzzle puzzle) { return $"a puzzle {puzzle.Destination}"; }
            if (discovery is IContainsClue clue) { return $"a clue {clue.Destination}"; }
            return $"something unknown: {discovery.Name}";
        }

        public override string ToString()
        {
            if (Executed)
            {
                return $"Player {Player} found {found}.";
            }
            return $"Player {Player} can search Room {CurrentPlayerRoom}.";
        }
    }
}
