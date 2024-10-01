using EmployeeApp.Backend.AppCore.Common.Repository;
using EmployeeApp.Backend.Infrastructure.Persistence;
using EmployeeApp.Backend.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.Infrastructure;

[ExcludeFromCodeCoverage]
public static class InfrastructureInjectModule
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Sql");

        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(connectionString));

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
    }
}
