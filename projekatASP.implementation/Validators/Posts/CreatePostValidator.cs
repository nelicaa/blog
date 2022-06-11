using FluentValidation;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.Validators.Posts
{
   public class CreatePostValidator : AbstractValidator<CreatePostDTO>
    {
        private readonly projekatDbContext _context;
        public CreatePostValidator(projekatDbContext context)
        {
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Naziv posta je obavezan za unos.")
                .MinimumLength(5).WithMessage("Minimalan broj karaktera je 5.")
                .MaximumLength(25).WithMessage("Maksimalan broj karaktera je 25.");

            RuleFor(x => x.Text)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Tekst posta je obavezan za unos.")
            .MinimumLength(15).WithMessage("Minimalan broj karaktera je 15.")
            .MaximumLength(250).WithMessage("Maksimalan broj karaktera je 250.");

            RuleFor(x => x.MainPic)
                .NotEmpty().WithMessage("Slika je obavezna za unos.");

            RuleFor(x => x.CategoryId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Kategorija je obavezna za unos.")
           .Must(CategoryExists).WithMessage("Id kategorije {PropertyValue} mora da postoji u bazi. Ovaj ne postoji.");

            RuleFor(x => x.UserId)
           .Cascade(CascadeMode.Stop)
           .NotEmpty().WithMessage("Korisnik je obavezan za unos.")
          .Must(UserExists).WithMessage("Korisnik {PropertyValue} mora da postoji u bazi. Ovaj ne postoji.");


            RuleFor(x => x.PostTag.Select(y => y))
                .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage("Mora da se unese makar jedan tag.")
               .DependentRules(() =>
               {
                   RuleFor(x => x.PostTag.Select(y => y))
                       .Must(ids => ids.Distinct().Count() == ids.Count())
                       .WithMessage("Jedan tag je moguce jednom odabrati za post.").OverridePropertyName("tagovi");

                   RuleForEach(x => x.PostTag.Select(y => y))
                       .Must(TagExists)
                       .WithMessage("Id taga {PropertyValue} mora da postoji u bazi. Ovaj ne postoji.")
                       .OverridePropertyName("tagovi");

               });
            _context = context;

               }

        private bool CategoryExists(int id)
        {
            var exists = _context.Categories.Any(x => x.Id == id && x.DeletedAt == null);

            return exists;
        }
        private bool UserExists(int id)
        {
            var exists = _context.Users.Any(x => x.Id == id && x.DeletedAt == null);

            return exists;
        }

        private bool TagExists(int id)
        {
            var exists = _context.Tags.Any(x => x.Id == id && x.DeletedAt == null);

            return exists;
        }


    }
}

