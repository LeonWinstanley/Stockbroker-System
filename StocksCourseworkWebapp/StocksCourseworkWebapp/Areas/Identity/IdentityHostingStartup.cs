using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StocksCourseworkWebapp.Data;

[assembly: HostingStartup(typeof(StocksCourseworkWebapp.Areas.Identity.IdentityHostingStartup))]
namespace StocksCourseworkWebapp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<StocksCourseworkWebappContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("StocksCourseworkWebappContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<StocksCourseworkWebappContext>();
            });
        }
    }
}