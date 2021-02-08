using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using DateTimeOffset = System.DateTimeOffset;

namespace StocksCourseworkAPI.Services
{
    public class APIStringBuilderService
    {
        private readonly string finnhubBaseUrl = "https://finnhub.io/api/v1/";
        private readonly string finnhubApiKey = "bo5285vrh5rbvm1sfma0";
        private readonly string currencyBaseUrl = "https://localhost:5001/api/";
        public async Task<string> CreateCandleUrl(string symbol, string resolution, int from)
        {
            long to = DateTimeOffset.Now.ToUnixTimeSeconds();
            long fromConverted = DateTimeOffset.Now.AddDays(-from).ToUnixTimeSeconds();
            var url = string.Format($"{finnhubBaseUrl}stock/candle?symbol={symbol}&resolution={resolution}&from={fromConverted}&to={to}&token={finnhubApiKey}");
            return url;
        }

        public async Task<string> CreateExchangeUrl(string rate)
        {
            var url = string.Format($"{currencyBaseUrl}currency={rate}");
            return url;
        }
        public async Task<string> CreateExchangeListUrl()
        {
            var url = string.Format($"{currencyBaseUrl}all-currencies");
            return url;
        }
        public async Task<string> CreateQuoteUrl(string symbol)
        {
            var url = string.Format($"{finnhubBaseUrl}quote?symbol={symbol}&token={finnhubApiKey}");
            return url;
        }

        public async Task<string> CreateIndicesUrl(string symbol)
        {
            var url = string.Format($"{finnhubBaseUrl}index/constituents?symbol={symbol}&token={finnhubApiKey}");
            return url;
        }

        public async Task<string> CreateSymbolsUrl()
        {
            var url= string.Format($"{finnhubBaseUrl}stock/symbol?exchange=US&token={finnhubApiKey}");
            return url;
        }

        public async Task<string> CreateCompanyProfileUrl(string symbol)
        {
            var url = string.Format($"{finnhubBaseUrl}stock/profile2?symbol={symbol}&token={finnhubApiKey}");
            return url;
        }

        public async Task<string> CreateCompanyNewsUrl(string symbol)
        {
            var now = DateTimeOffset.Now.ToString("yyyy-MM-dd");
            var oneWeek = DateTimeOffset.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            var url = string.Format(
                $"{finnhubBaseUrl}company-news?symbol={symbol}&from={oneWeek}&to={now}&token={finnhubApiKey}");

            return url;
        }

        public async Task<string> CreateMarketsNewsUrl()
        {
            var url = string.Format($"{finnhubBaseUrl}news?category=general&token={finnhubApiKey}");
            return url;
        }
    }
}
