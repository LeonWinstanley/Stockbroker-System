using System;
using Newtonsoft.Json;

namespace StocksCourseworkWebapp.Models.Payloads
{
    public class candleSticksPayload
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("close")]
        public double Close { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("open")]
        public double Open { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }
    }
}
