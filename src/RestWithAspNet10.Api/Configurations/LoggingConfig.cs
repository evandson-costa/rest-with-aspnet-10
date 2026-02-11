using Serilog;

namespace RestWithAspNet10.Configurations;

public static class LoggingConfig
{
    public static void AddSerilog(this WebApplicationBuilder builder)
    {
       Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .WriteTo.Console()
            .WriteTo.Debug()
            .Enrich.FromLogContext()
            .CreateLogger();

            builder.Host.UseSerilog();
    }
}