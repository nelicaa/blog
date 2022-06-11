using FluentValidation;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.Validators.Likes
{
   public class CreateLikeValidator  : AbstractValidator<LikeDTO>
    {
        private readonly projekatDbContext _context;
        public CreateLikeValidator(projekatDbContext context)
        {

            RuleFor(x => x.UserId)
           .Cascade(CascadeMode.Stop)
           .Must(UserExists).WithMessage("Korisnik {PropertyValue} mora da postoji u bazi. Ovaj ne postoji.");

            RuleFor(x => x.PostId)
.Cascade(CascadeMode.Stop)
.Must(PostExists).WithMessage("Post {PropertyValue} mora da postoji u bazi. Ovaj ne postoji.");
            _context = context;
        }
        private bool UserExists(int id)
        {
            var exists = _context.Users.Any(x => x.Id == id && x.DeletedAt == null);

            return exists;
        }

        private bool PostExists(int id)
        {
            var exists = _context.Posts.Any(x => x.Id == id && x.DeletedAt==null);

            return exists;
        }
    }

   
}
