using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting;

public static class AppHostingExtensions
{
    /// <summary>
    /// Configure <see cref="IHost"/> with DI services.
    /// </summary>
    /// <param name="host">The instance of <see cref="IHost"/>.</param>
    /// <param name="configure">configure.</param>
    public static void Configure(this IHost host, Action<IServiceProvider> configure)
    {
        using var scope = host.Services.CreateScope();
        configure(scope.ServiceProvider);
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
