using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace console.di
{
    public class Main
    {
        private ILogger<Main> _logger;

        public IConfiguration Configuration { get; set; }

        public Main(IConfiguration configuration, ILogger<Main> logger)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<int> RunAsync()
        {
            _logger.LogInformation("Main executed");
            return Task.FromResult(0);
        }
    }
}
