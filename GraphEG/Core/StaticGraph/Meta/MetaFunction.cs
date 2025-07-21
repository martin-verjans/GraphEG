using GraphEG.Core.DynamicGraph;
using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;

namespace GraphEG.Core.StaticGraph
{
    public interface IMetaFunction
    {
        INode MetaNode { get; set; }
        string FunctionName { get; }
        int ExecutionOrder { get; }
        bool ShouldTrigger(IDynamicGraph graph);
        void Execute(IDynamicGraph graph);

        event EventHandler MetaEvent;
    }
    [Serializable]
    public abstract class MetaFunction : IMetaFunction
    {
        public INode MetaNode { get; set; }
        public string FunctionName { get; }
        public int ExecutionOrder { get; }
        protected bool ShouldRepeat { get; }
        private List<string> logs;
        
        private bool executed = false;

        public event EventHandler MetaEvent;

        public MetaFunction(string name, int executionOrder, bool repeatable) 
        {
            logs = new List<string>();
            FunctionName = name;
            ShouldRepeat  = repeatable;
            ExecutionOrder = executionOrder;
        }

        public void Execute(IDynamicGraph graph)
        {
            if (logs is null) logs = new List<string>();
            logs.Clear();
            if (executed && !ShouldRepeat)
                return;
            Action(graph);
            executed = true;
        }

        public bool ShouldTrigger(IDynamicGraph graph)
        {
            if (executed && !ShouldRepeat)
                return false;
            return Condition(graph);
        }

        protected void Log(string log)
        {
            logs.Add(log);
        }

        protected void RaiseMetaEvent(EventArgs e)
        {
            MetaEvent?.Invoke(this, e);
        }

        protected abstract bool Condition(IDynamicGraph graph);
        protected abstract void Action(IDynamicGraph graph);

        public override string ToString()
        {
            if (logs.Count == 0)
            {
                return $"Meta {this.FunctionName}";
            }
            return string.Join(" ", logs);
        }
    }
}
