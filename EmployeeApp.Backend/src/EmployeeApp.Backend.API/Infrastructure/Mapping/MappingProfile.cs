using AutoMapper;
using EmployeeApp.Backend.API.Infrastructure.Models.Employee;
using EmployeeApp.Backend.AppCore.Common.Models.Department;
using EmployeeApp.Backend.AppCore.Common.Models.Employee;
using EmployeeApp.Backend.AppCore.Employee.Commands;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.API.Infrastructure.Mapping;

[ExcludeFromCodeCoverage]
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmployeeDto, EmployeeVm>();

        CreateMap<PaginatedEmployeeListDto, PaginatedEmployeeListResponseModel>();

        CreateMap<DepartmentDto, DepartmentVm>();

        CreateMap<EmployeeUpsertRequestModel, EmployeeCreateCommand>();

        CreateMap<EmployeeUpsertRequestModel, EmployeeUpdateCommand>();

        CreateMap<ManagerDto, ManagerVm>();

        CreateMap<EmployeeUpsertDataDto, EmployeeUpsertDataResponseModel>();

        CreateMap<EmployeeDataDto, EmployeeDataResponseModel>();
    }
}
