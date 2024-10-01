using AutoMapper;
using EmployeeApp.Backend.AppCore.Common.Models.Department;
using EmployeeApp.Backend.AppCore.Common.Models.Employee;
using EmployeeApp.Backend.AppCore.Employee.Commands.Validators;
using EmployeeApp.Backend.AppCore.Employee.Commands;
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
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Name.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]))
            .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager!.Name))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department!.Name));

        CreateMap<PaginatedEmployeeListDbModel, PaginatedEmployeeListDto>();

        CreateMap<DepartmentEntity, DepartmentDto>();

        CreateMap<EmployeeCreateCommand, EmployeeUpsertCommandValidatedModel>();

        CreateMap<EmployeeUpdateCommand, EmployeeUpsertCommandValidatedModel>();

        CreateMap<EmployeeEntity, ManagerDto>();

        CreateMap<EmployeeEntity, EmployeeDataDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Name.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]));
    }
}
