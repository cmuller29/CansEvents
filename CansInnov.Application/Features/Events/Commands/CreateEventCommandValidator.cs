using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CansInnov.Application.Features.Events.Commands
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(x => x.Titre)
                .MaximumLength(50).WithMessage("La taille du Titre dépasse 50 caractères.")
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Description)
               .MaximumLength(500).WithMessage("La taille du Titre dépasse 50 caractères.")
               .NotNull()
               .NotEmpty();

            RuleFor(x => x.DateDebut.Date)
                .GreaterThanOrEqualTo(DateTime.Now.Date);


            RuleFor(x => x.DateFin)
                .GreaterThanOrEqualTo(x => x.DateDebut);
        }
    }
}