using GraphEG.Core.DynamicGraph;
using System;
using System.Linq;

namespace GraphEG.Core.StaticGraph
{
    [Serializable]
    public class VictoryEventArgs : EventArgs
    {

    }
    [Serializable]
    public class MetaVictory : MetaFunction
    {
        public MetaVictory() 
            : base("victory", 0, true)
        {
        }

        protected override bool Condition(IDynamicGraph graph)
        {
            return !graph.Edges.Any(e => e.Origin is Player || e.Destination is Player);
        }

        protected override void Action(IDynamicGraph graph)
        {
            Log("Players won the game");
            RaiseMetaEvent(new VictoryEventArgs());
        }
    }
}
