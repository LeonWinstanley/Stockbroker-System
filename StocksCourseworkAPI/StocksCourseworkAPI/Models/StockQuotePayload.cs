using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StocksCourseworkAPI.Services
{
    public class StockQuotePayload
    {
        [JsonProperty("c")]
        public decimal CurrentPrice { get; set; }

        [JsonProperty("h")]
        public decimal HighPrice { get; set; }

        [JsonProperty("l")]
        public decimal LowPrice { get; set; }

        [JsonProperty("o")]
        public decimal OpenPrice { get; set; }

        [JsonProperty("pc")]
        public decimal PreviousClosePrice { get; set; }

    }
}
