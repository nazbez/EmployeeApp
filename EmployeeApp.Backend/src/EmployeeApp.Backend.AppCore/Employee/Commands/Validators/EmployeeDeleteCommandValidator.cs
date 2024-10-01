using EmployeeApp.Backend.AppCore.Common.Repository;
using EmployeeApp.Backend.AppCore.Employee.Validators;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.AppCore.Employee.Commands.Validators;

[ExcludeFromCodeCoverage]
public class EmployeeDeleteCommandValidator : AbstractValidator<EmployeeDeleteCommand>
{
    public EmployeeDeleteCommandValidator(
        EmployeeExistsValidator employeeExistsValidator,
        IEmployeeRepository employeeRepository)
    {
        RuleFor(cmd => cmd.Id)
            .SetValidator(employeeExistsValidator)
            .DependentRules(() =>
            {
                RuleFor(cmd => cmd.Id)
                    .MustAsync(async (id, _) => !(await employeeRepository.IsManagerAsync(id)))
                    .WithMessage(cmd => $"Employe with id = {cmd.Id} is manager. Cannot be deleted");
            });
    }
}
