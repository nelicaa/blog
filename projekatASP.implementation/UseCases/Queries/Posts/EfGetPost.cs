using Microsoft.EntityFrameworkCore;
using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries.Posts;
using projekatASP.dataAccess;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Queries.Posts
{
    public class EfGetPost : IGetPost
    {
        public int Id =>7;

        public string Name => "Get one post";
        private readonly projekatDbContext _context;

        public EfGetPost(projekatDbContext context)
        {
            _context = context;
        }

        public PostDTO Execute(int search)
        {
            var post = _context.Posts
                .Include(x => x.Category)
                .Include(x => x.Images)
                .Include(x => x.User)
                .Include(x => x.Likes)
                .ThenInclude(x=>x.User)
                .Include(x => x.Comments).Where(x => x.DeletedAt == null)
                .Include(x => x.Posts).ThenInclude(x => x.Tag)
                .FirstOrDefault(x => x.Id == search && x.DeletedAt==null);
            if (post == null)
            {
                throw new EntityNotFoundException(typeof(Post), search);
            }

            return new PostDetailsDTO
            {
                Id = post.Id,
                Title = post.Title,
                Text = post.Text,
                CoverImg = post.MainPic,
                CreatedAt = post.CreatedAt,
                User = post.User.FirstName + " " + post.User.LastName,
                Likes = post.Likes.Count(),
                Category = post.Category.Name,
                Images = post.Images.Select(x => new ImageDTO
                {
                    Image = x.Image
                }),
                Tags = post.Posts.Select(x => new TagDTO
                {
                    Id = x.TagId,
                    Name = x.Tag.Name
                }),
                UsersWhoLiked = post.Likes.Select(x => new LikeDTO
                {
                    User = x.User.Username,
                    PostId = x.PostId
                }),
                Comments = post.Comments.Select(x => new CommentDTO
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    User = x.User.Username,
                    Rate = x.Rate,
                    PostId = x.PostId,
                    TitlePost = x.Post.Title,
                    UserId = x.UserId

                }),
                AvgRate = post.Comments.Select(x => x.Rate).DefaultIfEmpty().Average()
            };

           
        }
    }


}
