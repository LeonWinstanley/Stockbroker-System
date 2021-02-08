using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksCourseworkAPI.Models;
using StocksCourseworkAPI.Services;

namespace StocksCourseworkAPI.Contexts
{
    [Route("api/company-news/symbol={symbolInput}")]
    [ApiController]
    public class CompanyNews : ControllerBase
    {
        private readonly StocksService _stocksService;
        public CompanyNews(StocksService stocksService)
        {
            _stocksService = stocksService;
        }

        [HttpGet]
        public async Task<List<CompanyNewsPayload>> Get(string symbolInput)
        {
            var toReturn = await _stocksService.fetchCompanyNews(symbolInput);
            return toReturn;
        }
    }
}
