using System;
using System.Collections.Generic;
using System.Text;

namespace SharedClasses
{
    public class CurrencyExchange
    {
        public int Id { get; set; }
        public string Base { get; set; }
        public string ExchangeCurrency { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
