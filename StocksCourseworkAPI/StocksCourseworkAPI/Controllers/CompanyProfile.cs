using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksCourseworkAPI.Models;
using StocksCourseworkAPI.Services;

namespace StocksCourseworkAPI.Controllers
{
    [Route("api/company-profile/symbol={symbolInput}")]
    [ApiController]
    public class CompanyProfile : ControllerBase
    {
        private readonly StocksService _stocksService;

        public CompanyProfile(StocksService stocksService)
        {
            _stocksService = stocksService;
        }

        [HttpGet]
        public async Task<CompanyProfilePayload> Get(string symbolInput)
        {
            var toReturn = await _stocksService.FetchCompanyProfile(symbolInput);
            return toReturn;
        }
    }
}
