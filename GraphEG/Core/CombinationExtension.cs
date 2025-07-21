using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core
{
    public static class CombinationExtension
    {
        /// <summary>
        /// Generates all possible combinations from a given IEnumerable except the empty one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T[]> Combinations<T>(this IEnumerable<T> source)
        {
            //For an explanation on how this works, see :
            //https://stackoverflow.com/a/57058345/5897829
            if (null == source)
                throw new ArgumentNullException(nameof(source));

            T[] data = source.ToArray();

            return Enumerable
              .Range(0, 1 << (data.Length))
              .Select(index => data
                 .Where((v, i) => (index & (1 << i)) != 0)
                 .ToArray())
              .Where(sequence => sequence.Length > 0);
        }
    }
}
