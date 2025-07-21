using GraphEG.Core.DynamicGraph;
using GraphEG.Core.Graph;
using GraphEG.Core.StaticGraph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace GraphEG.EscapeGame.GameSession
{
    public class GameSessionManager
    {
        public string FolderName { get; }
        public string StaticGraphFileName { get; set; } = "StaticGraph.sg";
        public string DynamicGraphFileName { get; set; } = "DynamicGraph.sg";

        public event EventHandler<CommandOutputReceivedEventArgs> CommandOutputReceived;

        private readonly GitWrapper git;
        public GameSessionManager(string folderName) 
        {
            FolderName = folderName;
            git = new GitWrapper(folderName);
            git.CommandOutputReceived += Git_CommandOutputReceived;
        }

        private void Git_CommandOutputReceived(object sender, CommandOutputReceivedEventArgs e)
        {
            CommandOutputReceived?.Invoke(this, e);
        }

        public List<string> GetExistingSessions()
        {
            return git.GetBranchNames();
        }

        public IEnumerable<SessionActionHistory> LoadHistoryForSession(string sessionName)
        {
            return git.GetBranchHistory(sessionName).OrderBy(s => s.Order);
        }

        public void LoadSession(string sessionName)
        {
            git.CheckoutBranch(sessionName);
        }

        public void InitSession(string sessionName)
        {
            git.CreateBranchFromInitialCommit(sessionName);
        }

        public void InitSession(string sessionName, string stepId)
        {
            git.CreateBranchFromCommit(sessionName, stepId);
        }

        public IStaticGraph GetStaticGraph()
        {
            BinaryGraphLoader loader = new BinaryGraphLoader(Path.Combine(FolderName, StaticGraphFileName));
            return (IStaticGraph)loader.LoadGraph();
        }

        public IDynamicGraph GetDynamicGraph()
        {
            BinaryGraphLoader loader = new BinaryGraphLoader(Path.Combine(FolderName, DynamicGraphFileName));
            return (IDynamicGraph)loader.LoadGraph();
        }

        public void SaveStaticGraph(IStaticGraph graph)
        {
            SaveFile(graph, Path.Combine(FolderName, StaticGraphFileName));
            git.AddFile(StaticGraphFileName);
            git.Commit("Game initialized");
        }

        public void StartGame(IDynamicGraph graph)
        {
            SaveFile(graph, Path.Combine(FolderName, DynamicGraphFileName));
            IEnumerable<string> playerSkills = graph.Players.Select(p => BuildPlayerSkills(p, graph));
            string message = string.Join("_", playerSkills);
            git.AddFile(DynamicGraphFileName);
            git.Commit(message);
        }

        private string BuildPlayerSkills(IPlayer player, IDynamicGraph graph)
        {
            IEnumerable<string> skills = graph.GetPlayerSkills(player).Select(s => s.Name);
            return $"{player.Name}:{string.Join("-", skills)}";
        }

        public void SaveDynamicGraph(IDynamicGraph graph, List<string> turnEvents)
        {
            SaveFile(graph, Path.Combine(FolderName, DynamicGraphFileName));
            git.Commit(turnEvents.First(), turnEvents.Skip(1));
            if (graph.HavePlayersWon)
                git.CreateTag($"Victory_{git.CurrentBranch}");
        }

        private void SaveFile(IGraph toSave, string fileName)
        {
            BinaryGraphSaver saver = new BinaryGraphSaver(fileName);
            saver.SaveGraph(toSave);
            using (FileStream fs = File.OpenWrite(fileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, toSave);
            }
        }

        internal bool IsFolderAnEscapeGame()
        {
            string folderName = $"{FolderName}{Path.DirectorySeparatorChar}.git";
            return Directory.Exists(folderName);
        }

        internal void InitEscapeGame(IStaticGraph graph)
        {
            git.Init();
            SaveStaticGraph(graph);
        }
    }
}
