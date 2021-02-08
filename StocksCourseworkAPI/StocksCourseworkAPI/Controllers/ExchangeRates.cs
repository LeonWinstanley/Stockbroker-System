using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StocksCourseworkAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedClasses;

namespace StocksCourseworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRates : ControllerBase
    {
        private readonly StocksService _stocksService;
        public ExchangeRates(StocksService stocksService)
        {
            _stocksService = stocksService;
        }

        [HttpGet]
        public async Task<List<CurrencyExchange>> Get()
        {
            var toReturn = await _stocksService.FetchAllCurrencies();
            return toReturn;
        }
    }
}
