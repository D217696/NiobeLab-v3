using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace NiobeLabHosting
{
    internal static class Setup
    {
        private static IHostBuilder CreateHostBuilder()
        {
            return new HostBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddBot();
                    //DI stuff goes here
                })
                .ConfigureLogging((context, builder) =>
                {
                    builder
                        .AddConfiguration(context.Configuration.GetSection("Logging"))
                        .AddConsole();
                    if (context.HostingEnvironment.IsDevelopment())
                        builder.AddConsole();
                })
                .UseContentRoot(Directory.GetCurrentDirectory());
        }
    }
}
