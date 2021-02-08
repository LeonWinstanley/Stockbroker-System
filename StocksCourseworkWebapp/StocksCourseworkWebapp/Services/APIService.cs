using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MudBlazor;
using Newtonsoft.Json;
using StocksCourseworkWebapp.Models.Payloads;
using Syncfusion.Blazor.Charts;

namespace StocksCourseworkWebapp.Services
{
    public class APIService
    {
        private readonly HttpClient _httpClient;
        private readonly APIStringBuilderService _stringBuilder;
        private readonly ISnackbar _snackbar;

        public APIService(HttpClient httpClient, APIStringBuilderService stringBuilder, ISnackbar snackbar)
        {
            _httpClient = httpClient;
            _stringBuilder = stringBuilder;
            _snackbar = snackbar;
        }
        
        public void throwSnackBarError()
        {
            string message = "An error has occoured whilst processing your request. Please try again.";
            _snackbar.Add(message, Severity.Error);
        }

        public async Task<List<CompanyNewsPayload>> fetchCompanyNews(string input)
        {
            List<CompanyNewsPayload> emptyList = new List<CompanyNewsPayload>();
            try
            {
                var urlString = _stringBuilder.CreateCompanyNewsUrl(input);
                var response = await _httpClient.GetAsync(urlString);
                var stringResponse = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<List<CompanyNewsPayload>>(stringResponse);
                }
                else
                {
                    throwSnackBarError();
                    return emptyList;
                }
            }
            catch (Exception e)
            {
                throwSnackBarError();
                Console.WriteLine(e);
                return emptyList;
            }
        }
        public async Task<List<CompanyNewsPayload>> fetchMarketNews()
        {
            List<CompanyNewsPayload> emptyList = new List<CompanyNewsPayload>();
            try
            {

                var urlString = _stringBuilder.CreateMarketNewsUrl();
                var response = await _httpClient.GetAsync(urlString);
                var stringResponse = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<List<CompanyNewsPayload>>(stringResponse);
                }
                else
                {
                    throwSnackBarError();
                    return emptyList;
                }
            }
            catch (Exception e)
            {
                throwSnackBarError();
                Console.WriteLine(e);
                return emptyList;
            }
        }

        public async Task<decimal> fetchConvertedToUSD(decimal amount, string currency)
        {
            try
            {
                var urlString = _stringBuilder.CreateUSDConvert(amount, currency);
                var response = await _httpClient.GetAsync(urlString);
                var stringResponse = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<decimal>(stringResponse);
                }
                else
                {
                    throwSnackBarError();
                    return 0;
                }
            }
            catch (Exception e)
            {
                throwSnackBarError();
                Console.WriteLine(e);
                return 0;
            }
        }

        public async Task<List<CompanyProfilePayload>> fetchAdvancedAutoSearch(AdvancedSearch advancedSearch)
        {
            try
            {
                var urlString = _stringBuilder.CreateAdvancedAutoCompleteUrl(advancedSearch.Symbol, advancedSearch.CompanyName, advancedSearch.Country, advancedSearch.Industry);
                var response = await _httpClient.GetAsync(urlString);
                var stringResponse = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<List<CompanyProfilePayload>>(stringResponse);
                }
                else
                {
                    throwSnackBarError();
                    return new List<CompanyProfilePayload>();
                }
            }
            catch (Exception e)
            {
                throwSnackBarError();
                Console.WriteLine(e);
                return new List<CompanyProfilePayload>();
            }
        }
        public async Task<decimal> fetchConvertedBalance(decimal balance, string currency)
        {
            try
            {
                var urlString = _stringBuilder.CreateBalanceConvert(balance, currency);
                var response = await _httpClient.GetAsync(urlString);
                var stringResponse = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<decimal>(stringResponse);
                }
                else
                {
                    throwSnackBarError();
                    return 0;
                }
            }
            catch(Exception e)
            {
                throwSnackBarError();
                Console.WriteLine(e);
                return 0;
            }
        }

        public async Task<CompanyProfilePayload> fetchCompanyProfile(string input)
        {
            CompanyProfilePayload emptyList = new CompanyProfilePayload();
            try
            {
                var urlString = _stringBuilder.CreateCompanyProfileUrl(input);
                var response = await _httpClient.GetAsync(urlString);
                var stringResponse = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<CompanyProfilePayload>(stringResponse);
                }
                else
                {
                    throwSnackBarError();
                    return emptyList;
                }
            }
            catch (Exception e)
            {
                throwSnackBarError();
                Console.WriteLine(e);
                return emptyList;
            }
        }

        public async Task<List<CurrencyExchangePayload>> fetchCurrencyPayload()
        {
            List<CurrencyExchangePayload> emptyList = new List<CurrencyExchangePayload>();
            try
            {
                var urlstring = _stringBuilder.CreateExchangeRateList();
                var response = await _httpClient.GetAsync(urlstring);
                var stringResponse = await response.Content.ReadAsStringAsync();

                if ((int)response.StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<List<CurrencyExchangePayload>>(stringResponse);
                }
                else
                {
                    throwSnackBarError();
                    return emptyList;
                }
            }
            catch (Exception e)
            {
                throwSnackBarError();
                Console.WriteLine(e);
                return emptyList;
            }
        }

        public async Task<List<AutoCompletePayload>> autoCompleteSymbolSearch(string input)
        {
            List<AutoCompletePayload> emptyList = new List<AutoCompletePayload>();
            
            try
            {
                var urlString = _stringBuilder.CreateAutoCompleteURL(input);
                var response = await _httpClient.GetAsync(urlString);
                var stringResponse = await response.Content.ReadAsStringAsync();
                
                if ((int)response.StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<List<AutoCompletePayload>>(stringResponse);
                }
                else
                {
                    throwSnackBarError();
                    return emptyList;
                }
                
            }
            catch (Exception e)
            {
                throwSnackBarError();
                Console.WriteLine(e);
                return emptyList;
            }
            
        }
        public async Task<List<candleSticksPayload>> fetchCandles(string symbol, string resolution, int fromDate, string currency)
        {
            List<candleSticksPayload> emptyList = new List<candleSticksPayload>();
            try
            {
                var urlstring = _stringBuilder.CreateCandleURL(symbol, resolution, fromDate, currency);
                var response = await _httpClient.GetAsync(urlstring);
                var stringResponse = await response.Content.ReadAsStringAsync();

                if ((int) response.StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<List<candleSticksPayload>>(stringResponse);
                }

                throwSnackBarError();
                return emptyList;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throwSnackBarError();
                return emptyList;
            }
        }

        public async Task<StockQuotePayload> fetchQuote(string symbol, string currency)
        {
            StockQuotePayload emptyQuote = new StockQuotePayload();
            try
            {
                var urlstring = _stringBuilder.CreateQuoteUrl(symbol, currency);
                var response = await _httpClient.GetAsync(urlstring);
                var stringResponse = await response.Content.ReadAsStringAsync();

                if ((int)response.StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<StockQuotePayload>(stringResponse);
                }

                throwSnackBarError();
                return emptyQuote;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throwSnackBarError();
                return emptyQuote;
            }
        }
    }
}
