using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace StocksCourseworkAPI.Models
{
    public class StockCandlePayload
    {
        [JsonProperty("c")]
        public List<decimal> Close { get; set; }

        [JsonProperty("h")]
        public List<decimal> High { get; set; }

        [JsonProperty("l")]
        public List<decimal> Low { get; set; }

        [JsonProperty("o")]
        public List<decimal> Open { get; set; }

        [JsonProperty("s")]
        public string Status { get; set; }

        [JsonProperty("t", ItemConverterType = typeof(UnixDateTimeConverter))]
        public List<DateTimeOffset> Timestamp { get; set; }

        [JsonProperty("v")]
        public List<long> Volume { get; set; }
    }
}
