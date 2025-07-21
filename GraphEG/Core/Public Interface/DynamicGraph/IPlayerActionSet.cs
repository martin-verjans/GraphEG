using System.Collections.Generic;

namespace GraphEG.Core.DynamicGraph
{
    public interface IPlayerActionSet : IEnumerable<IPlayerAction>
    {
        bool IsSetComplete { get; }
    }
}
