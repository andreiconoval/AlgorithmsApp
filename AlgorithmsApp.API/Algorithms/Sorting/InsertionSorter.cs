using System.Diagnostics;
using System.Threading.Tasks;

namespace AlgorithmsApp.API.Algorithms.Sorting
{
    public class InsertionSorter : SortBase, ISortAlg
    {
        public  long Iterative(int[] arr)
        {
            stopWatch.Start();
            for (int i = 0; i < arr.Length; i++)
            {
                int value = arr[i];
                int j = i;

                while (j > 0 && arr[j - 1] > value)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }

                arr[j] = value;
            }
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;

        }

        public long Recursive(int[] arr)
        {
            throw new System.NotImplementedException();
        }
    }
}