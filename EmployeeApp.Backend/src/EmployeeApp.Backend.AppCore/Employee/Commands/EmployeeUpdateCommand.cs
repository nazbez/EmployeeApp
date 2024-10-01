using EmployeeApp.Backend.AppCore.Common.Repository;
using MediatR;
using EmployeeEntity = EmployeeApp.Backend.Domain.Entities.Employee;

namespace EmployeeApp.Backend.AppCore.Employee.Commands;

public record EmployeeUpdateCommand(
    string Name,
    string Surname,
    int DepartmentId,
    int ManagerId,
    decimal Salary) : IRequest<Unit>
{
    public int Id { get; set; }

    public class EmployeeUpdateCommandHandler : IRequestHandler<EmployeeUpdateCommand, Unit>
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeUpdateCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Task<Unit> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            var updateDbModel = new EmployeeEntity
            {
                Id = request.Id,
                Name = $"{request.Name} {request.Surname}",
                ManagerId = request.ManagerId,
                DepartmentId = request.DepartmentId,
                Salary = request.Salary
            };

            employeeRepository.UpdateAsync(request.Id, updateDbModel);

            return Task.FromResult(Unit.Value);
        }
    }
}
