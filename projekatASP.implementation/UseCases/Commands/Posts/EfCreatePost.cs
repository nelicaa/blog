using FluentValidation;
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
    public class EfCreatePost : ICreatePost
    {
        public int Id => 25;

        public string Name => "Create new post";

        private readonly projekatDbContext _context;
        private readonly CreatePostValidator _validator;

        public EfCreatePost(projekatDbContext context, CreatePostValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public void Execute(CreatePostDTO request)
        {
            _validator.ValidateAndThrow(request);


            var post = new Post
            {
                Title = request.Title,
                Text = request.Text,
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                MainPic=request.MainPic
            };
            _context.Posts.Add(post);


            foreach (var tags in request.PostTag)
            {
                _context.PostTags.Add(new PostTag
                {
                    Post =post,
                    TagId = tags,
                });
            }
            foreach (var image in request.Images)
            {
                _context.Images.Add(new projekatASP.domain.Images
                {
                    Post = post,
                     Image= image
                });
            }
            _context.SaveChanges();



        }
    }
}
