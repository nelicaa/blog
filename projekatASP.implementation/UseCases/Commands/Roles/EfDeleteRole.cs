using ASPNedelja3.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.Commands.Roles;
using projekatASP.dataAccess;
using projekatASP.dataAccess.Extensions;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Roles
{
    public class EfDeleteRole : IDeleteRole
    {
        public int Id => 12;

        public string Name => "Delete role";
        private readonly projekatDbContext _context;

        public EfDeleteRole(projekatDbContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var role = _context.Roles
                       .Include(x => x.Users)
                       .FirstOrDefault(x => x.Id == request && x.DeletedAt == null);

            if (role == null)
            {
                throw new EntityNotFoundException(typeof(Role), request);
            }

            if (role.Users.Any())
            {
                throw new UseCaseConflictException("Can't delete this role because of it's link to this users: "
                                                   + string.Join(", ", role.Users.Select(x => x.Username)));
            }

            
            _context.Deactivate<Role>(request);

            _context.SaveChanges();
        }
    }
}
