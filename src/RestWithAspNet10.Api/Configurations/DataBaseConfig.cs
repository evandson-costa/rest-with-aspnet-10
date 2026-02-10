using Microsoft.EntityFrameworkCore;
using RestWithAspNet10.Model;

namespace RestWithAspNet10.Configurations;

public static class DataBaseConfig
{
    public static IServiceCollection AddMSSQLServerSQLConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("MSSQLServerSQLConnection:MSSQLServerSQLConnectionString").Value;

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string for MSSQL Server SQL is not configured.");
        }

        services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connectionString));
        return services;
    }
}
