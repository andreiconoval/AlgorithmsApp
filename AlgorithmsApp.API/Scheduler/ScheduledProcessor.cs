using System;
using System.Threading;
using System.Threading.Tasks;
using AlgorithmsApp.API.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NCrontab;

namespace AlgorithmsApp.API.Scheduler
{
    public abstract class ScheduledProcessor : ScopedProcessor
    {
        private CrontabSchedule _schedule;
        private DateTime _nextRun;
        protected abstract string Schedule { get; }
        public ScheduledProcessor(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration) : base(serviceScopeFactory, configuration)
        {
            _schedule = CrontabSchedule.Parse(Schedule);
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                var nextRun = _schedule.GetNextOccurrence(now);
                if (nextRun > _nextRun)
                {
                    await Process();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }
                await Task.Delay(5000, stoppingToken); // 5 seconds delay
            } while (!stoppingToken.IsCancellationRequested);
        }

    }
}