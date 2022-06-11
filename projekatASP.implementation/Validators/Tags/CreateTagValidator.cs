using FluentValidation;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.Validators.Tags
{
    public class CreateTagValidator : AbstractValidator<TagDTO>
    {
        private readonly projekatDbContext _context;
        public CreateTagValidator(projekatDbContext context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Naziv taga je obavezan za unos.")
                .MinimumLength(3).WithMessage("Minimalan broj karaktera je 3.")
                .Must(TagExists).WithMessage("Naziv taga: {PropertyValue} već postoji u bazi.");
            _context = context;

        }

        private bool TagExists(string name)
        {
            var exists = _context.Tags.Any(x => x.Name == name && x.DeletedAt == null);

            return !exists;
        }
    }
}
