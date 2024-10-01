using EmployeeApp.Backend.AppCore.Common.Models.Department;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.AppCore.Common.Models.Employee;

[ExcludeFromCodeCoverage]
public class EmployeeUpsertDataDto
{
    public IReadOnlyCollection<DepartmentDto> Departments { get; set; } = [];
    public IReadOnlyCollection<ManagerDto> Managers { get; set; } = [];
}
