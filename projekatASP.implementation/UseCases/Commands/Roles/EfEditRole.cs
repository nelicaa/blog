using FluentValidation;
using projekatASP.application.Exceptions;
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
    public class EfEditRole : IEditRole
    {
        public int Id => 23;

        public string Name =>"Edit role";

        private readonly projekatDbContext _context;
        private readonly CreateRoleValidator _validator;

        public EfEditRole(projekatDbContext context, CreateRoleValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public void Execute(RoleDTO request)
        {
            _validator.ValidateAndThrow(request);

            var role = _context.Roles.Find(request.Id);

            if (role == null)
            {
                throw new EntityNotFoundException(typeof(Role), request.Id);
            }

            role.Name = request.Name;

            _context.SaveChanges();
        }
    }
    }

