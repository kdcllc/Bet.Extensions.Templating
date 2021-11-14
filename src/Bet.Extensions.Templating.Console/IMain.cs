using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Hosting;

/// <summary>
/// The entry point to the console application.
/// </summary>
public interface IMain
{
    /// <summary>
    /// The configurations for the console di application <see cref="AppHost"/>.
    /// </summary>
    IConfiguration Configuration { get; set; }

    /// <summary>
    /// The main entry point to the application.
    /// </summary>
    /// <returns></returns>
    Task<int> RunAsync();
}
