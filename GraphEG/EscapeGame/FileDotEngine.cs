using System.IO;
using System.Diagnostics;
using System.Threading;
using QuikGraph.Graphviz;
using QuikGraph.Graphviz.Dot;

namespace GraphEG.EscapeGame
{
    public sealed class FileDotEngine : IDotEngine
    {
        public string Run(GraphvizImageType imageType, string dot, string outputFileName)
        {
            string output = outputFileName;
            File.WriteAllText(output, dot);

            // assumes dot.exe is on the path:
            var args = string.Format(@"{0} -Tpng -O", output);

            ProcessStartInfo startInfo = new ProcessStartInfo("C:\\Program Files\\Graphviz\\bin\\dot.exe", args)
            {
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            using (Process p = Process.Start(startInfo))
            {
                do
                {
                    Thread.Yield();
                } while (!p.HasExited);
            }
            return output;
        }
    }
}
