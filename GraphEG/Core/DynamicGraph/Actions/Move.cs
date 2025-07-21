using GraphEG.Core.StaticGraph;
using System;
using System.Linq;

namespace GraphEG.Core.DynamicGraph.Actions
{
    [Serializable]
    public class Move : PlayerAction
    {
        public IRoom CurrentRoom { get; }
        public IRoom NewRoom { get; }

        public override string Name => $"Move({Player}, {NewRoom})";

        public Move(IPlayer player, IRoom currentRoom, IRoom newRoom) : base(player)
        {
            CurrentRoom = currentRoom;
            NewRoom = newRoom;
        }

        protected override void InternalExecute()
        {
            IContainsPlayer currentPlayerLocation = Graph.Edges.OfType<IContainsPlayer>().First(cp => cp.Destination == Player);
            RemoveEdge(currentPlayerLocation);
            AddEdge(new ContainsPlayer(NewRoom, Player));
        }

        public override string ToString()
        {
            return $"Player {Player} {(Executed ? "moved" : "can move")} from Room {CurrentRoom} to Room {NewRoom}";
        }
    }
}
