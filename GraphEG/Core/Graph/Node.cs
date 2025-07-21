using System;

namespace GraphEG.Core.Graph
{
    [Serializable]
    public abstract class Node : GraphItem, INode
    {
        internal Node(string name)
            : base(name)
        {
        }

        public virtual string GenerateParameters()
        {
            return string.Empty;
        }
    }
}
