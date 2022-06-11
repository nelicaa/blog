using projekatASP.application.Searches;
using projekatASP.application.UseCases;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries;
using projekatASP.application.UseCases.Queries.Tags;
using projekatASP.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Queries.Tags
{
    public class EfGetTags : IUseCase, IGetTags
    {
        public int Id => 6;

        public string Name => "Get all tags";
        private readonly projekatDbContext _context;

        public EfGetTags(projekatDbContext context)
        {
            _context = context;
        }
        public PageResponse<TagDTO> Execute(TagSearchDTO search)
        {
            var query = _context.Tags.Where(x => x.DeletedAt == null).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            return new PageResponse<TagDTO>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = query.Skip(skipCount).Take(search.PerPage).Select(x => new TagDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };

        }
    }
    
}
