using GraphEG.EscapeGame.GameSession;
using System;
using System.Windows.Forms;

namespace GraphEG.EscapeGame
{
    public partial class GameLoaderForm : Form
    {
        public string SelectedSessionName { get; private set; } = string.Empty;
        public bool ShouldCreateNewSession { get; private set; } = false;

        public GameLoaderForm(GameSessionManager sessionManager)
        {
            InitializeComponent();
            LoadSessions(sessionManager);
        }

        private void LoadSessions(GameSessionManager sessionManager)
        {
            lbSessions.Items.Clear();
            foreach (string sessioName in sessionManager.GetExistingSessions())
            {
                lbSessions.Items.Add(sessioName);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SelectedSessionName = tbNewSessionName.Text;
            ShouldCreateNewSession = true;
            DialogResult = DialogResult.OK;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SelectedSessionName = lbSessions.SelectedItem.ToString();
            ShouldCreateNewSession = false;
            DialogResult = DialogResult.OK;
        }
    }
}
