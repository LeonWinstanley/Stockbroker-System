using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StocksCourseworkAPI.Models;
using StocksCourseworkAPI.Services;

namespace StocksCourseworkAPI.Controllers
{
    [Route("api/stock/symbol={symbolInput}&currency={currency}")]
    [ApiController]
    public class StockQuote : ControllerBase
    {
        private readonly StocksService _stocksService;
        public StockQuote(StocksService stocksService)
        {
            _stocksService = stocksService;
        }

        [HttpGet]
        public async Task<StockQuotePayload> Get(string symbolInput, string currency = "USD")
        {
            var toReturn = await _stocksService.FetchQuote(symbolInput, currency);
            return toReturn;
        }
    }
}
