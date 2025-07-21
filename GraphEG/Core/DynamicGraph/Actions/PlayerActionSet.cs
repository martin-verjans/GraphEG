using System;
using System.Collections.Generic;

namespace GraphEG.Core.DynamicGraph.Actions
{
    [Serializable]
    internal class PlayerActionSet : List<IPlayerAction>, IPlayerActionSet
    {
        public bool IsSetComplete { get; }

        public PlayerActionSet(IEnumerable<IPlayerAction> actions, bool setIsComplete = false)
            : base(actions)
        {
            IsSetComplete = setIsComplete;
        }
        IEnumerator<IPlayerAction> IEnumerable<IPlayerAction>.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
