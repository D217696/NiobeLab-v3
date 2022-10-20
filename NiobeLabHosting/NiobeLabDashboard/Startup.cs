using NiobeLabBot;
namespace NiobeLabDashboard
{
    public class Startup
    {
        public static void Configure()
        {
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddHostedService<NiobeLabBot.Startup>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
