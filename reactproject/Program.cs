using Microsoft.AspNetCore;
using Autofac.Extensions.DependencyInjection;

namespace reactproject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = GetConfiguration();

            CreateWebHostBuilder(configuration, args).Build().Run();
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            return builder;
        }

        public static IWebHostBuilder CreateWebHostBuilder(IConfiguration configuration, string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                        .UseConfiguration(configuration)
                        .UseStartup<Startup>()
                        .ConfigureServices(services => services.AddAutofac())
                        .UseContentRoot(Directory.GetCurrentDirectory());
    }
}