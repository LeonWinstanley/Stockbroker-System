using StocksCourseworkWebapp.Models.Payloads;
using System;
using System.Threading.Tasks;

namespace StocksCourseworkWebapp.Services
{
    public class APIStringBuilderService
    {
        private readonly string APIBaseURL = "https://localhost:5003/api/";
        private readonly string BaseCurrency = "USD";
        public string CreateCandleURL(string symbol, string resolution, int to, string currency)
        {
            string url;
            if (string.IsNullOrEmpty(currency))
            {
                url = String.Format($"{APIBaseURL}stock/candle/symbol={symbol}&resolution={resolution}&dateto={to}&currency={BaseCurrency}");
                return url;
            }
            url = String.Format($"{APIBaseURL}stock/candle/symbol={symbol}&resolution={resolution}&dateto={to}&currency={currency}");
            return url;
        }

        public string CreateAdvancedAutoCompleteUrl(string symbol, string company, string country, string industry)
        {
            string type = "";
            var url = String.Format($"{APIBaseURL}stock/advanced-search?");
            if (!string.IsNullOrEmpty(symbol))
            { 
                url = String.Format($"{url}symbol={symbol}");
                type = "&";
            }

            if (!string.IsNullOrEmpty(company))
            { 
                url = String.Format($"{url}{type}company={company}");
                type = "&";
            }

            if (!string.IsNullOrEmpty(country))
            { 
                url = String.Format($"{url}{type}country={country}");
                type = "&";
            }

            if (!string.IsNullOrEmpty(industry))
            { 
                url = String.Format($"{url}{type}industry={industry}"); 
            }

            return url;
        }

            public string CreateAutoCompleteURL(string input)
        {
            var url = String.Format($"{APIBaseURL}stock/symbols/search={input}");
            return url;
        }

        public string CreateCompanyNewsUrl(string input)
        {
            var url = string.Format($"{APIBaseURL}company-news/symbol={input}");
            return url;
        }

        public string CreateMarketNewsUrl()
        {
            return string.Format($"{APIBaseURL}market-news");
        }

        public string CreateCompanyProfileUrl(string input)
        {
            var url = string.Format($"{APIBaseURL}company-profile/symbol={input}");
            return url;
        }

        public string CreateQuoteUrl(string input, string currency)
        {
            string url;
            if (string.IsNullOrEmpty(currency))
            {
                url = string.Format($"{APIBaseURL}stock/symbol={input}&currency={BaseCurrency}");
            }
            url = string.Format($"{APIBaseURL}stock/symbol={input}&currency={currency}");
            return url;
        }

        public string CreateExchangeRateList()
        {
            var url = string.Format($"{APIBaseURL}ExchangeRates");
            return url;
        }

        public string CreateBalanceConvert(decimal balance, string currency)
        {
            var url = string.Format($"{APIBaseURL}user/balance={balance}&currency={currency}");
            return url;
        }

        public string CreateUSDConvert(decimal amount, string currency)
        {
            var url = string.Format($"{APIBaseURL}user/tousd/balance={amount}&currency={currency}");
            return url;
        }
    }
}
