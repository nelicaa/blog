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
    public class CreateUserValidator : AbstractValidator<InsertUserDTO>
    {
        private readonly projekatDbContext _context;
        public CreateUserValidator(projekatDbContext context)
        {
            var imePrezimeRegex = @"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$";

            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Ime je obavezno polje za unos.")
                .MinimumLength(3).WithMessage("Minimalan broj karaktera je 3.")
                .Matches(imePrezimeRegex).WithMessage("Nije u dobrom formatu napisano ime.");

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Ime je obavezno polje za unos.")
                .MinimumLength(3).WithMessage("Minimalan broj karaktera je 3.")
                .Matches(imePrezimeRegex).WithMessage("Nije u dobrom formatu napisano prezime.");

            RuleFor(x => x.Email)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Email je obavezno polje za unos.")
               .EmailAddress().WithMessage("Email nije u ispravnom formatu.")
               .Must(AlreadyExists).WithMessage("Email adresa {PropertyValue} je već u upotrebi. Ne sme biti duplih u bazi.");

            RuleFor(x => x.Username)
              .Cascade(CascadeMode.Stop)
              .NotEmpty().WithMessage("Korisničko ime je obavezno polje za unos.")
              .MinimumLength(3).WithMessage("Minimalan broj karaktera je 3.")
              .Matches("^(?=[a-zA-Z0-9._]{3,12}$)(?!.*[_.]{2})[^_.].*[^_.]$").WithMessage("Korisničko ime nije ispravnog formata.")
              .Must(AlreadyExistsUsername).WithMessage("Korisničko ime {PropertyValue} je već u upotrebi.");


            RuleFor(x => x.Password).NotEmpty().WithMessage("Lozinka je obavezan podatak.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("Lozinka mora da sadrži minimalno 8 karaktera, jedno veliko, jedno malo slovo, broj i specijalni karakter.");

            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Uloga korisnika je obavezan podatak.")
                .Must(roleExists).WithMessage("Uloga mora da postoji u bazi.");

            _context = context;

        }

        private bool AlreadyExists(string name)
        {
            var exists = _context.Users.Any(x => x.Email == name && x.DeletedAt == null);
            return !exists;
        }
        private bool AlreadyExistsUsername(string name)
        {
            var exists = _context.Users.Any(x => x.Username == name && x.DeletedAt == null);
            return !exists;
        }
        private bool roleExists(int id)
        {
            var exists = _context.Roles.Any(x => x.Id == id && x.DeletedAt == null);
            return exists;
        }
    }
}
