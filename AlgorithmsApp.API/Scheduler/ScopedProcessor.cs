using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AlgorithmsApp.API.Scheduler
{
    public abstract class ScopedProcessor: BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ScopedProcessor(IServiceScopeFactory serviceScopeFactory): base()
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public override async Task Process()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                await ProcessInScopeAsync(scope.ServiceProvider);
            }
        }

        public abstract Task ProcessInScopeAsync(IServiceProvider serviceProvider);
    }
}