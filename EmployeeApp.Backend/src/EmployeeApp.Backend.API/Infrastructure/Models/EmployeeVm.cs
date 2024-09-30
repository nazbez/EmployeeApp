using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.API.Infrastructure.Models;

[ExcludeFromCodeCoverage]
public class EmployeeVm
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Salary { get; set; }
    public required string ManagerName { get; set; }
    public required string DepartmentName { get; set; }
}
