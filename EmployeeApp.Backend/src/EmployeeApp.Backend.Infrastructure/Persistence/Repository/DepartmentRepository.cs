using EmployeeApp.Backend.AppCore.Common.Repository;
using Microsoft.EntityFrameworkCore;
using DepartmentEntity = EmployeeApp.Backend.Domain.Entities.Department;

namespace EmployeeApp.Backend.Infrastructure.Persistence.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext applicationDbContext;

    public DepartmentRepository(ApplicationDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public Task<List<DepartmentEntity>> GetAll()
    {
        return applicationDbContext.Departments.AsNoTracking().ToListAsync();
    }
}
