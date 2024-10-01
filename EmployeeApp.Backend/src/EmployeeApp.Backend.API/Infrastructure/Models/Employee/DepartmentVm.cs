using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.API.Infrastructure.Models.Employee;

[ExcludeFromCodeCoverage]
public class DepartmentVm
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
