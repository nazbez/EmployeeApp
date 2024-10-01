using AutoMapper;
using EmployeeApp.Backend.AppCore.Common.Models.Department;
using EmployeeApp.Backend.AppCore.Common.Models.Employee;
using System.Diagnostics.CodeAnalysis;
using DepartmentEntity = EmployeeApp.Backend.Domain.Entities.Department;
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

        CreateMap<DepartmentEntity, DepartmentDto>();
    }
}
