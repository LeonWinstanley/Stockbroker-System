using System;
using System.Net.Http;
using FluentScheduler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StocksCourseworkAPI.Contexts;
using StocksCourseworkAPI.Services;
using StocksCourseworkAPI.Services.BackgroundServices;

namespace StocksCourseworkAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<StockContext>(options => options.UseSqlite("Data Source=StockDb.db"));
            services.AddScoped<HttpClient>();
            services.AddScoped<StocksService>();
            services.AddScoped<APIStringBuilderService>();
            services.AddHostedService<CandleFetcherSchedulerService>();
            services.AddHostedService<SymbolFetcherSchedulerService>();
            services.AddHostedService<CompanyProfileSchedulerService>();
            services.AddScoped<IScopedProcessingService, ScopedProcessingService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StocksCourseworkAPI", Version = "v1" });
            });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StocksCourseworkAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
