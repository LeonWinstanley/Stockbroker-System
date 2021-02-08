using CurrencyExchangeAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace StocksCourseworkAPI
{
    public class CurrencyContext : DbContext
    {
        public DbSet<CurrencyExchange> CurrencyExchanges { get; set; }
        public CurrencyContext(DbContextOptions<CurrencyContext> options) :base(options){}
    }

}
