  using Microsoft.EntityFrameworkCore;
using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.Commands.Users;
using projekatASP.dataAccess;
using projekatASP.dataAccess.Extensions;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Users
{
    public class EfDeleteUser : IDeleteUser
    {
        public int Id => 16;

        public string Name =>"Delete user";

        private readonly projekatDbContext _context;

        public EfDeleteUser(projekatDbContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var user = _context.Users
                     .Include(x => x.Post).ThenInclude(x=>x.Posts)
                     .Include(x => x.Post).ThenInclude(x => x.Images)
                     .Include(x=>x.Comments)
                     .FirstOrDefault(x => x.Id == request && x.DeletedAt == null);

            if (user == null)
            {
                throw new EntityNotFoundException(typeof(User), request);
            }


            var imagesToDelete = user.Post.SelectMany(x => x.Images.Select(y => y.Id));
            _context.Deactivate<User>(request);
            _context.Deactivate<Post>(user.Post.Select(x => x.Id));
            _context.Deactivate<projekatASP.domain.Images>(imagesToDelete);
            _context.Deactivate<projekatASP.domain.Comments>(user.Comments.Select(x => x.Id));



            _context.SaveChanges();
        }
    }
}
