using FluentValidation;
using projekatASP.application.UseCases.Commands.Roles;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using projekatASP.domain;
using projekatASP.implementation.Validators.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Roles
{
    public class EfCreateRole : ICreateRole
    {
        public int Id => 20;

        public string Name => "Create new role";

             private readonly projekatDbContext _context;
        private readonly CreateRoleValidator _validator;

        public EfCreateRole(projekatDbContext context, CreateRoleValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public void Execute(RoleDTO request)
        {
            _validator.ValidateAndThrow(request);

            var role = new Role
            {
                Name = request.Name
            };

            _context.Roles.Add(role);

            _context.SaveChanges();
        } 
    }
 
}
