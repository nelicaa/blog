using Microsoft.EntityFrameworkCore;
using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.Commands.Comments;
using projekatASP.dataAccess;
using projekatASP.dataAccess.Extensions;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Comments
{
    public class EfDeleteComment : IDeleteComment
    {
        public int Id => 13;

        public string Name => "Delete comment";
        private readonly projekatDbContext _context;

        public EfDeleteComment(projekatDbContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var comment = _context.Comments
                       .FirstOrDefault(x => x.Id == request && x.DeletedAt == null);

            if (comment == null)
            {
                throw new EntityNotFoundException(typeof(projekatASP.domain.Comments), request);
            }

            _context.Deactivate<projekatASP.domain.Comments>(request);

            _context.SaveChanges();
        }
    }
}
