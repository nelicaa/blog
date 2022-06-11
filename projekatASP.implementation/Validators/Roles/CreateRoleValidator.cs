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
   public class CreateRoleValidator : AbstractValidator<RoleDTO>
    {
        private readonly projekatDbContext _context;
        public CreateRoleValidator(projekatDbContext context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Naziv uloge je obavezan za unos.")
                .MinimumLength(3).WithMessage("Minimalan broj karaktera je 3.")
                .Must(RoleExists).WithMessage("Naziv {PropertyValue} već postoji u bazi.");
            _context = context;

        }

        private bool RoleExists(string name)
        {
            var exists = _context.Roles.Any(x => x.Name == name && x.DeletedAt == null);

            return !exists;
        }
    }
}
