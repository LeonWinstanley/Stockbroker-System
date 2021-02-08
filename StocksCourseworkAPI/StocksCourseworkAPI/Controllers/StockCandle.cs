using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedClasses;
using StocksCourseworkAPI.Services;

namespace StocksCourseworkAPI.Controllers
{
    [Route("api/stock/candle/symbol={symbolInput}&resolution={resolutionInput}&dateto={dateToInput}&currency={currency}")]
    [ApiController]
    public class StockCandle : ControllerBase
    {
        private readonly StocksService _stocksService;
        public StockCandle(StocksService stocksService)
        {
            _stocksService = stocksService;
        }

        [HttpGet]
        public async Task<List<StocksCandleClass>> Get(string symbolInput, string resolutionInput, int dateToInput, string currency = "USD")
        {
            var listOfCandles = await _stocksService.FetchStockCandle(symbolInput, resolutionInput, dateToInput, currency);

            return listOfCandles;
        }
    }
}
