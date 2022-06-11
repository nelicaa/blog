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
    public class EditCommentValidator : AbstractValidator<CommentDTO>
    {
        private readonly projekatDbContext _context;
        public EditCommentValidator(projekatDbContext context)
        {
            RuleFor(x => x.Comment)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Komentar ne sme da bude prazno polje.")
                .MinimumLength(10).WithMessage("Minimalan broj karaktera je 10.");
            _context = context;

        }
    }
}
