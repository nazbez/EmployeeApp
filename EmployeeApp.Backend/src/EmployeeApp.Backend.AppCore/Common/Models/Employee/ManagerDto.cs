using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.AppCore.Common.Models.Employee;

[ExcludeFromCodeCoverage]
public class ManagerDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
