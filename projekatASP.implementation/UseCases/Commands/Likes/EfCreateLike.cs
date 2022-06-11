using FluentValidation;
using projekatASP.application.UseCases.Commands.Likes;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using projekatASP.implementation.Validators.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Likes
{
    public class EfCreateLike : ICreateLike
    {
        public int Id => 21;

        public string Name => "Like for post.";

        private readonly projekatDbContext _context;
        private readonly CreateLikeValidator _validator;

        public EfCreateLike(projekatDbContext context, CreateLikeValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public void Execute(LikeDTO request)
        {
            _validator.ValidateAndThrow(request);

            var like = new projekatASP.domain.Likes
            {
                UserId = request.UserId,
                PostId = request.PostId,
            };

            _context.Likes.Add(like);

            _context.SaveChanges();

        }
    }
}
