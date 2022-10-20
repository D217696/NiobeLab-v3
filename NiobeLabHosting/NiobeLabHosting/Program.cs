using Microsoft.Extensions.Hosting;

namespace NiobeLabHosting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var host = CreateHostBuilder().Build();
            Console.WriteLine("Tell!");
            Console.ReadKey();
        }

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