using System.Diagnostics;
using System.Threading.Tasks;

namespace AlgorithmsApp.Algorithms.SortingAlgorithms
{
    public class InsertionSorting
    {
        Stopwatch sw;
        //not tested
        public InsertionSorting()
        {
            sw = new Stopwatch();
        }
        public long IterativeSort(int[] arr)
        {
            sw.Start();
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
            sw.Stop();
            return sw.ElapsedMilliseconds;

        }


        // NOT TESTED
        public long RecursiveSort(ref long executedTime, ref int[] arr, int i = 1, int n = 1)
        {
            sw.Reset();
            int value = arr[i];
            int j = i;

            while (j > 0 && arr[j - 1] > value)
            {
                arr[j] = arr[j - 1];
                j--;
            }

            arr[j] = value;

            if (i + 1 <= n)
            {
                executedTime += RecursiveSort(ref executedTime, ref arr, i + 1, n);
            }

            sw.Stop();
            executedTime += sw.ElapsedTicks;

            return executedTime;
        }
    }
}