using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SharedClasses;
using StocksCourseworkAPI.Contexts;
using StocksCourseworkAPI.Models;

namespace StocksCourseworkAPI.Services
{
    public class StocksService
    {
        private readonly StockContext _context;
        private readonly APIStringBuilderService _stringBuilder;
        private readonly HttpClient _httpClient;

        public StocksService(StockContext context, APIStringBuilderService stringBuilder, HttpClient httpClient)
        {
            _context = context;
            _stringBuilder = stringBuilder;
            _httpClient = httpClient;
        }

        public async Task<List<StocksSymbolsClass>> SearchStockSymbol(string input)
        {
            var symbolQueryable = await _context.SymbolData.Where(symbol =>
                symbol.Symbol.Contains(input.ToUpper()) ||
                symbol.CompanyName.Contains(input.ToUpper()) ||
                symbol.Figi.Contains(input.ToUpper()) ||
                symbol.Mic.Contains(input.ToUpper()) ||
                symbol.Type.Contains(input.ToUpper())).ToListAsync();

            var listOfStocks = new List<StocksSymbolsClass>();
            for (var i = 0; i < symbolQueryable.Count; i++)
            {
                var symbolClass = new StocksSymbolsClass
                {
                    Symbol = symbolQueryable[i].Symbol,
                    CompanyName = symbolQueryable[i].CompanyName,
                    Figi = symbolQueryable[i].Figi,
                    Mic = symbolQueryable[i].Mic,
                    Type = symbolQueryable[i].Type
                };

                listOfStocks.Add(symbolClass);
            }

            return listOfStocks;
        }

        public async Task<CompanyProfilePayload> FetchCompanyProfile(string input)
        {

            try
            {
                return await FetchCompanyProfileDb(input.ToUpper());
                var urlstring = await _stringBuilder.CreateCompanyProfileUrl(input);
                var response = await _httpClient.GetAsync(urlstring);
                var stringResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    if (!stringResponse.Contains("no_data"))
                    {

                        var companyProfile = JsonConvert.DeserializeObject<CompanyProfilePayload>(stringResponse);
                        return companyProfile;

                    }

                }
                return await FetchCompanyProfileDb(input.ToUpper());
            }
            catch(Exception e)
            {
                return await FetchCompanyProfileDb(input.ToUpper());
            }
            
        }

        public async Task<CompanyProfilePayload> FetchCompanyProfileDb(string input)
        {
            return await _context.CompanyProfile.FirstOrDefaultAsync(x => x.Symbol == input) ?? new CompanyProfilePayload();
        }

