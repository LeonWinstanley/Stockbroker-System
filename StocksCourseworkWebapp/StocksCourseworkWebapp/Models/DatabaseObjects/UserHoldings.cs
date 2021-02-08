using System;

namespace StocksCourseworkWebapp.Models.DatabaseObjects
{
    public class UserHoldings
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Symbol { get; set; }
        public decimal PriceBought { get; set; }
        public DateTimeOffset TimeBought { get; set; }
        public decimal PriceSold { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }

    }
}
