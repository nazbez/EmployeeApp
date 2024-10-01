using DepartmentEntity = EmployeeApp.Backend.Domain.Entities.Department;

namespace EmployeeApp.Backend.AppCore.Common.Repository;

public interface IDepartmentRepository
{
    Task<List<DepartmentEntity>> GetAllAsync();
    Task<bool> ExistsAsync(int id);
}
