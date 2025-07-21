using System;
using System.Collections.Generic;

namespace GraphEG.Core.DynamicGraph.Actions.Generator
{
    /// <summary>
    /// Builder that will generate a list of action Generator. 
    /// You can create your own generators by listening to the event <see cref="ActionGeneratorBuilding"/>
    /// </summary>
    [Serializable]
    public class ActionGeneratorBuilder
    {
        private List<IActionGenerator> generators;
        public event EventHandler<ActionGeneratorBuildingEventArgs> ActionGeneratorBuilding;
        public ActionGeneratorBuilder() { }

        public IActionGenerator Build()
        {
            generators = new List<IActionGenerator>();

            GenerateStandardActions();
            ActionGeneratorBuilding?.Invoke(this, new ActionGeneratorBuildingEventArgs(generators));

            return new MainActionGenerator(generators);
        }

        private void GenerateStandardActions()
        {
            generators.AddRange(new IActionGenerator[]
            {
                new EnterActionGenerator(),
                new MoveActionGenerator(),
                new SearchActionGenerator(),
                new ClueActionGenerator(),
                new AttemptActionGenerator()
            });
        }
    }
}
