using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.API.Infrastructure.Models.Employee;

[ExcludeFromCodeCoverage]
public class EmployeeDataResponseModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public decimal Salary { get; set; }
    public required ManagerVm Manager { get; set; }
    public required DepartmentVm Department { get; set; }
}
