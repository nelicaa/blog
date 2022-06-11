using Microsoft.EntityFrameworkCore;
using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.Commands.Posts;
using projekatASP.dataAccess;
using projekatASP.dataAccess.Extensions;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Posts
{
    public class EfDeletePost : IDeletePost
    {
        public int Id =>17;

        public string Name => "Delete post";
        private readonly projekatDbContext _context;

        public EfDeletePost(projekatDbContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var post = _context.Posts
                .Include(x=>x.Comments)
                .Include(x=>x.Images)
                .FirstOrDefault(x => x.Id == request && x.DeletedAt == null);

            if (post == null)
            {
                throw new EntityNotFoundException(typeof(Post), request);

            }
            _context.Deactivate<Post>(request);

            _context.Deactivate<projekatASP.domain.Images>(post.Images.Select(x => x.Id));
            _context.Deactivate<projekatASP.domain.Comments>(post.Comments.Select(x => x.Id));

;

            _context.SaveChanges();
        }
    }
}
