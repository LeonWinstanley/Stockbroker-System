using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StocksCourseworkWebapp.Models.Payloads
{
    public class CompanyProfilePayload
    {

        [JsonProperty("country")]
        public string Country { get; set; } 

        [JsonProperty("currency")]
        public string Currency { get; set; } 

        [JsonProperty("exchange")]
        public string Exchange { get; set; } 

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }  

        [JsonProperty("symbol")]
        public string Symbol { get; set; } 

        [JsonProperty("ipoDate")]
        public string IpoDate { get; set; } 

        [JsonProperty("marketCapitalization")]
        public double MarketCapitalization { get; set; } 

        [JsonProperty("sharesOutstanding")]
        public double SharesOutstanding { get; set; } 

        [JsonProperty("logo")]
        public string Logo { get; set; } 

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("companyUrl")]
        public string CompanyUrl { get; set; } 

        [JsonProperty("industry")]
        public string Industry { get; set; }

    }
}
