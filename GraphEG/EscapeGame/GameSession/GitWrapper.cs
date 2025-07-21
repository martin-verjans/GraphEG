using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.EscapeGame.GameSession
{
    public class GitWrapper
    {
        private const string INIT_SESSION_NAME = "InitialSession";
        private readonly GitCommandProcessor commandProcessor;
        public event EventHandler<CommandOutputReceivedEventArgs> CommandOutputReceived;

        public GitWrapper(string folderName)
        {
            commandProcessor = new GitCommandProcessor(folderName);
        }

        public string CurrentBranch { get; private set; }

        internal void CheckoutBranch(string sessionName)
        {
            Execute($"checkout {sessionName}");
            CurrentBranch = sessionName;
        }

        internal void Commit(string commitMessage)
        {
            Commit(new[] {commitMessage});
        }

        internal void Commit(string commitMessage, IEnumerable<string> commitDetails)
        {
            List<string> messages = new List<string>(commitDetails);
            messages.Insert(0, commitMessage);
            Commit(messages);
        }

        private void Commit(IEnumerable<string> commitMessages)
        {
            Execute($"commit -a -m \"{string.Join("\" -m \"", commitMessages)}\" ");
        }

        internal void CreateBranchFromCommit(string sessionName, string stepId)
        {
            throw new NotImplementedException();
        }

        internal void CreateBranchFromInitialCommit(string sessionName)
        {
            CheckoutBranch(INIT_SESSION_NAME);
            Execute($"checkout -b {sessionName}");
            CurrentBranch = sessionName;
        }

        internal void CreateTag(string v)
        {
            string result = Execute("tag");
            string[] tags = result.Split(Environment.NewLine.ToCharArray());
            int tagCount = tags.Length;
            Execute($"tag {v}-{tagCount + 1}");
        }

        internal List<SessionActionHistory> GetBranchHistory(string sessionName)
        {
            Dictionary<string, string> history = new Dictionary<string, string>();
            string result = Execute("log --oneline");
            string[] results = result.Split(Environment.NewLine.ToCharArray());
            return new List<SessionActionHistory>(
                results
                .Where(r => r.Length > 0)
                .Select(r => SessionActionHistory.BuildActionHistoryLine(r)));
        }

        internal List<string> GetBranchNames()
        {
            string output = Execute("branch --list");
            return output
                .Split(Environment.NewLine.ToCharArray())
                .Select(b => b.StartsWith("*") ? b.Substring(b.IndexOf(" ") + 1).Trim() : b.Trim())
                .Except(new[] {INIT_SESSION_NAME}).ToList();
        }

        internal void Init()
        {
            Execute($"init --initial-branch={INIT_SESSION_NAME}");
        }

        private string Execute(string command)
        {
            string output = commandProcessor.ProcessCommand(command);
            CommandOutputReceived?.Invoke(this, new CommandOutputReceivedEventArgs(command, output));
            return output;
        }

        internal void AddFile(string fileName)
        {
            Execute($"add \"{fileName}\"");
        }
    }
}
