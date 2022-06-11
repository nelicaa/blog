using FluentValidation;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.Validators.Users
{
    public class EditUserValidator : AbstractValidator<InsertUserDTO>
    {
        private readonly projekatDbContext _context;
        public EditUserValidator(projekatDbContext context)
        {
            var imePrezimeRegex = @"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$";

            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.Stop)
                .MinimumLength(3).WithMessage("Minimalan broj karaktera je 3.")
                .Matches(imePrezimeRegex).WithMessage("Nije u dobrom formatu napisano ime.");

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.Stop)
                .MinimumLength(3).WithMessage("Minimalan broj karaktera je 3.")
                .Matches(imePrezimeRegex).WithMessage("Nije u dobrom formatu napisano prezime.");

            RuleFor(x => x.Email)
               .Cascade(CascadeMode.Stop)
               .EmailAddress().WithMessage("Email nije u ispravnom formatu.")
               .Must(AlreadyExists).WithMessage("Email adresa {PropertyValue} je već u upotrebi. Ne sme biti duplih u bazi.");

            RuleFor(x => x.Username)
              .Cascade(CascadeMode.Stop)
              .MinimumLength(3).WithMessage("Minimalan broj karaktera je 3.")
              .Matches("^(?=[a-zA-Z0-9._]{3,12}$)(?!.*[_.]{2})[^_.].*[^_.]$").WithMessage("Korisničko ime nije ispravnog formata.")
              .Must(AlreadyExistsUsername).WithMessage("Korisničko ime {PropertyValue} je već u upotrebi.");


            RuleFor(x => x.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("Lozinka mora da sadrži minimalno 8 karaktera, jedno veliko, jedno malo slovo, broj i specijalni karakter.");


            RuleFor(x => x.RoleId)
            .Must(RolesId)
            .WithMessage("Ovaj role id {PropertyValue} ne postoji u bazi. Moguće je uneti samo postojeći id iz baze.")
            .DependentRules(() =>
            RuleFor(x => x.RoleId)
            .Must(adminLast).WithMessage("Mora postojati bar jedan admin. Ovo je jedini u bazi, ne mozete da ga updejtujete.")
            .When(x=>x.RoleId!=2));

                _context = context;

        }

        private bool AlreadyExists(string name)
        {
            var exists = _context.Users.Any(x => x.Email == name );
            return !exists;
        }
        private bool AlreadyExistsUsername(string name)
        {
            var exists = _context.Users.Any(x => x.Username == name);
            return !exists;
        }
        private bool RolesId(int roleId)
        {
            var exists = _context.Roles.Any(x => x.Id == roleId && x.DeletedAt==null);
            return exists;
        }
        private bool adminLast(int roleId)
        {
            var lastAdmin = _context.Users.Where(x => x.RoleId == 2 && x.DeletedAt == null).Count();
            var value = false;

            if (lastAdmin > 1)
            {
                value = true;

            }
            return value;
        }
    }
}
