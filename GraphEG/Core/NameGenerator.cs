using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core
{
    [Serializable]
    public class NameGenerator
    {
        public static NameGenerator Instance { get; set; }
        public static string GenerateName(string key) { return Instance.InternalGenerateName(key); }
        public static int GetCounter(string key) { return Instance.InternalGetCounter(key); }


        private readonly Dictionary<string, int> counters = new Dictionary<string, int>();

        private string InternalGenerateName(string key)
        {
            return $"{key}{GetCounterAndIncrement(key)}";
        }

        private int InternalGetCounter(string key)
        {
            return counters[key];
        }

        private int GetCounterAndIncrement(string key)
        {
            if (!counters.ContainsKey(key))
            {
                counters.Add(key, 1);
            }
            return counters[key]++;
        }

        public int GetNumberFromName(string name)
        {
            return int.Parse(string.Join("", name.Where(c => char.IsDigit(c))));
        }
    }
}
