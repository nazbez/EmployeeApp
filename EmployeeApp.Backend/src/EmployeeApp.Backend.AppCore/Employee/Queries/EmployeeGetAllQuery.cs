using AutoMapper;
using EmployeeApp.Backend.AppCore.Common.Models.Employee;
using EmployeeApp.Backend.AppCore.Common.Repository;
using MediatR;

namespace EmployeeApp.Backend.AppCore.Employee.Queries;

public record EmployeeGetAllQuery(int PageNumber, int PageSize) : IRequest<PaginatedEmployeeListDto>
{
    public class EmployeeGetAllQueryHandler : IRequestHandler<EmployeeGetAllQuery, PaginatedEmployeeListDto>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeGetAllQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public async Task<PaginatedEmployeeListDto> Handle(EmployeeGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbResult = await employeeRepository.GetPaginatedEmployeeListAsync(request.PageNumber, request.PageSize);

            return mapper.Map<PaginatedEmployeeListDto>(dbResult);
        }
    }
}
