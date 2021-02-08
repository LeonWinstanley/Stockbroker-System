using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StocksCourseworkAPI.Models
{
    public class StockIndiciesPayload
    {
        [JsonProperty("constituents")]
        public List<string> Symbol { get; set; }
    }
}
