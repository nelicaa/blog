using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.Commands.Likes;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using projekatASP.dataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Likes
{
    public class EfDeleteLike : IDeleteLike
    {
        public int Id => 14;

        public string Name => "Remove like from post.";
        private readonly projekatDbContext _context;

        public EfDeleteLike(projekatDbContext context)
        {
            _context = context;
        }

        public void Execute(LikeDTO dto)
        {
            var like = _context.Likes.Find(dto.UserId,dto.PostId);

            if (like == null)
            {
                throw new EntityNotFoundException(typeof(projekatASP.domain.Likes), like.PostId);
            }

            _context.Remove(like);
            _context.SaveChanges();
        }
    }
}
