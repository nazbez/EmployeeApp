using EmployeeApp.Backend.AppCore.Common.Repository;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.AppCore.Employee.Commands.Validators;

[ExcludeFromCodeCoverage]
public class EmployeeUpsertCommandValidatedModel
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public int DepartmentId { get; set; }
    public int ManagerId { get; set; }
    public decimal Salary { get; set; }
}

[ExcludeFromCodeCoverage]
public class EmployeeUpsertCommandValidator : AbstractValidator<EmployeeUpsertCommandValidatedModel>
{
    public EmployeeUpsertCommandValidator(
        IEmployeeRepository employeeRepository, 
        IDepartmentRepository departmentRepository)
    {
        RuleFor(cmd => cmd.Name)
            .NotEmpty()
            .WithMessage("Name should not be empty");

        RuleFor(cmd => cmd.Surname)
            .NotEmpty()
            .WithMessage("Surname should not be empty");

        RuleFor(cmd => cmd.Salary)
            .GreaterThan(0)
            .WithMessage("Salary should be greater than 0");

        RuleFor(cmd => cmd.ManagerId)
            .MustAsync(async (id, _) => await employeeRepository.ExistsAsync(id))
            .WithMessage(model => $"Manager with id = {model.ManagerId} does not exist");

        RuleFor(cmd => cmd.DepartmentId)
            .MustAsync(async (id, _) => await departmentRepository.ExistsAsync(id))
            .WithMessage(model => $"Department with id = {model.DepartmentId} does not exist");
    }
}
