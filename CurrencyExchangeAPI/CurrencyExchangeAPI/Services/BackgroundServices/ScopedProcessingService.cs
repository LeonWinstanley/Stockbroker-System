using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StocksCourseworkAPI.Services;

namespace CurrencyExchangeAPI.Services.BackgroundServices
{
    internal interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }

    internal class ScopedProcessingService : IScopedProcessingService
    {
        private int executionCount = 0;
        private readonly ILogger _logger;
        private readonly CurrencyExchangeService _currencyExchangeService;

        public ScopedProcessingService(ILogger<ScopedProcessingService> logger, CurrencyExchangeService currencyExchangeService)
        {
            _logger = logger;
            _currencyExchangeService = currencyExchangeService;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                executionCount++;
                await _currencyExchangeService.SaveCurrencyExchangeRates();
                _logger.LogInformation(
                    "Scoped Processing Service is working. Count: {Count}", executionCount);

                await Task.Delay(86400000, stoppingToken); // 1 day delay
            }
        }
    }
}