        public async Task FetchCompanyProfileAndSave()
        {
            var urlString = await _stringBuilder.CreateIndicesUrl("^NDX");
            var response = await _httpClient.GetAsync(urlString);
            var stringresponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                if (!stringresponse.Contains("no_data"))
                {

                    var listOfStocks = JsonConvert.DeserializeObject<StockIndiciesPayload>(stringresponse);

                    foreach (var symbol in listOfStocks.Symbol)
                    {
                        var companyProfile = await FetchCompanyProfile(symbol);
                        Thread.Sleep(5000);

                        if (await _context.CompanyProfile.AnyAsync(Cname =>
                            Cname.CompanyName == companyProfile.CompanyName))
                        {
                            var databaseProfiles = await _context.CompanyProfile
                                .Where(Cname => Cname.CompanyName == companyProfile.CompanyName).ToListAsync();
                            foreach (var row in databaseProfiles)
                            {
                                row.Symbol = companyProfile.Symbol;
                                row.CompanyName = companyProfile.CompanyName;
                                row.CompanyUrl = companyProfile.CompanyUrl;
                                row.Country = companyProfile.Country;
                                row.Currency = companyProfile.Currency;
                                row.Exchange = companyProfile.Exchange;
                                row.Industry = companyProfile.Industry;
                                row.IpoDate = companyProfile.IpoDate;
                                row.Logo = companyProfile.Logo;
                                row.MarketCapitalization = companyProfile.MarketCapitalization;
                                row.PhoneNumber = companyProfile.PhoneNumber;
                                row.SharesOutstanding = companyProfile.SharesOutstanding;
                            }
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            await _context.CompanyProfile.AddAsync(companyProfile);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
        }


        public async Task<List<CompanyNewsPayload>> fetchCompanyNews(string symbol)
        {
            var urlstring = await _stringBuilder.CreateCompanyNewsUrl(symbol);
            var response = await _httpClient.GetAsync(urlstring);
            var stringResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                if (!stringResponse.Contains("no_data"))
                {
                    var companyNews = JsonConvert.DeserializeObject<List<CompanyNewsPayload>>(stringResponse);
                    return companyNews;
                }

                return null;
            }

            return null;
        }

        public async Task<StockQuotePayload> FetchQuote(string symbol, string exchangeRate = "USD")
        {
            var urlstring = await _stringBuilder.CreateQuoteUrl(symbol);
            var response = await _httpClient.GetAsync(urlstring);
            var stringResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                if (!stringResponse.Contains("no_data"))
                {
                    var stockQuote = JsonConvert.DeserializeObject<StockQuotePayload>(stringResponse);
                    var fetchedRate = await FetchCurrency(exchangeRate);

                    stockQuote.CurrentPrice = stockQuote.CurrentPrice * fetchedRate.ExchangeRate;
                    stockQuote.HighPrice = stockQuote.HighPrice * fetchedRate.ExchangeRate;
                    stockQuote.LowPrice = stockQuote.LowPrice * fetchedRate.ExchangeRate;
                    stockQuote.OpenPrice = stockQuote.OpenPrice * fetchedRate.ExchangeRate;
                    stockQuote.PreviousClosePrice = stockQuote.PreviousClosePrice * fetchedRate.ExchangeRate;
                    return stockQuote;
                }
            }
            return null;
        }


        public async Task<List<StocksSymbolsClass>> FetchSymbols()
        {
            var urlstring = await _stringBuilder.CreateSymbolsUrl();
            var response = await _httpClient.GetAsync(urlstring);
            var stringResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                if (!stringResponse.Contains("no_data")) //finnhub api sometimes doesn't send unsuccessful code but send "no_data"
                {
                    var StockSymbol = JsonConvert.DeserializeObject<List<StocksSymbolsPayload>>(stringResponse);
                    var listOfStocks = new List<StocksSymbolsClass>();
                    for (var i = 0; i < StockSymbol.Count; i++)
                    {
                        var symbolClass = new StocksSymbolsClass
                        {
                            Symbol = StockSymbol[i].Symbol,
                            CompanyName = StockSymbol[i].CompanyName,
                            Figi = StockSymbol[i].Figi,
                            Mic = StockSymbol[i].Mic,
                            Type = StockSymbol[i].Type
                        };
                        listOfStocks.Add(symbolClass);
                    }
                    return listOfStocks;
                }
                return null;
            }
            return null;
        }

        
        public async Task FetchSymbolsAndSave()
        {
            var listOfSymbols = await FetchSymbols();
            for (var i = 0; i < listOfSymbols.Count; i++)
            {
                if (await _context.SymbolData.AnyAsync(symbol => symbol.Symbol == listOfSymbols[i].Symbol))
                {
                    var databaseSymbols = await _context.SymbolData.Where(symbol => symbol.Symbol == listOfSymbols[i].Symbol).ToListAsync();
                    foreach (var row in databaseSymbols)
                    {
                        row.Symbol = listOfSymbols[i].Symbol;
                        row.CompanyName = listOfSymbols[i].CompanyName;
                        row.Figi = listOfSymbols[i].Figi;
                        row.Mic = listOfSymbols[i].Mic;
                        row.Type = listOfSymbols[i].Type;
                    }
                    await _context.SaveChangesAsync();
                }
                else
                {
                    await _context.SymbolData.AddAsync(listOfSymbols[i]);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<CurrencyExchange> FetchCurrency(string currencyConvert)
        {
            var urlString = await _stringBuilder.CreateExchangeUrl(currencyConvert);
            var response = await _httpClient.GetAsync(urlString);
            var stringrespose = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var currency = JsonConvert.DeserializeObject<CurrencyExchange>(stringrespose);
                return currency;
            }

            var currencyBase = new CurrencyExchange
            {
                ExchangeRate = 1
            };
            return currencyBase;
        }

        public async Task<List<CurrencyExchange>> FetchAllCurrencies()
        {
            var urlstring = await _stringBuilder.CreateExchangeListUrl();
            var response = await _httpClient.GetAsync(urlstring);
            var stringResponse = await response.Content.ReadAsStringAsync();

            if(response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<CurrencyExchange>>(stringResponse);
            }
            List<CurrencyExchange> emptylist = new List<CurrencyExchange>();
            return emptylist;
        }

        public async Task<List<StocksCandleClass>> FetchStockCandle(string symbol, string resolution, int fromDate, string currencyConvert = "USD")
        {
            var urlstring = await _stringBuilder.CreateCandleUrl(symbol, resolution, fromDate);
            var response = await _httpClient.GetAsync(urlstring);
            var stringResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                if (!stringResponse.Contains("no_data"))
                {
                    var StockCandle = JsonConvert.DeserializeObject<StockCandlePayload>(stringResponse);
                    var listOfCandles = new List<StocksCandleClass>();
                    var currency = await FetchCurrency(currencyConvert);
                    for (var i = 0; i < StockCandle.Timestamp.Count; i++)
                    {
                        var candleClass = new StocksCandleClass
                        {
                            Symbol = symbol,
                            Close = StockCandle.Close[i] * currency.ExchangeRate,
                            High = StockCandle.High[i] * currency.ExchangeRate,
                            Low = StockCandle.Low[i] * currency.ExchangeRate,
                            Open = StockCandle.Open[i] * currency.ExchangeRate,
                            Timestamp = StockCandle.Timestamp[i],
                            Volume = StockCandle.Volume[i]
                        };
                        listOfCandles.Add(candleClass);
                    }
                    return listOfCandles;
                }
            }
            return await FetchStockCandleDb(symbol.ToUpper(), currencyConvert);
        }

        public async Task<decimal> ConvertBalance(decimal balance, string currencyConvert = "USD")
        {
            var currency = await FetchCurrency(currencyConvert);
            return balance * currency.ExchangeRate;
        }
        public async Task<List<StocksCandleClass>> FetchStockCandleDb(string symbol, string currencyConvert = "USD")
        {
            var listOfCandles = await _context.CandleData.Where(x => x.Symbol == symbol).ToListAsync();
            if(currencyConvert != "USD")
            {
                var currency = await FetchCurrency(currencyConvert);
                for (var i = 0; i < listOfCandles.Count; i++)
                {
                    listOfCandles[i].Low = listOfCandles[i].Low * currency.ExchangeRate;
                    listOfCandles[i].Open = listOfCandles[i].Open * currency.ExchangeRate;
                    listOfCandles[i].Close = listOfCandles[i].Close * currency.ExchangeRate;
                    listOfCandles[i].High = listOfCandles[i].High * currency.ExchangeRate;
                }
            }
            return listOfCandles;
        }

        public async Task<decimal> ConvertAmountToUSD(decimal amount, string currencyConvert)
        {
            var currency = await FetchCurrency(currencyConvert);
            return amount / currency.ExchangeRate;
        }
        public async Task FetchNasdaq()
        {
            var urlString = await _stringBuilder.CreateIndicesUrl("^NDX");
            var response = await _httpClient.GetAsync(urlString);
            var stringresponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var listOfIndicies = JsonConvert.DeserializeObject<StockIndiciesPayload>(stringresponse);

                foreach (var element in listOfIndicies.Symbol)
                {
                    Thread.Sleep(5000);
                    var listOfCandles = await FetchStockCandle(element, "15", 7);
                    if (listOfCandles != null)
                    {
                        if (await _context.CandleData.AnyAsync(candle => candle.Symbol == element))
                        {
                            var databaseCandles = await _context.CandleData.Where(candle => candle.Symbol == element).ToListAsync();
                            foreach (var row in databaseCandles)
                            {
                                row.Timestamp = listOfCandles.First().Timestamp;
                                row.Close = listOfCandles.First().Close;
                                row.High = listOfCandles.First().High;
                                row.Volume = listOfCandles.First().Volume;
                                row.Low = listOfCandles.First().Low;
                                row.Open = listOfCandles.First().Open;
                                row.LastModified = DateTimeOffset.Now;

                                listOfCandles.Remove(listOfCandles.First());
                            }

                            await _context.SaveChangesAsync();
                        }
                        else
                            await _context.CandleData.AddRangeAsync(listOfCandles);
                            await _context.SaveChangesAsync();
                    }
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("StatusCodeFailed");
            }
            Console.WriteLine("Completed update process");
        }

        public async Task<List<CompanyProfilePayload>> runAdvancedSearch(AdvancedSearchPayload searchQ)
        {
            var ProfileCompany = await _context.CompanyProfile.Where(x => x.CompanyName.ToUpper().Contains(searchQ.CompanyName.ToUpper()) & x.Symbol.ToUpper().Contains(searchQ.Symbol.ToUpper()) & x.Industry.ToUpper().Contains(searchQ.Industry.ToUpper()) & x.Country.ToUpper().Contains(searchQ.Country.ToUpper())).ToListAsync();
            return ProfileCompany;
        }

        public async Task<List<CompanyNewsPayload>> fetchMarketNews()
        {
            var urlstring = await _stringBuilder.CreateMarketsNewsUrl();
            var response = await _httpClient.GetAsync(urlstring);
            var stringResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<CompanyNewsPayload>>(stringResponse);
            }
            return null;
        }
    }
}