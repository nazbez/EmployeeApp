using AutoMapper;
using EmployeeApp.Backend.API.Infrastructure.Models;
using EmployeeApp.Backend.AppCore.Common.Models;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.API.Infrastructure.Mapping;

[ExcludeFromCodeCoverage]
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmployeeDto, EmployeeVm>();

        CreateMap<PaginatedEmployeeListDto, PaginatedEmployeeListResponse>();
    }
}
