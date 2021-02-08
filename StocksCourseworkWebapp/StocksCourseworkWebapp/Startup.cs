using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor;
using MudBlazor.Services;
using StocksCourseworkWebapp.Services;
using StocksCourseworkWebapp.Contexts;
using StocksCourseworkWebapp.Models.Payloads;
using Syncfusion.Blazor;

namespace StocksCourseworkWebapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("Identity.Application")
                .AddCookie();

            
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient<UserService>();
            services.AddTransient<APIService>();
            services.AddTransient<HttpClient>();
            services.AddTransient<APIStringBuilderService>();
            services.AddDbContext<WebAppContext>(options => options.UseSqlite("Data Source=WebAppDb.db"));
            services.AddMudBlazorDialog();
            services.AddMudBlazorSnackbar();
            services.AddMudBlazorResizeListener();
            services.AddSyncfusionBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzg0MDEwQDMxMzgyZTM0MmUzMEZxWDhJNnp2WE5RVXkyalVuME9aUzJYc3lmc0hUWjlYRHZKTE1maU5TN289");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
