using Microsoft.EntityFrameworkCore;
using StocksCourseworkWebapp.Models.DatabaseObjects;

namespace StocksCourseworkWebapp.Contexts
{
    public class WebAppContext : DbContext
    {
        public DbSet<AccountDetails> AccountDetails { get; set; }
        public DbSet<UserHoldings> UserHoldings { get; set; }
        public WebAppContext(DbContextOptions options) : base(options)
        { }
    }
}
