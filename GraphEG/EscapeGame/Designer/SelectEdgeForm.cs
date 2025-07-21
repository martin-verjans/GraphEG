using GraphEG.Core.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GraphEG.EscapeGame
{
    public partial class SelectEdgeForm : Form
    {
        public IEdge<INode> SelectedEdge => (IEdge<INode>)lbEdges.SelectedItem;

        public SelectEdgeForm()
        {
            InitializeComponent();
        }

        public void SetNodes(IEnumerable<IEdge<INode>> nodes)
        {
            lbEdges.Items.Clear();
            lbEdges.Items.AddRange(nodes.ToArray());
        }

        private void lbNodes_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
