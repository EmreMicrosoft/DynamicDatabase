using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DynamicDatabase.Utilities
{
    public class HostBuilder
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}