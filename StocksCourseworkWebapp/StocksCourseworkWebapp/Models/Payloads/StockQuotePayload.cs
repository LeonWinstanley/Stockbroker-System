using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StocksCourseworkWebapp.Models.Payloads
{
    public class StockQuotePayload
    {
        [JsonProperty("currentPrice")]
        public decimal CurrentPrice { get; set; }

        [JsonProperty("highPrice")]
        public decimal HighPrice { get; set; }

        [JsonProperty("lowPrice")]
        public decimal LowPrice { get; set; }

        [JsonProperty("openPrice")]
        public decimal OpenPrice { get; set; }

        [JsonProperty("previousClosePrice")]
        public decimal PreviousClosePrice { get; set; }
    }
}
