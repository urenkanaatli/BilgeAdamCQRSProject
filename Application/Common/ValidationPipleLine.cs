using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Common
{
    public class ValidationPipleLine<TResquest, TResponse> : IPipelineBehavior<TResquest, TResponse>
    {

        private readonly IEnumerable<IValidator<TResquest>> _validators;
        public ValidationPipleLine(IEnumerable<IValidator<TResquest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TResquest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            if (_validators.Any())
            {
                var context = new ValidationContext<TResquest>(request);

                ValidationResult result = await _validators.First().ValidateAsync(context, cancellationToken);

                if (!result.IsValid)
                {
                    throw new ValidationException("validation hatası", result.Errors);
                }

            }



            return await next();
        }
    }
}
