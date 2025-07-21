using GraphEG.Core.Graph;

namespace GraphEG.Core.DynamicGraph
{
    public interface IPlayer : INode
    {
        bool HasExited { get; }
        void Exit();
    }
}
