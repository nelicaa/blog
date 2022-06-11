using Microsoft.EntityFrameworkCore;
using projekatASP.application.Exceptions;
using projekatASP.application.Searches;
using projekatASP.application.UseCases;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries;
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
    public class EfGetPosts : IUseCase, IGetPosts
    {
        public int Id => 8;

        public string Name => "Get all posts.";

        private readonly projekatDbContext _context;

        public EfGetPosts(projekatDbContext context)
        {
            _context = context;
        }
        public PageResponse<PostDetailsDTO> Execute(PostSearchDTO search)
        {
            var post = _context.Posts
                .Where(x => x.DeletedAt == null)
              .Include(x => x.Images)
                .Include(x => x.Likes)
                .ThenInclude(x => x.User)
               .Include(x => x.Comments).Where(x => x.DeletedAt == null)
               .Include(x => x.User)
               .Include(x => x.Category)
               .Include(x => x.Posts).ThenInclude(x => x.Tag)
               .AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                post = post.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()) ||
                                         x.Text.ToLower().Contains(search.Keyword.ToLower()) ||
                                         x.User.Username.ToLower().Contains(search.Keyword.ToLower()));
            }
            if (search.CategoriesList.Count() > 0)
            {
                post = post.Where(x => search.CategoriesList.Contains(x.CategoryId));
            }

            if (search.TagsList.Count() > 0)
            {
                post = post.Where(x => x.Posts.Any(x=> search.TagsList.Contains(x.TagId)));
            }

            if (search.NumberOfLikesGreater.HasValue)
            {
                post = post.Where(x => x.Likes.Count() >= search.NumberOfLikesGreater);
            }

            if (search.NumberOfLikesLower.HasValue)
            {
                post = post.Where(x => x.Likes.Count() <= search.NumberOfLikesLower);
            }
            if (search.CreatedAtFrom.HasValue)
            {
                post = post.Where(x => x.CreatedAt >= search.CreatedAtFrom);
            }
            if (search.CreatedAtTo.HasValue)
            {
                post = post.Where(x => x.CreatedAt <= search.CreatedAtTo);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            return new PageResponse<PostDetailsDTO>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = post.Count(),
                Data = post.Skip(skipCount).Take(search.PerPage).Select(post => new PostDetailsDTO
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
                     {Id=x.TagId,
                         Name = x.Tag.Name
                     }),
                     UsersWhoLiked = post.Likes.Select(x => new LikeDTO
                     {
                         User = x.User.Username,
                         PostId=x.PostId,
                         UserId=x.UserId
                     }),
                     Comments = post.Comments.Select(x => new CommentDTO
                     {
                         Id=x.Id,
                         Comment = x.Comment,
                         User = x.User.Username,
                         Rate = x.Rate,
                         PostId = x.PostId,
                         TitlePost = x.Post.Title,
                         UserId=x.UserId
                     }),
                    AvgRate = post.Comments.Select(x => x.Rate).DefaultIfEmpty().Average()}).ToList()
                };

        }
    }
}
