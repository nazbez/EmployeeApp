﻿using AutoMapper;
using EmployeeApp.Backend.AppCore.Employee.Validators;
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
            .SetValidator(employeeExistsValidator)
            .DependentRules(() =>
            {
                RuleFor(cmd => mapper.Map<EmployeeUpsertCommandValidatedModel>(cmd))
                    .SetValidator(employeeUpsertCommandValidator);

                RuleFor(cmd => cmd)
                    .Must(cmd => cmd.Id != cmd.ManagerId)
                    .WithMessage("Employee cannot be a manager of himself");
            });
    }
}
