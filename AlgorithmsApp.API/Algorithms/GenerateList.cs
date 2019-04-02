using System;
using System.Linq;

namespace AlgorithmsApp.API.Algorithms
{
    public class GenerateList
    {
        public int[] ListOfIntegers(int numOfInts)
        {
            Random rand = new Random();
            var ints = Enumerable.Range(0, numOfInts)
                                     .Select(i => new Tuple<int, int>(rand.Next(numOfInts), i))
                                     .OrderBy(i => i.Item1)
                                     .Select(i => i.Item2);
            return ints.ToArray();
        }
    }
}