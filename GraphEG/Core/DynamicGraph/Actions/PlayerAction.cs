using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;

namespace GraphEG.Core.DynamicGraph.Actions
{
    /// <summary>
    /// An action executable by a player (or a group of players)
    /// </summary>
    [Serializable]
    public abstract class PlayerAction : IPlayerAction
    {
        public IPlayer Player { get; }
        public virtual IEnumerable<IPlayer> Players => new[] { Player };
        public bool Executed { get; private set; } = false;
        public abstract string Name { get; }
        public string ExecutionResult => $"{Name} = {ExecutionResultBuilder.BuildExecutionResult()}";
        protected ExecutionResultBuilder ExecutionResultBuilder { get; } = new ExecutionResultBuilder();
        protected IDynamicGraph Graph { get; private set; }

        public PlayerAction(IPlayer player)
        {
            Player = player;
        }
        public void Execute(IDynamicGraph graph)
        {
            ExecutionResultBuilder.Reset();
            Graph = graph;
            InternalExecute();
            Executed = true;
        }
        protected abstract void InternalExecute();

        protected void DiscoverNode(INode node)
        {
            ExecutionResultBuilder.AddNode(node);
            Graph.DiscoverNode(node);
        }

        protected void RemoveNode(INode node)
        {
            ExecutionResultBuilder.RemoveNode(node);
            Graph.RemoveNode(node);
        }

        protected void AddEdge(IDynamicEdge<INode> edge)
        {
            ExecutionResultBuilder.AddEdge(edge);
            Graph.AddEdge(edge);
        }

        protected void RemoveEdge(IDynamicEdge<INode> edge)
        {
            ExecutionResultBuilder.RemoveEdge(edge);
            Graph.RemoveEdge(edge);
        }
    }
}
