using GraphEG.Core.DynamicGraph;
using GraphEG.EscapeGame.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GraphEG.EscapeGame
{
    public partial class GameEngineForm : Form
    {
        public event EventHandler<ActionSelectedEventArgs> ActionSelected;

        private GraphDisplay graphDisplay;

        public GameEngineForm()
        {
            InitializeComponent();
        }

        public void AddToHistory(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AddToHistory(data)));
                return;
            }
            rtbHistory.Text = rtbHistory.Text.Insert(0, $"{data}{Environment.NewLine}");
        }

        public void AddToHistory(IEnumerable<string> data)
        {
            AddToHistory(string.Join(Environment.NewLine, data.Reverse()));
        }

        public void DisplayAction(IPlayerActionSet actionSet)
        {
            lbActionList.Items.Clear();
            lbActionList.Items.AddRange(actionSet.ToArray());
        }

        public void DisplayGraph(IDynamicGraph graph)
        {
            if (graph is null) 
                return;
            graphDisplay = new DynamicGraphDisplay(GraphDisplayOptions.Default);
            graphDisplay.RefreshGraph(graph);
            pbGraph.Image = graphDisplay.LastGeneratedImage;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (lbActionList.SelectedItem is null)
                return;
            ActionSelected?.Invoke(this, new ActionSelectedEventArgs((IPlayerAction)lbActionList.SelectedItem));
        }
    }
}
