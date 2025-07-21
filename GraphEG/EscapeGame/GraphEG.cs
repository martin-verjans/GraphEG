using GraphEG.Core.Graph;
using GraphEG.Core.StaticGraph;
using GraphEG.EscapeGame.GameSession;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GraphEG.EscapeGame
{
    public partial class GraphEG : Form
    {
        private string[] RecentFolders => Properties.Settings.Default.RecentFolders.Split(Path.PathSeparator);
        public GraphEG()
        {
            InitializeComponent();
            LoadRecentGames();
        }

        private void LoadRecentGames()
        {
            foreach (string folder in RecentFolders.Reverse())
            {
                if (string.IsNullOrEmpty(folder)) continue;
                lbRecentFolders.Items.Add(folder);
            }
        }

        private void btnDesigner_Click(object sender, EventArgs e)
        {
            using (GameDesigner designer = new GameDesigner())
            {
                designer.ShowDialog();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            DialogResult result = openFolderDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            AddToRecentFolders(openFolderDialog.SelectedPath);
            StartGame(openFolderDialog.SelectedPath);
        }

        private void AddToRecentFolders(string folder)
        {
            if (RecentFolders.Contains(folder)) return;
            IEnumerable<string> recent = RecentFolders.Where(f => !string.IsNullOrEmpty(f));
            recent = recent.Append(folder);
            if (recent.Count() > 10)
            {
                recent = recent.Skip(1);
            }
            Properties.Settings.Default.RecentFolders = string.Join($"{Path.PathSeparator}", recent);
            Properties.Settings.Default.Save();
        }

        private void Manager_CommandOutputReceived(object sender, CommandOutputReceivedEventArgs e)
        {
            Console.WriteLine($"COMMAND : {e.Command}");
            Console.WriteLine($"RESPONSE{Environment.NewLine}---{Environment.NewLine}{e.Output}{Environment.NewLine}---");
        }

        private void btnLoadSelected_Click(object sender, EventArgs e)
        {
            if (lbRecentFolders.SelectedItem is null)
            {
                return;
            }
            string folder = lbRecentFolders.SelectedItem.ToString();
            StartGame(folder);   
        }

        private void StartGame(string folder)
        {
            GameSessionManager manager = new GameSessionManager(folder);
            manager.CommandOutputReceived += Manager_CommandOutputReceived;
            if (!manager.IsFolderAnEscapeGame())
            {
                DialogResult resultFile = openFileDialog.ShowDialog();
                if (resultFile != DialogResult.OK)
                    return;
                BinaryGraphLoader loader = new BinaryGraphLoader(openFileDialog.FileName);
                IStaticGraph graph = (IStaticGraph)loader.LoadGraph();
                manager.InitEscapeGame(graph);
            }

            GameEngine engine = new GameEngine(manager);
            engine.Start();
        }
    }
}
