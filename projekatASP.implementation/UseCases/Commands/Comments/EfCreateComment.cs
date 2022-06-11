using FluentValidation;
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
    public class EfCreateComment : ICreateComment
    {
        public int Id => 22;

        public string Name => "Create comment";

        private readonly projekatDbContext _context;
        private readonly CreateCommentValidator _validator;

        public EfCreateComment(projekatDbContext context, CreateCommentValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public void Execute(CommentDTO request)
        {
            _validator.ValidateAndThrow(request);

            var comment = new projekatASP.domain.Comments
            {
                Comment = request.Comment,
                UserId=request.UserId,
                PostId=request.PostId,
                Rate=request.Rate
            };

            _context.Comments.Add(comment);

            _context.SaveChanges();
        }
    }
}
