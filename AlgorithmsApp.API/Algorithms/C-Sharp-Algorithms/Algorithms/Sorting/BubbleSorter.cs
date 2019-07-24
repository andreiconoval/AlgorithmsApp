﻿using System.Collections.Generic;
using AlgorithmsApp.API.Algorithms.C_Sharp_Algorithms.Algorithms.Common;

namespace AlgorithmsApp.API.Algorithms.C_Sharp_Algorithms.Algorithms.Sorting
{
    public static class BubbleSorter
    {
        public static void BubbleSort<T>(this IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            collection.BubbleSortAscending(comparer);
        }

        /// <summary>
        /// Public API: Sorts                    
        /// </summary>
        public static void BubbleSortAscending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                for (int index = 0; index < collection.Count - 1; index++)
                {
                    if (comparer.Compare(collection[index], collection[index + 1])>0)
                    {
                        collection.Swap(index,index+1);
                    }
                }
            }
        }

        /// <summary>
        /// Public API: Sorts descending
        /// </summary>
        public static void BubbleSortDescending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            for (int i = 0; i < collection.Count-1; i++)
            {
                for (int index = 1; index < collection.Count - i; index++)
                {
                    if (comparer.Compare(collection[index], collection[index - 1]) > 0)
                    {
                        collection.Swap(index-1, index);
                    }
                }
            }
        }
    }
}
