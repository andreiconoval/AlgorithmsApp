using System;
using System.Linq;
using AlgorithmsApp.API.Dtos;

namespace AlgorithmsApp.API.Algorithms
{
    public class ListGenerator
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

        public double[] GetSeps(MockSettings mockSettings)
        {
            var steps = new double[mockSettings.NumberOfSteps];
            decimal pow = Decimal.Divide( 1, (mockSettings.NumberOfSteps - 1));
            double demp = mockSettings.MaxPoint / mockSettings.MinPoint;
            var coef = Math.Pow(demp, decimal.ToDouble(pow));
            steps[0] = 20;
            for (int i = 1; i < mockSettings.NumberOfSteps - 1; i++)
            {
                steps[i] = (double)(steps[i - 1] * coef);
            }

            return steps;
        }
    }
}