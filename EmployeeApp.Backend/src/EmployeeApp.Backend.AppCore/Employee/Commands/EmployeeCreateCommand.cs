using EmployeeApp.Backend.AppCore.Common.Repository;
using MediatR;
using EmployeeEntity = EmployeeApp.Backend.Domain.Entities.Employee;

namespace EmployeeApp.Backend.AppCore.Employee.Commands;

public record EmployeeCreateCommand(
    string Name,
    string Surname,
    int DepartmentId,
    int ManagerId,
    decimal Salary) : IRequest<int>
{
    public class EmployeeCreateCommandHandler : IRequestHandler<EmployeeCreateCommand, int>
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeCreateCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
        {
            var employee = new EmployeeEntity
            {
                Name = $"{request.Name} {request.Surname}",
                ManagerId = request.ManagerId,
                DepartmentId = request.DepartmentId,
                Salary = request.Salary
            };

            return await employeeRepository.CreateAsync(employee);
        }
    }
}
