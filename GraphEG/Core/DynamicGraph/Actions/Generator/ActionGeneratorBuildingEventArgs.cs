using System.Collections.Generic;

namespace GraphEG.Core.DynamicGraph.Actions.Generator
{
    /// <summary>
    /// Event Args use to add your own action generators to the stanadard ones (or replace them)
    /// </summary>
    public class ActionGeneratorBuildingEventArgs
    {
        public List<IActionGenerator> ActionGenerators { get; }
        public ActionGeneratorBuildingEventArgs(List<IActionGenerator> actionGenerators)
        {
            ActionGenerators = actionGenerators;
        }
    }
}
