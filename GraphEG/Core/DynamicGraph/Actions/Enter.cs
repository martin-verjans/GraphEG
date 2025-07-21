using GraphEG.Core.StaticGraph;
using System;

namespace GraphEG.Core.DynamicGraph.Actions
{
    [Serializable]
    public class Enter : PlayerAction
    {
        public IRoom Room { get; }

        public override string Name => $"Enter({Player}, {Room})";

        public Enter(IPlayer p, IRoom room) : base(p)
        {
            Room = room;
        }

        protected override void InternalExecute()
        {
            //We simply add one edge of type player location
            ContainsPlayer containsPlayer = new ContainsPlayer(Room, Player);
            AddEdge(containsPlayer);
            DiscoverNode(Room);
        }

        public override string ToString()
        {
            return $"Player {Player.Name} {(Executed ? "started" : "can start")} the game in room {Room.Name}";
        }
    }
}
