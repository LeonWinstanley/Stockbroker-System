using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StocksCourseworkAPI.Services.BackgroundServices
{
    internal interface IScopedProcessingService
    {
        Task CandleFetcher(CancellationToken stoppingToken);
        Task SymbolFetcher(CancellationToken stoppingToken);
        Task CompanyProfileFetcher(CancellationToken stoppingToken);
    }

    internal class ScopedProcessingService : IScopedProcessingService
    {
        private readonly ILogger _logger;
        private readonly StocksService _stocksService;

        public ScopedProcessingService(ILogger<ScopedProcessingService> logger, StocksService stocksService)
        {
            _logger = logger;
            _stocksService = stocksService;
        }

        public async Task CandleFetcher(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _stocksService.FetchNasdaq();
                await Task.Delay(3600000, stoppingToken); // 3600000 miliseconds = 1 hour
            }
        }
        public async Task SymbolFetcher(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _stocksService.FetchSymbolsAndSave();
                await Task.Delay(86400000, stoppingToken); // 86400000 miliseconds = 24 hours
            }
        }
        public async Task CompanyProfileFetcher(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _stocksService.FetchCompanyProfileAndSave();
                await Task.Delay(604800000, stoppingToken); // 604800000 miliseconds = 1 week
            }
        }
    }
}
