using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting.Internal;

using Serilog;

namespace Microsoft.Extensions.Hosting;

/// <summary>
/// A Console DI enabled application.
/// </summary>
public sealed class AppHost
{
    private static string[] _args;
    private static string _appName;

    /// <summary>
    /// <see cref="AppHost"/> configurations.
    /// </summary>
    public static IConfiguration Configuration { get; private set; }

    public static IHostEnvironment HostingEnvironment { get; private set; }

    public static void Start(string[] args, string appName = default)
    {
        _args = args;
        _appName = appName;
        Configuration = GetConfiguration();
    }

    public static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder(_args)
                .ConfigureAppConfiguration(configBuilder =>
                {
                    configBuilder.AddConfiguration(Configuration);
                })
                .UseSerilog(Log.Logger);
    }

    public static ILogger CreateSerilogLogger(Action<LoggerConfiguration, IConfiguration, IHostEnvironment> configure = default)
    {
        if (Configuration == null)
        {
            throw new ArgumentException($"{nameof(AppHost.Start)} wasn't called, configuration doesn't exist.");
        }

        var logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.WithProperty("ApplicationContext", Configuration[HostDefaults.ApplicationKey])
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .ReadFrom.Configuration(Configuration);

        configure?.Invoke(logger, Configuration, HostingEnvironment);

        return logger.CreateLogger();
    }

    private static IConfiguration GetConfiguration()
    {
        var initConfigBuilder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddInMemoryCollection()
                                    .AddEnvironmentVariables(prefix: "DOTNET_");

        if (!string.IsNullOrEmpty(_appName))
        {
            var dic = new Dictionary<string, string>
                {
                    { HostDefaults.ApplicationKey, _appName }
                };
            initConfigBuilder.AddInMemoryCollection(dic);
        }

        if (_args != null)
        {
            initConfigBuilder.AddCommandLine(_args);
        }

        var initConfig = initConfigBuilder.Build();

        HostingEnvironment = GetHostingEnvironment(initConfig);

        var intermConfigBuilder = new ConfigurationBuilder();
        var reloadOnChange = initConfig.GetValue("hostBuilder:reloadConfigOnChange", defaultValue: true);

        intermConfigBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: reloadOnChange)
              .AddJsonFile($"appsettings.{HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: reloadOnChange);

        if (HostingEnvironment.IsDevelopment() && !string.IsNullOrEmpty(HostingEnvironment.ApplicationName))
        {
            var appAssembly = Assembly.Load(new AssemblyName(HostingEnvironment.ApplicationName));
            if (appAssembly != null)
            {
                intermConfigBuilder.AddUserSecrets(appAssembly, optional: true, reloadOnChange: reloadOnChange);
            }
        }

        intermConfigBuilder.AddConfiguration(initConfig);

        var intermConfig = intermConfigBuilder.Build();

        var finalConfig = new ConfigurationBuilder();

        if (intermConfig["AzureVault:BaseUrl"] != null)
        {
            finalConfig.AddConfiguration(
                           intermConfigBuilder.AddAzureKeyVault(
                           hostingEnviromentName: HostingEnvironment.EnvironmentName,
                           usePrefix: true,
                           sectionName: "AzureVault"));
        }

        return finalConfig
            .AddConfiguration(initConfig)
            .AddConfiguration(intermConfig)
            .Build();
    }

    private static IHostEnvironment GetHostingEnvironment(IConfiguration configuration)
    {
        var hostingEnvironment = new HostingEnvironment()
        {
            ApplicationName = configuration[HostDefaults.ApplicationKey],
            EnvironmentName = configuration[HostDefaults.EnvironmentKey] ?? Environments.Production,
            ContentRootPath = ResolveContentRootPath(configuration[HostDefaults.ContentRootKey], AppContext.BaseDirectory),
        };

        if (string.IsNullOrEmpty(hostingEnvironment.ApplicationName))
        {
            // Note GetEntryAssembly returns null for the net4x console test runner.
            hostingEnvironment.ApplicationName = Assembly.GetEntryAssembly()?.GetName().Name;
        }

        hostingEnvironment.ContentRootFileProvider = new PhysicalFileProvider(hostingEnvironment.ContentRootPath);

        return hostingEnvironment;
    }

    private static string ResolveContentRootPath(string contentRootPath, string basePath)
    {
        if (string.IsNullOrEmpty(contentRootPath))
        {
            return basePath;
        }

        if (Path.IsPathRooted(contentRootPath))
        {
            return contentRootPath;
        }

        return Path.Combine(Path.GetFullPath(basePath), contentRootPath);
    }
}
