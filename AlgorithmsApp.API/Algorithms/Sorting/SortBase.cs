using System.Diagnostics;

namespace AlgorithmsApp.API.Algorithms.Sorting
{
    public class SortBase
    {
        internal Stopwatch stopWatch {get; set;}
        //not tested
        public SortBase()
        {
            stopWatch = new Stopwatch();
        }


        internal static void Swap(ref int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}