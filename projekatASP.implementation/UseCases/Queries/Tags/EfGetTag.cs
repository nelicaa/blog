using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries.Tags;
using projekatASP.dataAccess;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Queries.Tags
{
    public class EfGetTag : IGetTag
    {
        public int Id => 5;

        public string Name => "Get tag";

        private readonly projekatDbContext _context;

        public EfGetTag(projekatDbContext context)
        {
            _context = context;
        }
        public TagDTO Execute(int search)
        {
            var tag = _context.Tags.Find(search);

            if (tag == null)
            {
                throw new EntityNotFoundException(typeof(Tag), search);
            }

            return new TagDTO
            {
                Id = tag.Id,

                Name = tag.Name
            };
        }
    }
    
}
