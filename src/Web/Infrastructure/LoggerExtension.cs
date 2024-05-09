using Serilog;

namespace DBR.OCR.Web.Infrastructure;

public static class LoggerExtension
{
    public static void AddLoggerConfig(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, config) =>
        {
            string environment = context.HostingEnvironment.EnvironmentName;

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(environment == "Development"
                    ? $"appsettings.{environment}.json"
                    : "appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            config.ReadFrom.Configuration(context.Configuration);
        });
    }
}
