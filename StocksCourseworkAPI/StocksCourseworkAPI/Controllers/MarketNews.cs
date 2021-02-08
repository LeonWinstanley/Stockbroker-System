using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StocksCourseworkAPI.Services;
using StocksCourseworkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksCourseworkAPI.Controllers
{
    [Route("api/market-news")]
    [ApiController]
    public class MarketNews : ControllerBase
    {
        private readonly StocksService _stocksService;

        public MarketNews(StocksService stocksService)
        {
            _stocksService = stocksService;
        }

        [HttpGet]
        public async Task<List<CompanyNewsPayload>> Get()
        {
            return await _stocksService.fetchMarketNews();
        }
    }
}
