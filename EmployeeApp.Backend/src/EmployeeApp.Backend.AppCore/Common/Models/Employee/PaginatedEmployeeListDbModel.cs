using System.Diagnostics.CodeAnalysis;
using EmployeeEntity = EmployeeApp.Backend.Domain.Entities.Employee;

namespace EmployeeApp.Backend.AppCore.Common.Models.Employee;

[ExcludeFromCodeCoverage]
public class PaginatedEmployeeListDbModel
{
    public IReadOnlyCollection<EmployeeEntity> Items { get; } = [];
    public int PageNumber { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    public PaginatedEmployeeListDbModel(IReadOnlyCollection<EmployeeEntity> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }
}
