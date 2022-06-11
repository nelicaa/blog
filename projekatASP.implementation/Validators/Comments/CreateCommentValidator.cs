using FluentValidation;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.Validators.Comments
{
  public  class CreateCommentValidator : AbstractValidator<CommentDTO>
    {
        private readonly projekatDbContext _context;

        public CreateCommentValidator(projekatDbContext context)
        {
            RuleFor(x => x.Comment)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Komentar ne sme da bude prazno polje.")
                .MinimumLength(10).WithMessage("Minimalan broj karaktera je 10.");

            RuleFor(x => x.UserId)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("User ne sme da bude prazno polje.")
               .Must(userExists).WithMessage("User sa id {PropertyValue} mora da postoji u bazi. Ovaj ne postoji.");


            RuleFor(x => x.PostId)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Post ne sme da bude prazno polje.")
               .Must(postExists).WithMessage("Post sa id {PropertyValue} mora da postoji u bazi. Ovaj ne postoji.");

            RuleFor(x => x.Rate)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Ocena ne sme da bude prazno polje.")
               .LessThan(6).WithMessage("Ocena je najveca 5.")
               .GreaterThan(0).WithMessage("Ocena je najmanja 1.");


            _context = context;

        }

        public bool userExists(int id)
        {
           var exists= _context.Users.Any(x => x.Id == id && x.DeletedAt == null);
            return exists;
        }
        public bool postExists(int id)
        {
            var exists = _context.Posts.Any(x => x.Id == id && x.DeletedAt == null);
            return exists;
        }
    }
}
