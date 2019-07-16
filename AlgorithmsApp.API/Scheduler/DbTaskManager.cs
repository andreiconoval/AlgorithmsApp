using System;
using System.Collections;
using System.Threading.Tasks;
using AlgorithmsApp.API.Common;
using AlgorithmsApp.API.Data;

namespace AlgorithmsApp.API.Scheduler
{
    public class DbTaskManager 
    {
        private DataManager dataManager;
        public DbTaskManager()
        {
            AlgorithmsList = EnumConverter.EnumToList<AlgorithmsEnum>();
            dataManager = new DataManager();
        }
        EnumConverter EnumConverter;
        private IList AlgorithmsList { get; set; }

        public async Task<Task> GenerateAlgorithmsStatistics()
        {

            foreach (var item in AlgorithmsList)
            {
                var s = await dataManager.AddOrUpdateAlgorithm(item.ToString());
                Console.WriteLine(s);
            }

            return Task.CompletedTask;
        }
    }
}