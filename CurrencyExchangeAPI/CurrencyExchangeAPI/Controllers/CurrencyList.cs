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
    [Route("api/all-currencies")]
    [ApiController]
    public class CurrencyList : ControllerBase
    {
        private readonly CurrencyExchangeService _currencyExchangeService;

        public CurrencyList(CurrencyExchangeService currencyExchangeService)
        {
            _currencyExchangeService = currencyExchangeService;
        }

        [HttpGet]
        public async Task<List<CurrencyExchange>> Get()
        {
            var currencyExchange = await _currencyExchangeService.FetchExchangeRateList();
            return currencyExchange;
        }
    }
}
