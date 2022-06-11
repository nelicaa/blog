using ASPNedelja3.Application.Exceptions;
using FluentValidation;
using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.Commands.Users;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using projekatASP.domain;
using projekatASP.implementation.Validators.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Users
{
    public class EfEditUser : IEditUser
    {
        public int Id => 24;

        public string Name => "Edit usera";
        private readonly projekatDbContext _context;
        private readonly EditUserValidator _validator;

        public EfEditUser(projekatDbContext context, EditUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public void Execute(InsertUserDTO request)
        {

            _validator.ValidateAndThrow(request);

            var user = _context.Users.Find(request.Id);

            if (user == null)
            {
                throw new EntityNotFoundException(typeof(User), request.Id);
            }
            if (request.FirstName != null)
            {
                user.FirstName = request.FirstName;
            }
            if (request.LastName!= null)
            {
                user.LastName = request.LastName;
            }
            if (request.Email != null)
            {
                user.Email = request.Email;
            }
            if (request.Username != null)
            {
                user.Username = request.Username;
            }
           

            if (request.Password!= null)
            {
                var oldHash = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
                if (!oldHash)
                {
                    var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);
                    user.Password = hash;

                }
                else
                {
                    throw new UseCaseConflictException("Password je isti kao i perthodni.");
                }
            }

            if (request.RoleId != user.RoleId && request.RoleId != 0)
            {
                user.RoleId = request.RoleId;

                if (user.RoleId == 2)
                {
                    for (var i = 1; i < 29; i++)
                    {

                        _context.UserUseCase.Add(new UserUseCase
                        {
                            User = user,
                            UseCaseId = i
                        });
                    }
                }
                else
                {
                    var oldUseCases = _context.UserUseCase.Where(x => x.UserId == user.Id);
                    _context.UserUseCase.RemoveRange(oldUseCases);
                }

            }



            _context.SaveChanges();
        }
    }
}
