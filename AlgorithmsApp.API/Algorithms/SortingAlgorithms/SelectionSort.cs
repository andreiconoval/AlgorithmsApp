using System.Diagnostics;

namespace AlgorithmsApp.API.Algorithms.SortingAlgorithms
{
    public class SelectionSort
    {
        Stopwatch sw;
        //not tested
        public SelectionSort()
        {
            sw = new Stopwatch();
        }

        public long IterativeSort(int[] arr)
        {
            sw.Start();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }

                Swap(ref arr, min, i);
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        private static void Swap(ref int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }



    }


}