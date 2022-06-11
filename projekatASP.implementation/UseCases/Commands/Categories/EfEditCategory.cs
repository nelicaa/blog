using FluentValidation;
using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using projekatASP.domain;
using projekatASP.implementation.Validators.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.UseCases.Commands.Categories
{
    public class EfEditCategory : IEditCategory
    {
        public int Id => 22;

        public string Name => "Edit category";
        private readonly projekatDbContext _context;
        private readonly CreateCategoryValidator _validator;

        public EfEditCategory(projekatDbContext context, CreateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public void Execute(CategoryDTO request)
        {
            _validator.ValidateAndThrow(request);

            var category = _context.Categories.Find(request.Id);

            if (category == null)
            {
                throw new EntityNotFoundException(typeof(Category), request.Id);
            }

            category.Name = request.Name;

            _context.SaveChanges();
        }
    }
        
   
}