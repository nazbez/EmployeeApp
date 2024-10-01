using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.AppCore.Common.Models.Employee;

[ExcludeFromCodeCoverage]
public class EmployeeDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Salary { get; set; }
    public required string ManagerName { get; set; }
    public required string DepartmentName { get; set; }
}
