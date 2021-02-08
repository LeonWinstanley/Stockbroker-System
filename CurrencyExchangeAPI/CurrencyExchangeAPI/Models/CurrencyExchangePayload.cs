using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchangeAPI.Models
{
    public class CurrencyExchangePayload
    {
        public string Base { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
