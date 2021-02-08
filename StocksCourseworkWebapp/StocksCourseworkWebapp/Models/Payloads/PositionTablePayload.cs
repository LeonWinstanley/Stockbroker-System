using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksCourseworkWebapp.Models.Payloads
{
    public class PositionTablePayload
    {
        public string UserName { get; set; }
        public string Symbol { get; set; }
        public decimal PriceBought { get; set; }
        public DateTimeOffset TimeBought { get; set; }
        public decimal PriceSold { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal ProfitLoss { get; set; }
    }
}
