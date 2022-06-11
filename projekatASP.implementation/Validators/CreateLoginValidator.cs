using FluentValidation;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.Validators
{
    public class CreateLoginValidator : AbstractValidator<LoginDTO>
    {
        private readonly projekatDbContext _context;
        public CreateLoginValidator(projekatDbContext context)
        {
            RuleFor(x => x.Email)
                  .Cascade(CascadeMode.Stop)
                  .NotEmpty().WithMessage("Email je obavezno polje za unos.")
                  .EmailAddress().WithMessage("Email nije u ispravnom formatu.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Lozinka je obavezan podatak.")
               .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
               .WithMessage("Lozinka mora da sadrži minimalno 8 karaktera, jedno veliko, jedno malo slovo, broj i specijalni karakter.");


            _context = context;
        }
        }
}
