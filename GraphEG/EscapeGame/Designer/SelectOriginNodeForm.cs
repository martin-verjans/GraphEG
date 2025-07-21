using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GraphEG.EscapeGame
{
    public partial class SelectOriginNodeForm : Form
    {
        public INode SelectedNode => (INode)lbNodes.SelectedItem;

        public SelectOriginNodeForm()
        {
            InitializeComponent();
        }

        public void SetNodes(IEnumerable<INode> nodes)
        {
            lbNodes.Items.Clear();
            lbNodes.Items.AddRange(nodes.ToArray());
        }

        private void lbNodes_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
