using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace SharedClasses
{
    public class StocksCandleClass
    {
        public int id { get; set; }
        public string Symbol { get; set; }
        public decimal Close { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Open { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public long Volume { get; set; }
        public DateTimeOffset LastModified { get; set; }
    }
}
