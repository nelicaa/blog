using FluentValidation;
using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.Commands.Comments;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using projekatASP.implementation.Validators.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Comments
{
    public class EfEditComment : IEditComment
    {
        public int Id => 24;

        public string Name => "Edit comment";


        private readonly projekatDbContext _context;
        private readonly EditCommentValidator _validator;

        public EfEditComment(projekatDbContext context, EditCommentValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public void Execute(CommentDTO request)
        {
            _validator.ValidateAndThrow(request);

            var category = _context.Comments.Find(request.Id);

            if (category == null)
            {
                throw new EntityNotFoundException(typeof(domain.Comments), request.Id);
            }

            category.Comment = request.Comment;

            _context.SaveChanges();
        }
    }
}
