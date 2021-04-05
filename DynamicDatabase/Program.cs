using Microsoft.Extensions.Hosting;

namespace DynamicDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Utilities.HostBuilder
                .CreateHostBuilder(args).Build().Run();
        }
    }
}