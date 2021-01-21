using Microsoft.Extensions.DependencyInjection;

using System;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    public static class AppHostingExtensions
    {
        public static void Configure(this IHost host, Action<IServiceProvider> action)
        {
            using var scope = host.Services.CreateScope();
            action(scope.ServiceProvider);
        }

        public static Task<int> ExecuteAsync(this IHost host, Func<IMain, Task<int>> action)
        {
            using var scope = host.Services.CreateScope();
            return action(scope.ServiceProvider.GetRequiredService<IMain>());
        }

        public static Task<int> ExecuteAsync<T>(this IHost host, Func<T, Task<int>> action) where T : class
        {
            using var scope = host.Services.CreateScope();
            return action(scope.ServiceProvider.GetRequiredService<T>());
        }
    }
}
