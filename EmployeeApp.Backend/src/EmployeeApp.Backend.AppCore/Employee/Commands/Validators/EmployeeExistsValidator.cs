using EmployeeApp.Backend.AppCore.Common.Repository;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.AppCore.Employee.Commands.Validators;

[ExcludeFromCodeCoverage]
public class EmployeeExistsValidator : AbstractValidator<int>
{
    public EmployeeExistsValidator(IEmployeeRepository employeeRepository)
    {
        RuleFor(id => id)
            .MustAsync(async (id, _) => await employeeRepository.ExistsAsync(id))
            .WithMessage(id => $"There is no employee with id {id}");
    }
}
