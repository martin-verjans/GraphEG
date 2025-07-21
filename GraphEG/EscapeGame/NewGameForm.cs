using GraphEG.Core.DynamicGraph;
using GraphEG.Core.StaticGraph;
using GraphEG.EscapeGame.GameSession;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GraphEG.EscapeGame
{
    public partial class NewGameForm : Form
    {
        private bool refreshing = false;
        public IStaticGraph StaticGraph { get; private set; }
        public IEnumerable<IPlayer> Players => lbPlayers.Items.Cast<IPlayer>();

        public IEnumerable<Possesses> PlayerSkills => playerSkills;

        private readonly List<Possesses> playerSkills;
        private IEnumerable<Skill> gameSkills;
        private IPlayer SelectedPlayer => lbPlayers.SelectedItem as IPlayer;

        public NewGameForm(IStaticGraph staticGraph)
        {
            InitializeComponent();
            playerSkills = new List<Possesses>();
            StaticGraph = staticGraph;
        }

        private void NewGameForm_Shown(object sender, EventArgs e)
        {
            Text = $"Prepare new game";
            gameSkills = StaticGraph.Nodes.OfType<Skill>();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            lbPlayers.Items.Add(new Player());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Players.Count() <= 0)
            {
                MessageBox.Show("You need at least one player");
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void lbPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPlayers.SelectedItem is null)
            {
                return;
            }
            refreshing = true;
            clbSkills.Items.Clear();
            foreach (Skill s in gameSkills)
            {
                if (playerSkills.Any(ps => ps.Origin == SelectedPlayer && ps.Destination == s))
                {
                    clbSkills.Items.Add(s, true);
                }
                else
                {
                    clbSkills.Items.Add(s, false);
                }
            }
            refreshing = false;
        }

        private void clbSkills_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (refreshing)
            {
                return;
            }
            bool addSkill = (e.CurrentValue == CheckState.Unchecked) && (e.NewValue == CheckState.Checked);
            Player p = (Player)SelectedPlayer;
            Skill s = (Skill)clbSkills.Items[e.Index];
            if (addSkill)
            {
                playerSkills.Add(new Possesses(p, s));
            }
            else
            {
                Possesses edge = playerSkills.First(ps => ps.Origin == p && ps.Destination == s);
                playerSkills.Remove(edge);
            }
        }
    }
}
