using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksCourseworkAPI.Models
{
    public class AdvancedSearchPayload
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
    }
}
