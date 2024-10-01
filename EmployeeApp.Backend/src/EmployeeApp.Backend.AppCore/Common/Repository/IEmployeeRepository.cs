using EmployeeApp.Backend.AppCore.Common.Models.Employee;

namespace EmployeeApp.Backend.AppCore.Common.Repository;

public interface IEmployeeRepository
{
    Task<PaginatedEmployeeListDbModel> GetPaginatedEmployeeListAsync(int pageNumber, int pageSize);
}
