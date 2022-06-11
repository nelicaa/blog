using FluentValidation;
using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.Commands.Posts;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using projekatASP.domain;
using projekatASP.implementation.Validators.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Posts
{
    public class EfEditPost : IEditPost
    {
        public int Id => 26;

        public string Name => "Edit post";
        private readonly projekatDbContext _context;
        private readonly EditPostValidator _validator;

        public EfEditPost(projekatDbContext context, EditPostValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public void Execute(CreatePostDTO request)
        {

            _validator.ValidateAndThrow(request);

            var post = _context.Posts.Find(request.Id);


            if (post == null)
            {
                throw new EntityNotFoundException(typeof(Post), request.Id);
            }
            if (request.Title != null)
            {
                post.Title = request.Title;
            }
            if (request.Text != null)
            {
                post.Text = request.Text;
            }
            if (request.MainPic != null)
            {
                post.MainPic = request.MainPic;
            }
          
            if (request.CategoryId != post.CategoryId && request.CategoryId!=0)
            {
                post.CategoryId = request.CategoryId;
            }

            if (request.PostTag.Count() != 0)
            {
                var tagsRemove = _context.PostTags.Where(x => x.Post.Id == request.Id);

                _context.PostTags.RemoveRange(tagsRemove);
                foreach (var tags in request.PostTag)
                {
                    _context.PostTags.Add(new PostTag
                    {
                        Post = post,
                        TagId = tags,
                    });
                }
            }

                
                    foreach (var image in request.Images)
                    {
                        _context.Images.Add(new projekatASP.domain.Images
                        {
                            Post = post,
                            Image = image
                        });
                    }
                
            _context.SaveChanges();

        }
    }
}
