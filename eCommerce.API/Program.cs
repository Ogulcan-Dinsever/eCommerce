using eCommerce.API.Enricher;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
               .WriteTo.Seq("http://localhost:5341")
               .MinimumLevel.Information()
               .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
               .Enrich.WithProperty("AppName", "eCommerce")
               .Enrich.WithProperty("Environment", "development")
               .Enrich.With(new ThreadIdEnricher())
               .CreateLogger();
                Log.Information("Starting web host");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(config => config.ClearProviders()).UseSerilog();
    }
}
