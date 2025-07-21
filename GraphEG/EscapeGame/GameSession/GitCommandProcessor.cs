using System.Diagnostics;
using System.Threading;

namespace GraphEG.EscapeGame.GameSession
{
    public class GitCommandProcessor
    {
        public string FolderName { get; }
        public GitCommandProcessor(string folderName)
        {
            FolderName = folderName;
        }

        public string ProcessCommand(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("C:\\Program Files\\Git\\bin\\git.exe", command)
            {
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                WorkingDirectory = FolderName
            };

            using (Process p = Process.Start(startInfo))
            {
                do
                {
                    Thread.Yield();
                } while (!p.HasExited);
                return p.StandardOutput.ReadToEnd();
            }
        }
    }
}
