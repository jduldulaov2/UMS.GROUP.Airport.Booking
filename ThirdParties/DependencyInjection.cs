using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog.Events;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddThirdParties(this IServiceCollection services)
    {
        // Add Serilog
        services.AddSerilog();

        return services;
    }

    private static IServiceCollection AddSerilog(this IServiceCollection services)
    {
        services.AddLogging((logging) =>
        {
            // Configure Serilog
            var logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Seq(serverUrl: "http://localhost:5341")
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            logging.ClearProviders();
            logging.AddSerilog(logger);
        });

        return services;
    }
}
