using GraphEG.Core.Graph;
using System;

namespace GraphEG.Core.DynamicGraph
{
    [Serializable]
    public class Player : Node, IPlayer
    {

        public bool HasExited { get; private set; } = false;

        public Player(string name) : base(name)
        {
        }

        public Player() : this(NameGenerator.GenerateName("P"))
        {
            
        }

        public void Exit()
        {
            HasExited = true;
        }
    }
}
