using Microsoft.Extensions.Configuration;

namespace EmployeeApp.Backend.Infrastructure.Configuration;

public static class ConfigurationExtensions
{
    public static string GetConnectionString(this IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Sql");

        if (!string.IsNullOrEmpty(connectionString))
        {
            return connectionString;
        }
        
        var sqlConnectionStringFile = Environment.GetEnvironmentVariable("ConnectionStrings__SqlFile");

        if (!string.IsNullOrEmpty(sqlConnectionStringFile) && File.Exists(sqlConnectionStringFile))
        {
            return File.ReadAllText(sqlConnectionStringFile).Trim();
        }

        throw new InvalidOperationException("SQL connection string file is not found or not specified.");
    } 
}