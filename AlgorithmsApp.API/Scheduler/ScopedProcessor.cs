using System;
using System.Threading.Tasks;
using AlgorithmsApp.API.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlgorithmsApp.API.Scheduler
{
    public abstract class ScopedProcessor: BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private  IConfiguration _configuration { get; }


        public ScopedProcessor(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration): base(serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _configuration = configuration;
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