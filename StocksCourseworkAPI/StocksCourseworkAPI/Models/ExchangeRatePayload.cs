using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StocksCourseworkAPI.Models
{
    public class ExchangeRatePayload
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("exchangeCurrency")]
        public string ExchangeCurrency { get; set; }

        [JsonProperty("exchangeRate")]
        public decimal ExchangeRate { get; set; }
    }
}
