using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GraphEG.Core.Graph
{
    public class BinaryGraphSaver
    {
        public string Filename { get; }
        public BinaryGraphSaver(string filename)
        {
            Filename = filename;
        }

        public void SaveGraph(IGraph graph)
        {
            using (FileStream fs = File.OpenWrite(Filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, graph);
            }
        }
    }
}
