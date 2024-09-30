using AutoMapper;
using EmployeeApp.Backend.AppCore.Common.Models;
using System.Diagnostics.CodeAnalysis;
using EmployeeEntity = EmployeeApp.Backend.Domain.Entities.Employee;

namespace EmployeeApp.Backend.AppCore.Common.Mapping;

[ExcludeFromCodeCoverage]
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmployeeEntity, EmployeeDto>()
            .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager!.Name))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department!.Name));

        CreateMap<PaginatedEmployeeListDbModel, PaginatedEmployeeListDto>();
    }
}
