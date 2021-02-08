using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CurrencyExchangeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace StocksCourseworkAPI.Services
{
    public class CurrencyExchangeService
    {

        private readonly HttpClient _httpClient;
        private readonly CurrencyContext _currencyContext;

        public CurrencyExchangeService(HttpClient httpClient, CurrencyContext currencyContext)
        {
            _httpClient = httpClient;
            _currencyContext = currencyContext;
        }

        public List<CurrencyExchange> ConvertPayloadToClass(CurrencyExchangePayload exchangePayload)
        {
            var listOfCurrencyExchnage = new List<CurrencyExchange>();
            foreach (var element in exchangePayload.Rates)
            {
                var currencyExchange = new CurrencyExchange
                {
                    Base = exchangePayload.Base,
                    ExchangeRate = element.Value,
                    ExchangeCurrency = element.Key
                };
                listOfCurrencyExchnage.Add(currencyExchange);
            }
            return listOfCurrencyExchnage;
        }

        public async Task<List<CurrencyExchange>> FetchCurrencyExchangeRates()
        {
            var response = await _httpClient.GetAsync("https://api.exchangeratesapi.io/latest?base=USD");
            var stringResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var exchangeRates = JsonConvert.DeserializeObject<CurrencyExchangePayload>(stringResponse);
                var exchangeRatesSorted = ConvertPayloadToClass(exchangeRates);
                return exchangeRatesSorted;
            }
            return null;
        }

        public async Task<CurrencyExchange> FetchExchangeRate(string exchangeSymbol)
        {
            return await _currencyContext.CurrencyExchanges.FirstOrDefaultAsync(x => x.ExchangeCurrency == exchangeSymbol);
        }

        public async Task<List<CurrencyExchange>> FetchExchangeRateList()
        {
            return await _currencyContext.CurrencyExchanges.ToListAsync();
        }

        public async Task SaveCurrencyExchangeRates()
        {
            var exchangeClass = await FetchCurrencyExchangeRates();
            foreach (var exchangeElement in exchangeClass)
            {
                if (await _currencyContext.CurrencyExchanges.AnyAsync(x =>
                    x.ExchangeCurrency == exchangeElement.ExchangeCurrency))
                {
                    var exchangeQuery =
                        await _currencyContext.CurrencyExchanges
                            .Where(x => x.ExchangeCurrency == exchangeElement.ExchangeCurrency).ToListAsync();

                    foreach (var element in exchangeQuery)
                    {
                        element.ExchangeCurrency = exchangeElement.ExchangeCurrency;
                        element.ExchangeRate = exchangeElement.ExchangeRate;
                        element.Base = exchangeElement.Base;
                    }
                }
                else
                {
                    await _currencyContext.AddAsync(exchangeElement);
                }
                
            }
            await _currencyContext.SaveChangesAsync();
        }
    }
}