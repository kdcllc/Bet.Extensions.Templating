using Microsoft.Extensions.Configuration;

using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    public interface IMain
    {
        IConfiguration Configuration { get; set; }

        Task<int> RunAsync();
    }
}