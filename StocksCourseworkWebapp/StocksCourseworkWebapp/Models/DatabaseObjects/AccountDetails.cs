using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace StocksCourseworkWebapp.Models.DatabaseObjects
{
    public class AccountDetails
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public decimal AccountBalance { get; set; }
        public decimal AccountBalanceAvailable { get; set; }
        public decimal AccountBalanceConverted { get; set; }
        public string DefaultCurrency { get; set; }
    }
}
