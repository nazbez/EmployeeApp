using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.AppCore.Common.Models;

[ExcludeFromCodeCoverage]
public class PaginatedEmployeeListDto
{
    public IReadOnlyCollection<EmployeeDto> Items { get; set; } = [];
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
}
