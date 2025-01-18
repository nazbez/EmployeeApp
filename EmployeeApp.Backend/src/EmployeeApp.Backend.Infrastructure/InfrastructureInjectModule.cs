using EmployeeApp.Backend.AppCore.Common.Repository;
using EmployeeApp.Backend.Infrastructure.Persistence;
using EmployeeApp.Backend.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Config = EmployeeApp.Backend.Infrastructure.Configuration.ConfigurationExtensions;

namespace EmployeeApp.Backend.Infrastructure;

[ExcludeFromCodeCoverage]
public static class InfrastructureInjectModule
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Config.GetConnectionString(configuration);

        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(connectionString));

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
    }
}
