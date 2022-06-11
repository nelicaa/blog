using FluentValidation;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.Validators.Posts
{
    public class EditPostValidator : AbstractValidator<CreatePostDTO>
    {
        private readonly projekatDbContext _context;
        public EditPostValidator(projekatDbContext context)
        {
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                
                .MinimumLength(5).WithMessage("Minimalan broj karaktera je 5.")
                .MaximumLength(25).WithMessage("Maksimalan broj karaktera je 25.");


            RuleFor(x => x.Text)
            .Cascade(CascadeMode.Stop)
           
            .MinimumLength(15).WithMessage("Minimalan broj karaktera je 15.")
            .MaximumLength(250).WithMessage("Maksimalan broj karaktera je 250.");


            RuleFor(x => x.CategoryId)
            .Cascade(CascadeMode.Stop)
           
           .Must(CategoryExists).When(x=>x.CategoryId!=0).WithMessage("Id kategorije {PropertyValue} mora da postoji u bazi. Ovaj ne postoji.");

         

                   RuleFor(x => x.PostTag.Select(y => y))
                       .Must(ids => ids.Distinct().Count() == ids.Count())
                       .WithMessage("Jedan tag je moguce jednom odabrati za post.").OverridePropertyName("tagovi");

                   RuleForEach(x => x.PostTag.Select(y => y))
                       .Must(TagExists)
                       .WithMessage("Id taga {PropertyValue} mora da postoji u bazi. Ovaj ne postoji.")
                       .OverridePropertyName("tagovi");

            _context = context;

        }

        private bool CategoryExists(int id)
        {
            var exists = _context.Categories.Any(x => x.Id == id && x.DeletedAt == null);

            return exists;
        }
     

        private bool TagExists(int id)
        {
            var exists = _context.Tags.Any(x => x.Id == id && x.DeletedAt == null);

            return exists;
        }


    }
}


