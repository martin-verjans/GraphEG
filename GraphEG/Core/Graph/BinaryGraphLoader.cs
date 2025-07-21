using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GraphEG.Core.Graph
{
    public class BinaryGraphLoader
    {
        public string Filename { get; }
        public BinaryGraphLoader(string filename)
        {
            Filename = filename;
        }

        public IGraph LoadGraph()
        {
            using (FileStream fs = File.OpenRead(Filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (IGraph)formatter.Deserialize(fs);
            }
        }
    }
}
