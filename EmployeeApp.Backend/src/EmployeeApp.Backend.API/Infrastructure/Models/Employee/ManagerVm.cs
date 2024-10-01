using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.API.Infrastructure.Models.Employee;

[ExcludeFromCodeCoverage]
public class ManagerVm
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
