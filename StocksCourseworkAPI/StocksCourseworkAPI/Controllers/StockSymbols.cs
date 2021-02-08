using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksCourseworkAPI.Services;
using SharedClasses;

namespace StocksCourseworkAPI.Controllers
{
    [Route("api/stock/symbols/search={input}")]
    [ApiController]
    public class StockSymbols : ControllerBase
    {
        private readonly StocksService _stocksService;

        public StockSymbols(StocksService stocksService)
        {
            _stocksService = stocksService;
        }
        [HttpGet]
        public async Task<List<StocksSymbolsClass>> Get(string input)
        {
            var listOfSymbols = await _stocksService.SearchStockSymbol(input);
            return listOfSymbols;
        }
    }
}
