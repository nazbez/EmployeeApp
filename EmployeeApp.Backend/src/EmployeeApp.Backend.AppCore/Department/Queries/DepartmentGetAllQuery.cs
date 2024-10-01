using AutoMapper;
using EmployeeApp.Backend.AppCore.Common.Models.Department;
using EmployeeApp.Backend.AppCore.Common.Repository;
using MediatR;

namespace EmployeeApp.Backend.AppCore.Department.Queries;

public record DepartmentGetAllQuery : IRequest<IReadOnlyCollection<DepartmentDto>>
{
    public class DepartmentGetAllQueryHandler : IRequestHandler<DepartmentGetAllQuery, IReadOnlyCollection<DepartmentDto>>
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;

        public DepartmentGetAllQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyCollection<DepartmentDto>> Handle(DepartmentGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbResult = await departmentRepository.GetAll();

            return dbResult.Select(mapper.Map<DepartmentDto>).ToList();
        }
    }
}
