using NiobeLabBot;

namespace NiobeLabDashboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var host = CreateHostBuilder().Build();
            host.Run();

        }

        private static IHostBuilder CreateHostBuilder()
        {
            return new HostBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                //.ConfigureServices((hostContext, services) =>
                //{
                //    services.AddHostedMyService();
                //})
                //.ConfigureLogging((context, builder) =>
                //{
                //    builder
                //        .AddConfiguration(context.Configuration.GetSection("Logging"))
                //        .AddConsole();
                //    if (context.HostingEnvironment.IsDevelopment())
                //        builder.AddConsole();
                //})
                .UseContentRoot(Directory.GetCurrentDirectory());
        }
    }
}