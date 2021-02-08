using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StocksCourseworkAPI.Models
{
    public class CompanyProfilePayload
    {
        public int id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }

        [JsonProperty("name")]
        public string CompanyName { get; set; }

        [JsonProperty("ticker")]
        public string Symbol { get; set; }

        [JsonProperty("ipo")]
        public string IpoDate { get; set; }

        [JsonProperty("marketCapitalization")]
        public double MarketCapitalization { get; set; }

        [JsonProperty("shareOutstanding")]
        public double SharesOutstanding { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }

        [JsonProperty("weburl")]
        public string CompanyUrl { get; set; }

        [JsonProperty("finnhubIndustry")]
        public string Industry { get; set; }
    }
}
