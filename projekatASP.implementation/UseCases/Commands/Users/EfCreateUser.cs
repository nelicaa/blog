using ASPNedelja3.Application.Emails;
using FluentValidation;
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
    public class EfCreateUser : ICreateUser
    {
        public int Id => 24;

        public string Name => "Register user";

        private readonly projekatDbContext _context;
        private readonly CreateUserValidator _validator;
        private readonly IEmailSender _sender;


        public EfCreateUser(projekatDbContext context, CreateUserValidator validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }


        public void Execute(InsertUserDTO request)
        {
            _validator.ValidateAndThrow(request);

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = hash,
                FirstName = request.FirstName,
                LastName = request.LastName,
                RoleId = request.RoleId,
                Active = true
            };
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

            _context.Users.Add(user);
            _context.SaveChanges();


            //slanje email-a za verifikaciju

            _sender.Send(new MessageDto
            {
                To = request.Email,
                Title = "Successfull registration!",
                Body = "Dear " + request.Username + "\n Please activate your account...."
            });
        }
    }
    }
