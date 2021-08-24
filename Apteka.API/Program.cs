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

namespace Apteka.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                    path: "C:\\Logs\\Apteka\\logs\\log-.txt",
                    outputTemplate: "{Timestamp: yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information
                ).CreateLogger();


            try
            {
                Log.Information("Dastur yurdi");

                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Dastur yurishda kamchilik yuzaga keldi");
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
                });
    }
}