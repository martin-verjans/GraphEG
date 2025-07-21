using System;

namespace GraphEG.Core.Graph
{
    [Serializable]
    public abstract class GraphItem : IGraphItem
    {
        private static int nextId = 1;
        private static int GetNextId()
        {
            return nextId++;
        }
        /// <summary>
        /// Unique object identifier accross run-time, this value should not be saved in a file
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Node's name, should be unique accross one application. 2 nodes having the same name
        /// means it's the same node but belonging to a different graph. Their IDs will however be different.
        /// </summary>
        public string Name { get; }

        protected GraphItem()
        {
            Id = GetNextId();
            Name = Id.ToString();
        }

        protected GraphItem(string name)
        {
            Id = GetNextId();
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return obj is GraphItem item ? Equals(item) : base.Equals(obj);
        }

        public bool Equals(IGraphItem other)
        {
            if (other is null) return false;
            return Name == other.Name;
        }

        public int CompareTo(IGraphItem other)
        {
            return Name.CompareTo(other.Name);
        }

        public static bool operator ==(GraphItem left, GraphItem right)
        {
            return (left is null) ? right is null : left.Equals(right);
        }

        public static bool operator !=(GraphItem left, GraphItem right)
        {
            return (left is null) ? !(right is null) : !left.Equals(right);
        }

        public static bool operator ==(IGraphItem left, GraphItem right)
        {
            return (left is null) ? right is null : left.Equals(right);
        }

        public static bool operator !=(IGraphItem left, GraphItem right)
        {
            return (left is null) ? !(right is null) : !left.Equals(right);
        }
        public static bool operator ==(GraphItem left, IGraphItem right)
        {
            return (left is null) ? right is null : left.Equals(right);
        }

        public static bool operator !=(GraphItem left, IGraphItem right)
        {
            return (left is null) ? !(right is null) : !left.Equals(right);
        }
    }
}
