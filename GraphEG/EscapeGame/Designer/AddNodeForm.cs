using GraphEG.Core.Graph;
using GraphEG.Core.StaticGraph;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GraphEG.EscapeGame
{
    public partial class AddNodeForm : Form
    {
        private IStaticGraph graph;

        public AddNodeForm()
        {
            InitializeComponent();
        }

        public void SetGraph(IStaticGraph graph)
        {
            this.graph = graph;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            graph.AddNode(new Room());
            DialogResult = DialogResult.OK;
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            SelectOriginNodeForm nodeForm = new SelectOriginNodeForm();
            nodeForm.SetNodes(graph.Nodes.OfType<Puzzle>().Cast<INode>().Concat(graph.Nodes.OfType<Room>()));
            DialogResult result = nodeForm.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            if (nodeForm.SelectedNode is Puzzle puzzle)
            {
                Role role = new Role(puzzle.PuzzleNumber);
                graph.AddNode(role);
                graph.LinkNodes(role, puzzle);
            }
            else if (nodeForm.SelectedNode is Room room)
            {
                Role newRole = new Role();
                graph.AddNode(newRole);
                graph.LinkNodes(newRole, room);
            }
            DialogResult = DialogResult.OK;
        }

        private void btnAddClue_Click(object sender, EventArgs e)
        {
            SelectOriginNodeForm nodeForm = new SelectOriginNodeForm();
            nodeForm.SetNodes(graph.Nodes.OfType<Role>());
            DialogResult result = nodeForm.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            Role selectedRole = (Role)nodeForm.SelectedNode;
            Clue clue = new Clue(null, false, selectedRole.PuzzleNumber);
            graph.AddNode(clue);
            graph.LinkNodes(clue, selectedRole);
            DialogResult = DialogResult.OK;
        }

        private void btnAddPuzzle_Click(object sender, EventArgs e)
        {
            graph.AddNode(new Puzzle());
            DialogResult = DialogResult.OK;
        }

        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            graph.AddNode(new Skill(""));
            DialogResult = DialogResult.OK;
        }

        private void btnAddMeta_Click(object sender, EventArgs e)
        {
            SelectMetaForm metaForm = new SelectMetaForm();
            DialogResult result = metaForm.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            IMetaFunction metaFunction = null;
            switch(metaForm.SelectedValue.ToString())
            {
                case "Victory":
                    metaFunction = new MetaVictory();
                    break;
                case "Exit":
                    metaFunction = new MetaExit();
                    break;
            }
            graph.AddNode(new Meta(metaFunction));
            DialogResult = DialogResult.OK;
        }
    }
}
