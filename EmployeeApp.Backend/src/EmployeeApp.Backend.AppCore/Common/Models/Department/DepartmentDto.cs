using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.AppCore.Common.Models.Department;

[ExcludeFromCodeCoverage]
public class DepartmentDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
