using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Pipelines
{
    public class ValidationBehavior<TIn, TOut> : IPipelineBehavior<TIn, TOut>
        where TIn : IRequest<TOut>
    {
        private readonly IEnumerable<IValidator<TIn>> _validators;
        public ValidationBehavior(
                IEnumerable<IValidator<TIn>> validators
            )
        {
            _validators = validators;
        }

        public Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            var context = new ValidationContext<TIn>(request);
            var failrues = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null);

            if (failrues.Any())
            {
                throw new ValidationException(failrues);
            }
            return next();
        }
    }
}
