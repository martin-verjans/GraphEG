using GraphEG.Core.Graph;
using GraphEG.Core.StaticGraph;
using System.Collections.Generic;

namespace GraphEG.Core.DynamicGraph
{
    public interface IDynamicGraph 
        : IGraph<INode, IDynamicEdge<INode>, NodeSet<INode>, IDynamicEdgeSet<IDynamicEdge<INode>>>
    {
        IStaticGraph StaticGraph { get; }
        IEnumerable<IPlayer> Players { get; }
        IEnumerable<INode> DiscoveredNodes { get; }
        bool HavePlayersWon { get; }
        IActionGenerator ActionGenerator { get; set; }

        IPlayerActionSet GetPossibleActions();
        IDynamicGraph ExecuteAction(IPlayerAction action);
        void DiscoverNode(INode node);
        IDynamicGraph ExecuteMeta(IMetaFunction function);
    }
}
