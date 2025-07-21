using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.DynamicGraph.Actions.Generator
{
    /// <summary>
    /// This generator is given to the Dynamic graph. It only contains all other generators.
    /// It does not generate any action.
    /// </summary>
    [Serializable]
    public class MainActionGenerator : ActionGenerator
    {
        public IEnumerable<IActionGenerator> Generators { get; }

        public MainActionGenerator(IEnumerable<IActionGenerator> generators)
        {
            Generators = generators;
        }

        protected override void GenerateActions()
        {
            List<IPlayerActionSet> actions = new List<IPlayerActionSet>();
            foreach (IActionGenerator generator in Generators)
            {
                IPlayerActionSet actionSet = generator.GenerateActions(Graph);
                actions.Add(actionSet);
                if (actionSet.IsSetComplete)
                    break;
            }
            Actions.AddRange(actions.SelectMany(a => a));
        }        
    }
}
