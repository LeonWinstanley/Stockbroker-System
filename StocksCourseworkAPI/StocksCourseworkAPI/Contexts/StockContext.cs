using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SharedClasses;
using StocksCourseworkAPI.Models;


namespace StocksCourseworkAPI.Contexts
{
    public class StockContext : DbContext
    {
        public DbSet<StocksSharedClass> StocksData { get; set; }
        public DbSet<StocksCandleClass> CandleData { get; set; }
        public DbSet<StocksSymbolsClass> SymbolData { get; set; }
        public DbSet<CompanyProfilePayload> CompanyProfile { get; set; }
        public StockContext(DbContextOptions<StockContext> options) : base(options)
        {
        }
    }
}
