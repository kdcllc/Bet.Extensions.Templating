using Console.Di;

using Microsoft.Extensions.Hosting;

using Serilog;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConsoleServiceCollectionExtensions
    {
        public static void ConfigureServices(HostBuilderContext hostBuilder, IServiceCollection services)
        {
            services.AddScoped<Main>();
        }
    }
}
