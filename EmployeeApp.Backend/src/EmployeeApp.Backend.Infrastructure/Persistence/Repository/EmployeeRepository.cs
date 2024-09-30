using EmployeeApp.Backend.AppCore.Common.Models;
using EmployeeApp.Backend.AppCore.Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Backend.Infrastructure.Persistence.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext applicationDbContext;

    public EmployeeRepository(ApplicationDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<PaginatedEmployeeListDbModel> GetPaginatedEmployeeListAsync(int pageNumber, int pageSize)
    {
        var query = applicationDbContext.Employees.Include(x => x.Department)
            .Include(x => x.Manager);

        var count = await query.CountAsync();
        
        var items = await query.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedEmployeeListDbModel(items, count, pageNumber, pageSize);
    }
}
