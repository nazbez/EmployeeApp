using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.API.Infrastructure.Models.Department;

[ExcludeFromCodeCoverage]
public class DepartmentVm
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
