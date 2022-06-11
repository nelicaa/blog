using FluentValidation;
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
    public class EfCreateTag : ICreateTag
    {
        public int Id => 19;

        public string Name => "Create new tag";

        private readonly projekatDbContext _context;
        private readonly CreateTagValidator _validator;

        public EfCreateTag(projekatDbContext context, CreateTagValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public void Execute(TagDTO request)
        {
            _validator.ValidateAndThrow(request);

            var tag = new Tag
            {
                Name = request.Name
            };

            _context.Tags.Add(tag);

            _context.SaveChanges();
        }
    }

}
