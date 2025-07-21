using GraphEG.Core.Graph;
using GraphEG.Core.StaticGraph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.DynamicGraph.Actions
{
    [Serializable]
    public class Attempt : PlayerAction
    {
        public override IEnumerable<IPlayer> Players { get; }
        public IPuzzle Puzzle { get; }
        public bool Succeed { get; private set; }
        public string Missing { get; private set; }
        private IRoom currentPuzzleRoom;

        public override string Name => $"Attempt([{string.Join(", ", Players)}], {Puzzle})";

        public Attempt(IEnumerable<IPlayer> players, IPuzzle puzzle) : base(players.First())
        {
            Players = players;
            Puzzle = puzzle;
        }

        protected override void InternalExecute()
        {
            IEnumerable<Role> roles = Graph.StaticGraph.FindAllConnected(Puzzle).OfType<Role>();
            if (!CheckPlayerCount(roles)) return;
            IDictionary<Role, IEnumerable<INode>> roleRequirementSet = BuildRoleRequirements(roles);
            IDictionary<IPlayer, IEnumerable<INode>> playerCapabilitySet = BuildPlayerCapabilities();
            List<IEdge<INode>> edges = new List<IEdge<INode>>();
            foreach (KeyValuePair<IPlayer, IEnumerable<INode>> kvpPlayer in playerCapabilitySet)
            {
                foreach (KeyValuePair<Role, IEnumerable<INode>> kvpRole in roleRequirementSet)
                {
                    if(kvpRole.Value.Except(kvpPlayer.Value).Count() == 0)
                    {
                        //This player possesses everything required for this role
                        edges.Add(new Edge<INode>(NameGenerator.GenerateName("BP"), kvpPlayer.Key, kvpRole.Key));
                    }
                }
            }
            MaxCouplingFinder maxCouplingFinder = new MaxCouplingFinder(playerCapabilitySet.Keys.ToArray(), roleRequirementSet.Keys.ToArray(), edges);
            int maxCoupling = maxCouplingFinder.FindMaxCoupling();
            if (maxCoupling == roleRequirementSet.Keys.Count)
            {
                //The puzzle is solved
                SolvePuzzle(roleRequirementSet.SelectMany(r => r.Value.OfType<Clue>()));
            }
            else
            {
                //Requirements are not met
                Missing = "some puzzle requirements";
            }
        }

        private void SolvePuzzle(IEnumerable<IClue> clues)
        {
            Succeed = true;
            //First, place the reward in the current puzzle room & discover it
            currentPuzzleRoom = Graph.Edges.OfType<IContainsPuzzle>().First(cp => cp.Destination.Equals(Puzzle)).Origin;
            IEnumerable<IPuzzleRewardsRoom> rewardRoom = Graph.StaticGraph.Edges.OfType<IPuzzleRewardsRoom>().Where(pr => pr.Origin.Equals(Puzzle));
            foreach(IPuzzleRewardsRoom room in rewardRoom)
            {
                AddEdge(new LeadsTo(currentPuzzleRoom, room.Destination));
                DiscoverNode(room.Destination);
            }
            IEnumerable<IPuzzleRewardsClue> rewardClue = Graph.StaticGraph.Edges.OfType<IPuzzleRewardsClue>().Where(pr => pr.Origin.Equals(Puzzle));
            foreach (IPuzzleRewardsClue clue in rewardClue)
            {
                AddEdge(new ContainsClue(currentPuzzleRoom, clue.Destination));
                DiscoverNode(clue.Destination);
            }
            IEnumerable<IPuzzleRewardsPuzzle> rewardPuzzle = Graph.StaticGraph.Edges.OfType<IPuzzleRewardsPuzzle>().Where(pr => pr.Origin.Equals(Puzzle));
            foreach (IPuzzleRewardsPuzzle puzzle in rewardPuzzle)
            {
                AddEdge(new ContainsPuzzle(currentPuzzleRoom, puzzle.Destination));
                DiscoverNode(puzzle.Destination);
            }
            //Then, we can remove the puzzle node and all the clues related to it
            RemoveNode(Puzzle);
            foreach(IClue clue in clues)
            {
                RemoveNode(clue);
            }
        }

        private IDictionary<IPlayer, IEnumerable<INode>> BuildPlayerCapabilities()
        {
            Dictionary<IPlayer, IEnumerable<INode>> capabilities = new Dictionary<IPlayer, IEnumerable<INode>>();
            foreach (IPlayer player in Players)
            {
                IEnumerable<INode> playerCapabities = Graph
                    .FindAllConnected(player)
                    .OfType<INode>()
                    .Where(item => item is Clue || item is Room || item is Skill);
                capabilities.Add(player, playerCapabities);
            }
            return capabilities;
        }

        private IDictionary<Role, IEnumerable<INode>> BuildRoleRequirements(IEnumerable<Role> roles)
        {
            Dictionary<Role, IEnumerable<INode>> requirements = new Dictionary<Role, IEnumerable<INode>>();
            foreach (Role role in roles)
            {
                IEnumerable<INode> roleRequirements = Graph.StaticGraph
                    .FindAllConnected(role)
                    .OfType<INode>()
                    .Where(item => item is Clue || item is Room || item is Skill);
                requirements.Add(role, roleRequirements);
            }
            return requirements;
        }

        private bool CheckPlayerCount(IEnumerable<Role> roles)
        {
            if (Players.Count() >= roles.Count())
                return true;
            Missing = $"some players";
            return false;
        }

        public override string ToString()
        {
            if (!Executed)
            {
                return $"Players [{string.Join(", ", Players)}] can attempt to solve Puzzle {Puzzle}.";
            }
            if (Succeed)
            {
                return $"Players [{string.Join(", ", Players)}] solved Puzzle {Puzzle}.";
            }
            return $"Players [{string.Join(", ", Players)}] did not solve Puzzle {Puzzle}, it seems {Missing} are missing.";
        }
    }
}
