using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AlgorithmsApp.API.Algorithms.C_Sharp_Algorithms.Algorithms.Sorting;
using AlgorithmsApp.API.Common;
using AlgorithmsApp.API.Data;


namespace AlgorithmsApp.API.Scheduler
{
    public class DbTaskManager
    {
        private DataManager dataManager;
        public DbTaskManager(DataContext context)
        {
            AlgorithmsList = EnumConverter.EnumToList<AlgorithmsEnum>();
            dataManager = new DataManager(context);
        }
        public DbTaskManager(IList algorithmsList)
        {
            this.AlgorithmsList = algorithmsList;

        }
        private IList AlgorithmsList { get; set; }

        public async Task<Task> GenerateAlgorithmsStatistics()
        {
            var mockList = await dataManager.GetMocks();

            foreach (var mock in mockList)
            {
                Console.WriteLine(mock.Id);
                Task<Dictionary<string, long>>[] taskArray = {
                    Task<Dictionary<string,long>>.Factory.StartNew(() =>
                        DoComputation(() => GetIntArray(mock.SetOfData).BubbleSort(),AlgorithmsEnum.BubbleSorter.ToString())
                        ),
                    Task<Dictionary<string,long>>.Factory.StartNew(() =>
                        DoComputation(() => GetIntArray(mock.SetOfData).BucketSort(),AlgorithmsEnum.BucketSorter.ToString())
                    ),
                    Task<Dictionary<string,long>>.Factory.StartNew(() =>
                    DoComputation(() => GetIntArray(mock.SetOfData).CombSort(),AlgorithmsEnum.ComboSorter.ToString())
                        )};

                Task.WaitAll(taskArray);

                for (int i = 0; i < taskArray.Length; i++)
                {
                    var data = taskArray[i].Result;

                    if (data != null)
                        foreach (KeyValuePair<string, long> item in data)
                        {
                            Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
                        }
                }

            }

            return Task.CompletedTask;
        }

        private static int[] GetIntArray(string s)
        {
            try
            {
                return Array.ConvertAll(s.Split(","), Int32.Parse);
            }
            catch (System.Exception)
            {
                int[] i = new int[3] { 0, 1, 2 };
                return i;
            }

        }
        private static Dictionary<string, long> DoComputation(Action sortingMethod, string sortingName)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            sortingMethod();
            stopWatch.Stop();
            return new Dictionary<string, long> { { sortingName, stopWatch.ElapsedMilliseconds } };
        }
    }
}