namespace AlgorithmsApp.API.Algorithms.Sorting
{
    public class BubbleSorter: SortBase, ISortAlg
    {
        public long Iterative(int[] arr)
        {
            stopWatch.Start();
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = 0; j < arr.Length-1; j++)
                {
                    if (arr[j] < arr[j+1])
                    {
                        Swap(ref arr,j, j+1);
                    }
                }
                
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