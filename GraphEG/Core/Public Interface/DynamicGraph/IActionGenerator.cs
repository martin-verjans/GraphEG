namespace GraphEG.Core.DynamicGraph
{
    public interface IActionGenerator
    {

        int GenerationOrder { get; }
        IPlayerActionSet GenerateActions(IDynamicGraph graph);
    }
}
