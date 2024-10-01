using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.API.Infrastructure.Models.Employee;

[ExcludeFromCodeCoverage]
public class EmployeeUpsertRequestModel
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public int DepartmentId { get; set; }
    public int ManagerId { get; set; }
    public decimal Salary { get; set; }
}
