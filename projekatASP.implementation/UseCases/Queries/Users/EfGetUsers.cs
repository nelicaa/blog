using Microsoft.EntityFrameworkCore;
using projekatASP.application.Searches;
using projekatASP.application.UseCases;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries;
using projekatASP.application.UseCases.Queries.Users;
using projekatASP.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Queries.Users
{
    public class EfGetUsers : IUseCase, IGetUsers
    {
        public int Id => 10;

        public string Name => "Get all users and search them";
        private readonly projekatDbContext _context;

        public EfGetUsers(projekatDbContext context)
        {
            _context = context;
        }
        public PageResponse<UserDTO> Execute(UserSearchDTO search)
        {
            var users = _context.Users
              .Include(x => x.Role)
              .Include(x => x.Likes)
              .ThenInclude(x => x.Post)
              .Include(x => x.Comments)
              .ThenInclude(x => x.Post).Where(x => x.DeletedAt == null).AsQueryable();

           
                

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                users = users.Where(x => x.Username.ToLower().Contains(search.Keyword.ToLower()) ||
                   x.FirstName.ToLower().Contains(search.Keyword.ToLower()) ||
                   x.LastName.ToLower().Contains(search.Keyword.ToLower()) ||
                   x.Email.ToLower().Contains(search.Keyword.ToLower()));
            }
/*
            var userPosts = _context.Posts
               .Where(x => x.DeletedAt==null && users.Any(y => y.Id==x.UserId))
               .Include(x => x.Images)
               .Include(x => x.Likes)
               .ThenInclude(x => x.User)
               .Include(x => x.Comments)
               .Include(x => x.User)
               .Include(x => x.Category)
               .Include(x => x.Posts).ThenInclude(x => x.Tag).AsQueryable();*/

            var skipCount = search.PerPage * (search.Page - 1);

            return new PageResponse<UserDTO>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = users.Count(),
                Data = users.Skip(skipCount).Take(search.PerPage).Select(user => new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Username = user.Username,
                    Role = user.Role.Name,
                    PostsNumber = user.Post.Count(),
                    CommentsNumber = user.Comments.Count(),
                    CommentsFromThisUser = user.Comments.Select(x => new CommentDTO
                    {
                        Id=x.Id,
                        UserId=x.UserId,
                        Comment = x.Comment,
                        Rate = x.Rate,
                        PostId = x.PostId,
                        TitlePost = x.Post.Title,
                        User = user.Username
                    }),
                    LikesFromThisUseer = user.Likes.Select(x => new LikeDTO
                    {
                        User = x.User.Username,
                        PostId=x.PostId
                    }),
                    Posts=user.Post.Select(x=>new PostDTO
                    {
                        Id=x.Id,
                        Title=x.Title,
                        Text=x.Text,
                        Category=x.Category.Name,
                        CoverImg=x.MainPic,
                        CreatedAt=x.CreatedAt,
                        User=x.User.Username,
                        Likes= x.Likes.Count(),
                        AvgRate = x.Comments.Select(x => x.Rate).DefaultIfEmpty().Average()

                    })
                   /* ,
                    Posts = userPosts.Select(post => new PostDTO
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Text = post.Text,
                        CoverImg = post.MainPic,
                        CreatedAt = post.CreatedAt,
                        Likes = post.Likes.Count(),
                        Category = post.Category.Name,
                        Images = post.Images.Select(x => new ImageDTO
                        {
                            Image = x.Image
                        }),
                        Tags = post.Posts.Select(x => new TagDTO
                        {
                            Name = x.Tag.Name
                        }),
                        UsersWhoLiked = post.Likes.Select(x => new LikeDTO
                        {
                            User = x.User.Username
                        }),
                        Comments = post.Comments.Select(x => new CommentDTO
                        {
                            Comment = x.Comment,
                            User = x.User.Username,
                            Rate = x.Rate,
                            PostId = x.PostId,
                            TitlePost = x.Post.Title
                        }),
                        AvgRate = post.Comments.Select(x => x.Rate).DefaultIfEmpty().Average()
                    })
*/
                })
            };

        }
    }
}
