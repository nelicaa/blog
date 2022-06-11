using projekatASP.application.Searches;
using projekatASP.application.UseCases;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries;
using projekatASP.application.UseCases.Queries.Categories;
using projekatASP.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Queries.Categories
{
    public class EfGetCategories : IUseCase, IGetCategories
    {
        public int Id => 2;

        public string Name => "Get all categories.";

        private readonly projekatDbContext _context;

        public EfGetCategories(projekatDbContext context)
        {
            _context = context;
        }

        public PageResponse<CategoryDTO> Execute(CategorySearchDto search)
        {
            var query = _context.Categories.Where(x=>x.DeletedAt==null).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            return new PageResponse<CategoryDTO>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = query.Skip(skipCount).Take(search.PerPage).Select(x => new CategoryDTO
                {
                    Id=x.Id,
                    Name = x.Name
                }).ToList()
            };
        
        }
    }
}
