using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries.Roles;
using projekatASP.dataAccess;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Queries.Roles
{
    public class EfGetRole : IGetRole
    {
        public int Id => 3;

        public string Name =>"Get one role";
        private readonly projekatDbContext _context;

        public EfGetRole(projekatDbContext context)
        {
            _context = context;
        }

        public RoleDTO Execute(int search)
        {
            var role = _context.Roles.Find(search);

            if (role == null)
            {
                throw new EntityNotFoundException(typeof(Role), search);
            }

            return new RoleDTO
            {
                Id = role.Id,

                Name = role.Name
            };
        }
    }
    
}
