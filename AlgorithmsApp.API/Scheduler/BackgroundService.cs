using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace AlgorithmsApp.API.Scheduler
{
    public abstract class BackgroundService : IHostedService
    {
        private Task _executingTask;
        private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Store the  task we're executing
            _executingTask = ExecuteAsync(_stoppingCts.Token);

            // If the task is completed then return it
            // this will bubble cancelation and failure to the canceler
            if(_executingTask.IsCompleted)
                return _executingTask;

            // Otherwise it's running
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
           // Stop called without start
        if (_executingTask == null)
        {
            return;
        }
 
        try
        {
            // Signal cancellation to the executing method
            _stoppingCts.Cancel();
        }
        finally
        {
            // Wait until the task completes or the stop token triggers
            await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite,cancellationToken));
        }
        }

        protected virtual async Task ExecuteAsync(CancellationToken stoppingToken)
        {
             //stoppingToken.Register(() =>
             //        _logger.LogDebug($" GracePeriod background task is stopping."));
            do
            {
                await Process();

                await Task.Delay(5000, stoppingToken);
            }
            while(!stoppingToken.IsCancellationRequested);
        }

        public abstract Task Process();
    }
}