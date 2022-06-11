using ASPNedelja3.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.Commands.Tags;
using projekatASP.dataAccess;
using projekatASP.dataAccess.Extensions;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Tags
{
    public class EfDeleteTag : IDeleteTag
    {
        public int Id => 15;

        public string Name => "Delete tag";
        private readonly projekatDbContext _context;

        public EfDeleteTag(projekatDbContext context)
        {
            _context = context;
        }
        public void Execute(int request)
        {
            var tag = _context.Tags
                        .Include(x => x.Tags).ThenInclude(x=>x.Post)
                        .FirstOrDefault(x => x.Id == request && x.Tags.Any(y=>y.Post.DeletedAt==null));

            if (tag == null)
            {
                throw new EntityNotFoundException(typeof(Tag), request);
            }

            if (tag.Tags.Any())
            {
                throw new UseCaseConflictException("Can't delete this tag because of it's link to this posts: "
                                                   + string.Join(", ", tag.Tags.Select(y => y.Post.Title)));
            }


            _context.Deactivate<Tag>(request);

            _context.SaveChanges();
        }
    }
}
