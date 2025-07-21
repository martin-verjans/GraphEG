using GraphEG.Core.StaticGraph;
using GraphEG.EscapeGame.Graph;
using System;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using GraphEG.Core.Graph;
using System.Reflection;

namespace GraphEG.EscapeGame
{
    public partial class GameDesigner : Form
    {
        private IStaticGraph graph;
        private GraphDisplay graphDisplay;
        private GraphDisplayOptions graphDisplayOptions;
        private bool refreshing = false;

        public GameDesigner()
        {
            InitializeComponent();
            graphDisplayOptions = GraphDisplayOptions.Default;
            InitUI();
        }

        private void InitUI()
        {
            SuspendLayout();
            refreshing = true;
            btnNewEG.Enabled = true;
            btnLoad.Enabled = true;

            btnSaveGame.Enabled = false;
            btnAddNode.Enabled = false;
            btnAddEdge.Enabled = false;
            btnRemoveNode.Enabled = false;
            btnRemoveEdge.Enabled = false;

            gbDisplay.Enabled = false;
            gbErrors.Enabled = false;
            CreateDisplayOptions();
            refreshing = false;
            ResumeLayout(false);
        }

        private void RefreshUI()
        {
            if (graph == null)
            {
                InitUI();
                return;
            }
            RefreshGraph();
            RefreshButtons();
        }

        private void CreateDisplayOptions()
        {
            cbListDisplay.Items.Clear();
            var type = graphDisplayOptions.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(bool))
                {
                    bool value = (bool)property.GetValue(graphDisplayOptions);
                    cbListDisplay.Items.Add(property.Name, value);
                }
            }
        }

        private void RefreshButtons()
        {
            btnNewEG.Enabled = true;
            btnLoad.Enabled = true;

            btnSaveGame.Enabled = true;
            btnAddNode.Enabled = true;
            btnAddEdge.Enabled = true;
            btnRemoveNode.Enabled = true;
            btnRemoveEdge.Enabled = true;

            gbDisplay.Enabled = true;
            gbErrors.Enabled = true;
            pbGraph.Enabled = true;
        }

        private void RefreshGraph()
        {
            if (graph is null) { return; }

            graphDisplay = InstanciateGraphDisplay();

            graphDisplay.RefreshGraph(graph);
            pbGraph.Image = graphDisplay.LastGeneratedImage;

            List<string> Errors = new List<string>();
            foreach (IStaticGraphNode node in graph.Nodes)
            {
                node.Validate(graph, Errors);
            }
            lbErrors.Items.Clear();
            lbErrors.Items.AddRange(Errors.ToArray());
        }

        private GraphDisplay InstanciateGraphDisplay()
        {
            if (graphDisplayOptions.UseRawDisplay)
            {
                return new RawGraphDisplay(graphDisplayOptions);
            }
            return graphDisplay = new StaticGraphDisplay(graphDisplayOptions);
        }

        private void btnNewEG_Click(object sender, EventArgs e)
        {
            graph = new StaticGraph();
            graph.Init();
            Room startingRoom = new Room("R0");
            Role globalStart = new Role("L0", 0);
            Meta victory = new Meta("I0", new MetaVictory());
            graph.AddNode(startingRoom);
            graph.AddNode(globalStart);
            graph.AddNode(victory);
            graph.LinkNodes(globalStart, startingRoom);
            graph.LinkNodes(victory, globalStart);
            RefreshUI();
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            BinaryGraphSaver saver = new BinaryGraphSaver(saveFileDialog.FileName);
            saver.SaveGraph(graph);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            BinaryGraphLoader loader = new BinaryGraphLoader(openFileDialog.FileName);
            graph = (IStaticGraph)loader.LoadGraph();
            graph.Init();
            RefreshUI();
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            using (AddNodeForm nodeForm = new AddNodeForm())
            {
                nodeForm.SetGraph(graph);
                DialogResult result = nodeForm.ShowDialog();
                if (result != DialogResult.OK)
                    return;
            }
            RefreshUI();
        }

        private void btnRemoveNode_Click(object sender, EventArgs e)
        {
            using (SelectOriginNodeForm nodeForm = new SelectOriginNodeForm())
            {
                nodeForm.SetNodes(graph.Nodes);
                DialogResult result = nodeForm.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                graph.RemoveNode(nodeForm.SelectedNode);
            }
            RefreshUI();
        }

        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            using (SelectNodePairForm edgeForm = new SelectNodePairForm())
            {
                edgeForm.SetNodes(graph, graph.Nodes);
                DialogResult result = edgeForm.ShowDialog();
                if (result != DialogResult.OK)
                    return;
            }
            RefreshUI();
        }

        private void btnRemoveEdge_Click(object sender, EventArgs e)
        {
            using (SelectEdgeForm selectEdge = new SelectEdgeForm())
            {
                selectEdge.SetNodes(graph.Edges);
                DialogResult result = selectEdge.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                graph.RemoveEdge(selectEdge.SelectedEdge);
            }
            RefreshUI();
        }

        private void cbListDisplay_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (refreshing) return;
            if (e.CurrentValue == e.NewValue) return;

            bool newValue = e.NewValue == CheckState.Checked;
            string propertyName = cbListDisplay.Items[e.Index].ToString();
            PropertyInfo property = graphDisplayOptions.GetType().GetProperty(propertyName);
            property.SetValue(graphDisplayOptions, newValue);
            RefreshUI();
        }
    }
}
