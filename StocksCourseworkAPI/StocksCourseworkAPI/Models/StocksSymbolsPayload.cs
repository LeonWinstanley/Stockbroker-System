using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StocksCourseworkAPI.Models
{
    public class StocksSymbolsPayload
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("description")]
        public string CompanyName { get; set; }

        [JsonProperty("figi")]
        public string Figi { get; set; }

        [JsonProperty("mic")]
        public string Mic { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
