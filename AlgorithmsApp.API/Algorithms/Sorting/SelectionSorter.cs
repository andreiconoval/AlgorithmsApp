using System.Diagnostics;

namespace AlgorithmsApp.API.Algorithms.Sorting
{
    public class SelectionSorter : SortBase, ISortAlg
    {
        public  long Iterative(int[] arr)
        {
            stopWatch.Start();

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

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
            
        }

        public long Recursive(int[] arr)
        {
            throw new System.NotImplementedException();
        }
    }


}