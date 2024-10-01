using AutoMapper;
using EmployeeApp.Backend.AppCore.Common.Models.Employee;
using EmployeeApp.Backend.AppCore.Common.Repository;
using MediatR;

namespace EmployeeApp.Backend.AppCore.Employee.Queries;

public record EmployeeGetByIdQuery(int Id) : IRequest<EmployeeDataDto>
{
    public class EmployeeGetByIdQueryHandler : IRequestHandler<EmployeeGetByIdQuery, EmployeeDataDto>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeGetByIdQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public async Task<EmployeeDataDto> Handle(EmployeeGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbResult = await employeeRepository.GetByIdAsync(request.Id);

            return mapper.Map<EmployeeDataDto>(dbResult);
        }
    }
}
