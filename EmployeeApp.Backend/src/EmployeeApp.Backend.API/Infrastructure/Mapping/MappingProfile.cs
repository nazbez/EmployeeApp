using AutoMapper;
using EmployeeApp.Backend.API.Infrastructure.Models.Department;
using EmployeeApp.Backend.API.Infrastructure.Models.Employee;
using EmployeeApp.Backend.AppCore.Common.Models.Department;
using EmployeeApp.Backend.AppCore.Common.Models.Employee;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.API.Infrastructure.Mapping;

[ExcludeFromCodeCoverage]
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmployeeDto, EmployeeVm>();

        CreateMap<PaginatedEmployeeListDto, PaginatedEmployeeListResponse>();

        CreateMap<DepartmentDto, DepartmentVm>();
    }
}
