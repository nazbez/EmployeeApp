using EmployeeApp.Backend.AppCore.Employee.Validators;
using FluentValidation;

namespace EmployeeApp.Backend.AppCore.Employee.Queries.Validators;

public class EmployeeGetByIdQueryValidator : AbstractValidator<EmployeeGetByIdQuery>
{
    public EmployeeGetByIdQueryValidator(EmployeeExistsValidator employeeExistsValidator)
    {
        RuleFor(cmd => cmd.Id)
            .SetValidator(employeeExistsValidator);
    }
}
