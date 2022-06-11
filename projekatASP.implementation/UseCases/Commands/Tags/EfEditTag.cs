using FluentValidation;
using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.Commands.Tags;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using projekatASP.domain;
using projekatASP.implementation.Validators.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Tags
{
    public class EfEditTag : IEditTag
    {
        public int Id => 24;

        public string Name => "Edit tag";

        private readonly projekatDbContext _context;
        private readonly CreateTagValidator _validator;

        public EfEditTag(projekatDbContext context, CreateTagValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public void Execute(TagDTO request)
        {
            _validator.ValidateAndThrow(request);

            var tag = _context.Tags.Find(request.Id);

            if (tag == null)
            {
                throw new EntityNotFoundException(typeof(Tag), request.Id);
            }

            tag.Name = request.Name;

            _context.SaveChanges();
        }
    }
    }
