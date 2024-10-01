using EmployeeApp.Backend.AppCore.Common.Models.Employee;
using EmployeeApp.Backend.AppCore.Common.Repository;
using EmployeeApp.Backend.Domain.Entities;
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

    public async Task<int> CreateAsync(Employee employee)
    {
        await applicationDbContext.Employees.AddAsync(employee);
        await applicationDbContext.SaveChangesAsync();

        return employee.Id;
    }

    public Task<bool> ExistsAsync(int id)
    {
        return applicationDbContext.Employees.AnyAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(int id, Employee employee)
    {
        applicationDbContext.Employees.Attach(employee);
        applicationDbContext.Entry(employee).State = EntityState.Modified;
        await applicationDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await applicationDbContext.Employees.Where(x => x.Id == id)
            .ExecuteDeleteAsync();
        
        await applicationDbContext.SaveChangesAsync();
    }

    public async Task<bool> IsManagerAsync(int id)
    {
        var employee = await applicationDbContext.Employees
            .Include(x => x.Subordinates)
            .FirstAsync(x => x.Id == id);

        return employee.Subordinates.Count() > 0;
    }

    public Task<List<Employee>> GetAllAsync()
    {
        return applicationDbContext.Employees.AsNoTracking().ToListAsync();
    }
}
