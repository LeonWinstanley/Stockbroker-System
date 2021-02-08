using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchangeAPI.Models;
using StocksCourseworkAPI.Services;

namespace CurrencyExchangeAPI.Controllers
{
    [Route("api/currency={currencySymbol}")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyExchangeService _currencyExchangeService;

        public CurrencyController(CurrencyExchangeService currencyExchangeService)
        {
            _currencyExchangeService = currencyExchangeService;
        }

        [HttpGet]
        public async Task<CurrencyExchange> Get(string currencySymbol)
        {
            var currencyExchange = await _currencyExchangeService.FetchExchangeRate(currencySymbol);
            return currencyExchange;
        }
    }
}
