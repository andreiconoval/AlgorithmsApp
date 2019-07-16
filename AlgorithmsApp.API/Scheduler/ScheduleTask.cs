using System;
using System.Threading.Tasks;
using AlgorithmsApp.API.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlgorithmsApp.API.Scheduler
{
    public class ScheduleTask : ScheduledProcessor
    {
        private StringSettings _stringSettings;
        private string _schedule = "*/3 * * * *";
        private DbTaskManager _dbTaskManager;
        public ScheduleTask(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration) : base(serviceScopeFactory)
        {
            _stringSettings = new StringSettings(configuration);
            _schedule = _stringSettings.GetSchedule();
            _dbTaskManager = new DbTaskManager();
        }

        protected override string Schedule =>  _schedule; //Runs every 100 minutes

        public override Task ProcessInScopeAsync(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Process strat here" + _schedule);
            var temp = _dbTaskManager.GenerateAlgorithmsStatistics();
            return Task.CompletedTask;
        }
    }
}

//https://thinkrethink.net/2018/05/31/run-scheduled-background-tasks-in-asp-net-core/