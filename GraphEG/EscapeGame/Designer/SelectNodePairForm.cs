using GraphEG.Core.StaticGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GraphEG.EscapeGame
{
    public partial class SelectNodePairForm : Form
    {
        public IStaticGraphNode SelectedOrigin => lbOrigin.SelectedItem as IStaticGraphNode;
        public IStaticGraphNode SelectedDestination => lbDestination.SelectedItem as IStaticGraphNode;

        private IStaticGraph graph;

        public SelectNodePairForm()
        {
            InitializeComponent();
        }

        public void SetNodes(IStaticGraph graph, IEnumerable<IStaticGraphNode> nodes)
        {
            this.graph = graph;
            lbOrigin.Items.Clear();
            lbDestination.Items.Clear();
            lbOrigin.Items.AddRange(nodes.ToArray());
            lbDestination.Items.AddRange(nodes.ToArray());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lbDestination.SelectedItem == null || lbOrigin.SelectedItem == null)
            {
                MessageBox.Show("You must select one node on each side");
            }
            try
            {
                graph.LinkNodes(SelectedOrigin, SelectedDestination);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while creating link");
            }
        }
    }
}
