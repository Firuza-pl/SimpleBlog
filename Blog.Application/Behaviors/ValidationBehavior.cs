using FluentValidation;
using MediatR;

namespace Blog.Application.Behaviors
{
    //NOTES: IPipelineBehavior looks like mediatr pattern. introduce additional behavior around each request that is going through the pipeline without modifying original request.
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        //NOTES: Fluent Validators (IValidator) allows us to scan all project for AbstractValidator implementation for a given type. then provide us an instance at runtime.
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                //NOTES:when exception is occurs due to validation error this excaption handle it.
                throw new ValidationException(failures);
            }

            return await next();
        }

    }
}
