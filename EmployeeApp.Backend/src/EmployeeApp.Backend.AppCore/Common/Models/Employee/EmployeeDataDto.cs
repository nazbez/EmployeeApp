using EmployeeApp.Backend.AppCore.Common.Models.Department;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.AppCore.Common.Models.Employee;

[ExcludeFromCodeCoverage]
public class EmployeeDataDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public decimal Salary { get; set; }
    public required ManagerDto Manager { get; set; }
    public required DepartmentDto Department { get; set; }
}
