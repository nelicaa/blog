using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries.Categories;
using projekatASP.dataAccess;
using projekatASP.domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Queries.Categories
{
    public class EfGetCategoryQuery : IGetCategory
    {
        public int Id => 1;

        public string Name => "Get one category";

        private readonly projekatDbContext _context;

        public EfGetCategoryQuery(projekatDbContext context)
        {
            _context = context;
        }

        public CategoryDTO Execute(int search)
        {
            var category = _context.Categories.Find(search);

            if (category == null)
            {
                throw new EntityNotFoundException(typeof(Category), search);
            }

            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
    }
