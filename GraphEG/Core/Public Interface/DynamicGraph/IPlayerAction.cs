namespace GraphEG.Core.DynamicGraph
{
    public interface IPlayerAction
    {
        IPlayer Player { get; }
        string Name { get; }
        string ExecutionResult { get; }
        bool Executed { get; }
        void Execute(IDynamicGraph graph);
    }
}
