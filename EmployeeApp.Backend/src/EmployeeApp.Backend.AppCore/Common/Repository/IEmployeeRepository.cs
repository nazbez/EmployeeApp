using EmployeeApp.Backend.AppCore.Common.Models.Employee;
using EmployeeEntity = EmployeeApp.Backend.Domain.Entities.Employee;

namespace EmployeeApp.Backend.AppCore.Common.Repository;

public interface IEmployeeRepository
{
    Task<PaginatedEmployeeListDbModel> GetPaginatedEmployeeListAsync(int pageNumber, int pageSize);
    Task<int> CreateAsync(EmployeeEntity employee);
    Task<bool> ExistsAsync(int id);
    Task UpdateAsync(int id, EmployeeEntity employee);
    Task DeleteAsync(int id);
    Task<bool> IsManagerAsync(int id);
    Task<List<EmployeeEntity>> GetAllAsync();
    Task<EmployeeEntity> GetByIdAsync(int id);
}
