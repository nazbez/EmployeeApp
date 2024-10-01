using FluentValidation;

namespace EmployeeApp.Backend.AppCore.Employee.Queries.Validators;

public class EmployeeGetAllQueryValidator : AbstractValidator<EmployeeGetAllQuery>
{
    public EmployeeGetAllQueryValidator()
    {
        RuleFor(cmd => cmd.PageNumber)
            .GreaterThan(0)
            .WithMessage("Page number should be greater than 0");

        RuleFor(cmd => cmd.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size should be greater than 0"); ;
    }
}
