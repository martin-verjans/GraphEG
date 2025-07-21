using System;
using System.Collections.Generic;

namespace GraphEG.Core.DynamicGraph.Actions.Generator
{
    /// <summary>
    /// If you want to generate your own action set, implement this class and add it
    /// when <see cref="ActionGeneratorBuilder.ActionGeneratorBuilding"/> event fires.
    /// </summary>
    [Serializable]
    public abstract class ActionGenerator : IActionGenerator
    {
        public virtual int GenerationOrder => 1;
        protected List<IPlayerAction> Actions { get; private set; }
        protected IDynamicGraph Graph { get; private set; }

        public IPlayerActionSet GenerateActions(IDynamicGraph graph)
        {
            Actions = new List<IPlayerAction>();
            Graph = graph;
            GenerateActions();
            return new PlayerActionSet(Actions);
        }

        protected abstract void GenerateActions();
    }
}
