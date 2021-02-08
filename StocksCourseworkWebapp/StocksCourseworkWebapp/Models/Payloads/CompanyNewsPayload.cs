using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StocksCourseworkWebapp.Models.Payloads
{
    public class CompanyNewsPayload
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("datetime")]
        public int DateOfRelease { get; set; }

        [JsonProperty("headline")]
        public string Headline { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("related")]
        public string Related { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }
    }
}
