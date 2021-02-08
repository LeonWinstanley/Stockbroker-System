using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StocksCourseworkAPI.Models;
using StocksCourseworkAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksCourseworkAPI.Controllers
{
    [Route("api/stock/advanced-search/")]
    [ApiController]
    public class AdvancedSearch : ControllerBase
    {
        private readonly StocksService _stocksService;
        public AdvancedSearch(StocksService stocksService)
        {
            _stocksService = stocksService;
        }

        [HttpGet]
        public async Task<List<CompanyProfilePayload>> Get(string symbol = "", string company = "", string country = "", string industry = "")
        {
            AdvancedSearchPayload search = new AdvancedSearchPayload { Symbol = symbol, Industry = industry, CompanyName = company, Country = country };

            var toReturn = await _stocksService.runAdvancedSearch(search);
            return toReturn;
        }
    }
}
