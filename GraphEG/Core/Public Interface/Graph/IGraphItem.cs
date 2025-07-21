using System;

namespace GraphEG.Core.Graph
{
    public interface IGraphItem : IEquatable<IGraphItem>, IComparable<IGraphItem>
    {
        int Id { get; }
        string Name { get; }
    }
}
