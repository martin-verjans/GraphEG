using GraphEG.Core.DynamicGraph;
using System;

namespace GraphEG.EscapeGame
{
    public class ActionSelectedEventArgs : EventArgs
    {
        public IPlayerAction SelectedAction { get; }
        public ActionSelectedEventArgs(IPlayerAction action)
        {
            SelectedAction = action;
        }
    }
}
