using System.Collections.Generic;

namespace GraphEG.Core.Graph
{
    public interface IGraphItemSet<T> : IEnumerable<T> where T : IGraphItem
    {
    }
}
