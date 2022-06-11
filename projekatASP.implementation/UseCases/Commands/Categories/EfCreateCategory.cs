using projekatASP.dataAccess;
using projekatASP.implementation.Validators.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projekatASP.domain;
using projekatASP.application.UseCases.DTO;

namespace projekatASP.application.UseCases.Commands.Categories
{
    public class EfCreateCategory : ICreateCategory
    {
        public int Id => 18;

        public string Name => "Create new category";

        private readonly projekatDbContext _context;
        private readonly CreateCategoryValidator _validator;

        public EfCreateCategory(projekatDbContext context, CreateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public void Execute(CategoryDTO request)
        {
            _validator.ValidateAndThrow(request);

            var category = new Category
            {
                Name = request.Name
            };

            _context.Categories.Add(category);

            _context.SaveChanges();
        }
    }
}
