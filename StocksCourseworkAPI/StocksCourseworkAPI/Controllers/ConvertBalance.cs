using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StocksCourseworkAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksCourseworkAPI.Controllers
{
    [Route("api/user/balance={balance}&currency={currency}")]
    [ApiController]
    public class ConvertBalance : ControllerBase
    {
        private readonly StocksService _stocksService;

        public ConvertBalance(StocksService stocksService)
        {
            _stocksService = stocksService;
        }

        [HttpGet]
        public async Task<decimal> get(decimal balance, string currency)
        {
            return await _stocksService.ConvertBalance(balance, currency);
        }
    }
}
