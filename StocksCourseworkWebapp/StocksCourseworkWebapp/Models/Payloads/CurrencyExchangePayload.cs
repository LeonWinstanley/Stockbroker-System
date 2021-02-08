using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksCourseworkWebapp.Models.Payloads
{
    public class CurrencyExchangePayload
    {
        public string Base { get; set; }
        public string ExchangeCurrency { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
