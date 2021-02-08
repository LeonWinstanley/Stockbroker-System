using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using StocksCourseworkAPI.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace CurrencyExchangeAPI.Services.BackgroundServices
{
    public class CurrencyExchangeBackgroundService : BackgroundService
    {
        private readonly ILogger<CurrencyExchangeBackgroundService> _logger;

        public CurrencyExchangeBackgroundService(IServiceProvider services,
            ILogger<CurrencyExchangeBackgroundService> logger)
        {
            Services = services;
            _logger = logger;
        }

        public IServiceProvider Services { get; }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service running.");

            await DoWork(stoppingToken);
        }
        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service is working.");

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IScopedProcessingService>();

                await scopedProcessingService.DoWork(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
