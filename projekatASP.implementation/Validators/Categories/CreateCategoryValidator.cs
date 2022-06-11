using FluentValidation;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.Validators.Categories
{
   public class CreateCategoryValidator : AbstractValidator<CategoryDTO>
    {
        private readonly projekatDbContext _context;
        public CreateCategoryValidator(projekatDbContext context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Naziv kategorije je obavezan za unos.")
                .MinimumLength(3).WithMessage("Minimalan broj karaktera je 3.")
                .Must(CategoryExists).WithMessage("Naziv {PropertyValue} već postoji u bazi.");
            _context = context;

        }

        private bool CategoryExists(string name)
        {
            var exists = _context.Categories.Any(x => x.Name == name && x.DeletedAt == null);

            return !exists;
        }
    }
}
