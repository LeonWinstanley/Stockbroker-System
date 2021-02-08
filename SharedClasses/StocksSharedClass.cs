using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace SharedClasses
{
    public class StocksSharedClass
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanySymbol { get; set; }
        public double AvailableShares { get; set; }
        public decimal StockPrice { get; set; }
    }
}
