using FluentValidation;
using MediatR;
using System.Diagnostics.CodeAnalysis;
using ValidationException = FluentValidation.ValidationException;

namespace EmployeeApp.Backend.AppCore.Common.Behaviours;

[ExcludeFromCodeCoverage]
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        this.validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var failures = (await Task.WhenAll(validators.Select(x => x.ValidateAsync(context))))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .ToList();

        if (failures.Any())
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}
