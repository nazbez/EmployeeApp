using AutoMapper;
using EmployeeApp.Backend.AppCore.Common.Models.Department;
using EmployeeApp.Backend.AppCore.Common.Models.Employee;
using EmployeeApp.Backend.AppCore.Common.Repository;
using MediatR;

namespace EmployeeApp.Backend.AppCore.Employee.Queries;

public class EmployeeGetUpsertDataQuery : IRequest<EmployeeUpsertDataDto>
{
    public class EmployeeGetUpsertDataQueryHandler : IRequestHandler<EmployeeGetUpsertDataQuery, EmployeeUpsertDataDto>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;

        public EmployeeGetUpsertDataQueryHandler(
            IEmployeeRepository employeeRepository, 
            IDepartmentRepository departmentRepository, 
            IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }

        public async Task<EmployeeUpsertDataDto> Handle(EmployeeGetUpsertDataQuery request, CancellationToken cancellationToken)
        {
            var depertmentsDbResult = await departmentRepository.GetAllAsync();
            var employeesDbResult = await employeeRepository.GetAllAsync();

            var departmentDtos = depertmentsDbResult.Select(mapper.Map<DepartmentDto>).ToList();
            var managerDto = employeesDbResult.Select(mapper.Map<ManagerDto>).ToList();

            return new EmployeeUpsertDataDto 
            { 
                Departments = departmentDtos, 
                Managers = managerDto 
            };
        }
    }
}
