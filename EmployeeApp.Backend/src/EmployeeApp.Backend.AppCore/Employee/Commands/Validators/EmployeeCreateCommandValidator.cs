using AutoMapper;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.AppCore.Employee.Commands.Validators;

[ExcludeFromCodeCoverage]
public class EmployeeCreateCommandValidator : AbstractValidator<EmployeeCreateCommand>
{
    public EmployeeCreateCommandValidator(
        IMapper mapper,
        EmployeeUpsertCommandValidator validator)
    {
        RuleFor(cmd => mapper.Map<EmployeeUpsertCommandValidatedModel>(cmd))
            .SetValidator(validator);
    }
}
