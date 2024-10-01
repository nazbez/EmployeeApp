using EmployeeApp.Backend.AppCore.Common.Repository;
using MediatR;

namespace EmployeeApp.Backend.AppCore.Employee.Commands;

public record EmployeeDeleteCommand(int Id): IRequest<Unit>
{
    public class EmployeeDeleteCommandHandler : IRequestHandler<EmployeeDeleteCommand, Unit>
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeDeleteCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Task<Unit> Handle(EmployeeDeleteCommand request, CancellationToken cancellationToken)
        {
            employeeRepository.DeleteAsync(request.Id);

            return Task.FromResult(Unit.Value);
        }
    }
}
