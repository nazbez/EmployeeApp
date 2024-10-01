using EmployeeApp.Backend.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.API.Infrastructure.Models.Employee;

[ExcludeFromCodeCoverage]
public class EmployeeUpsertDataResponseModel
{
    public IReadOnlyCollection<DepartmentVm> Departments { get; set; } = [];
    public IReadOnlyCollection<ManagerVm> Managers { get; set; } = [];
}
