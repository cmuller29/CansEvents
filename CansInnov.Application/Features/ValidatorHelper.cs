using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;

namespace CansInnov.Application.Features
{
    public class ValidatorHelper<Validator, Command>
        where Validator : AbstractValidator<Command>
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidatorHelper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task ValidateAsync(Command command, CancellationToken cancellationToken)
        {
            Validator validator = ActivatorUtilities.CreateInstance<Validator>(_serviceProvider);

            ValidationResult result = await validator.ValidateAsync(command, cancellationToken);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}