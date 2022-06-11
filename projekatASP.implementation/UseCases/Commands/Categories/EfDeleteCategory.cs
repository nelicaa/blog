using ASPNedelja3.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using projekatASP.application.Exceptions;
using projekatASP.dataAccess;
using projekatASP.dataAccess.Extensions;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.UseCases.Commands.Categories
{
    public class EfDeleteCategory : IDeleteCategory
    {
        public int Id => 11;

        public string Name => "Delete category";

        private readonly projekatDbContext _context;

        public EfDeleteCategory(projekatDbContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var category = _context.Categories
                       .Include(x => x.Posts)
                       .FirstOrDefault(x => x.Id == request && x.DeletedAt==null);

            if (category == null)
            {
                throw new EntityNotFoundException(typeof(Category), request);
            }

            if (category.Posts.Any())
            {
                throw new UseCaseConflictException("Can't delete category because of it's link to posts: "
                                                   + string.Join(", ", category.Posts.Select(x => x.Title)));
                
            }

            _context.Deactivate<Category>(request);

            _context.SaveChanges();
        }
    }
    }
