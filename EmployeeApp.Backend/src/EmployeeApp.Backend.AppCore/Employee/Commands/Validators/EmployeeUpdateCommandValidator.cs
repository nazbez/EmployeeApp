using AutoMapper;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.AppCore.Employee.Commands.Validators;

[ExcludeFromCodeCoverage]
public class EmployeeUpdateCommandValidator : AbstractValidator<EmployeeUpdateCommand>
{
    public EmployeeUpdateCommandValidator(
        EmployeeExistsValidator employeeExistsValidator,
        IMapper mapper,
        EmployeeUpsertCommandValidator employeeUpsertCommandValidator)
    {
        RuleFor(cmd => cmd.Id)
            .SetValidator(employeeExistsValidator);

        RuleFor(cmd => mapper.Map<EmployeeUpsertCommandValidatedModel>(cmd))
            .SetValidator(employeeUpsertCommandValidator);
    }
}
