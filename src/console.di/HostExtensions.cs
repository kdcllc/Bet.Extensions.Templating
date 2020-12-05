using console.di;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    public static class HostExtensions
    {
        public static void Configure(this IHost host, Action<IServiceProvider> action)
        {
            using var scope = host.Services.CreateScope();
            action(scope.ServiceProvider);
        }

        public static Task<int> ExecuteAsync(this IHost host, Func<Main, Task<int>> action)
        {
            using var scope = host.Services.CreateScope();
            return action(scope.ServiceProvider.GetRequiredService<Main>());
        }
    }
}
