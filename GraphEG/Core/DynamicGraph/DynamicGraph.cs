using GraphEG.Core.Graph;
using GraphEG.Core.StaticGraph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.DynamicGraph
{
    [Serializable]
    public class DynamicGraph : Graph.Graph, IDynamicGraph
    {
        private List<INode> discoveredNodes;
        public IStaticGraph StaticGraph { get; }

        public IEnumerable<INode> DiscoveredNodes => discoveredNodes;

        public bool HavePlayersWon { get; private set; } = false;

        public IEnumerable<IPlayer> Players => Nodes.OfType<IPlayer>();

        public new NodeSet<INode> Nodes => (NodeSet<INode>)base.Nodes;

        public new IDynamicEdgeSet<IDynamicEdge<INode>> Edges => (IDynamicEdgeSet<IDynamicEdge<INode>>)base.Edges;

        public IActionGenerator ActionGenerator { get; set; } = null;

        public DynamicGraph(IStaticGraph staticGraph, IEnumerable<IPlayer> players, IDynamicEdgeSet<IDynamicEdge<INode>> playerSkills)
            : base(new NodeSet<INode>(staticGraph.Nodes.Cast<INode>().Concat(players)), new DynamicEdgeSet(playerSkills))
        {
            StaticGraph = staticGraph;
            discoveredNodes = new List<INode>();
            discoveredNodes.AddRange(staticGraph.Edges.OfType<StartingPosition>().Select(sp => sp.Destination));
            LinkVictoryNodes();
        }

        private DynamicGraph(DynamicGraph toClone)
            : base(toClone.Nodes, (EdgeSet<IEdge<INode>>)toClone.Edges.Clone())
        {
            discoveredNodes = new List<INode>(toClone.DiscoveredNodes);
            StaticGraph = toClone.StaticGraph;
            HavePlayersWon = toClone.HavePlayersWon;
            ActionGenerator = toClone.ActionGenerator;
            LinkVictoryNodes();
        }

        private void LinkVictoryNodes()
        {
            IEnumerable<INode> victoryNodes = Nodes.Where(n => n is Meta m && m.MetaFunction is MetaVictory);
            foreach (INode node in victoryNodes)
            {
                Meta meta = node as Meta;
                ((MetaVictory)meta.MetaFunction).MetaEvent += VictoryEventReceived;
            }
        }

        private void VictoryEventReceived(object sender, EventArgs e)
        {
            if (e is VictoryEventArgs)
            {
                HavePlayersWon = true;
            }
        }

        public IPlayerActionSet GetPossibleActions()
        {
            return ActionGenerator?.GenerateActions(this);
        }

        public IDynamicGraph ExecuteAction(IPlayerAction action)
        {
            DynamicGraph newGraph = new DynamicGraph(this);
            action.Execute(newGraph);
            return newGraph;
        }

        public IDynamicGraph ExecuteMeta(IMetaFunction function)
        {
            DynamicGraph newGraph = new DynamicGraph(this);
            function.Execute(newGraph);
            return newGraph;
        }

        public void DiscoverNode(INode node)
        {
            if (discoveredNodes.Contains(node))
                return;
            discoveredNodes.Add(node);
        }
    }
}
