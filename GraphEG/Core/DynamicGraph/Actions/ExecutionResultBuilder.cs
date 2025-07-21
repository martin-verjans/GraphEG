using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.DynamicGraph.Actions
{
    [Serializable]
    public class ExecutionResultBuilder
    {
        private List<string> AddedNodes;
        private List<string> AddedEdges;
        private List<string> RemovedNodes;
        private List<string> RemovedEdges;

        public ExecutionResultBuilder()
        {
            Reset();
        }

        internal void Reset()
        {
            AddedNodes = new List<string>();
            AddedEdges = new List<string>();
            RemovedNodes = new List<string>();
            RemovedEdges = new List<string>();
        }

        public void AddNode(INode node)
        {
            AddedNodes.Add(node.Name);
        }

        public void AddEdge(IDynamicEdge<INode> edge)
        {
            AddedEdges.Add($"{edge.Origin.Name} -> {edge.Destination.Name}");
        }
        public void RemoveNode(INode node)
        {
            RemovedNodes.Add(node.Name);
        }
        public void RemoveEdge(IDynamicEdge<INode> edge)
        {
            RemovedEdges.Add($"{edge.Origin.Name} -> {edge.Destination.Name}");
        }

        public string BuildExecutionResult()
        {
            if (AllEmpty())
                return "Nothing";
            return $"[Add({BuildAdded()}); Remove({BuildRemoved()})]";
        }

        private bool AllEmpty()
        {
            return AddedNodes.Count() == 0
                && AddedEdges.Count() == 0
                && RemovedNodes.Count() == 0
                && RemovedEdges.Count() == 0;
        }

        private string BuildAdded()
        {
            return string.Join(", ", AddedNodes.Concat(AddedEdges));
        }

        private string BuildRemoved()
        {
            return $"{string.Join(", ", RemovedNodes.Concat(RemovedEdges))}";
        }
    }
}
