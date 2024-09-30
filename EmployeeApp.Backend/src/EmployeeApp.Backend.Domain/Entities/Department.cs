using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Department
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public ICollection<Employee> Employees = []; 
}
