using Microsoft.EntityFrameworkCore;
using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries.Users;
using projekatASP.dataAccess;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Queries.Users
{
    public class EfGetUser : IGetUser
    {
        public int Id =>9;

        public string Name =>"Get one user";
        private readonly projekatDbContext _context;

        public EfGetUser(projekatDbContext context)
        {
            _context = context;
        }

        public UserDTO Execute(int search)
        {
            var user = _context.Users
              .Include(x => x.Role)
              .Include(x=>x.Comments)
              .ThenInclude(x=>x.Post).Where(x => x.DeletedAt == null)
              .Include(x => x.Likes)
              .ThenInclude(x=>x.Post).Where(x => x.DeletedAt == null)
              .FirstOrDefault(x => x.Id == search && x.DeletedAt == null);

            var userPosts= _context.Posts
                .Include(x => x.Images).Where(x => x.DeletedAt == null)
                .Include(x => x.Likes)
                .ThenInclude(x => x.User)
                .Include(x => x.Comments).Where(x => x.DeletedAt == null)
                .Include(x => x.User)
                .Include(x => x.Category)
                .Include(x => x.Posts).ThenInclude(x => x.Tag)
                .Where(x => x.UserId == user.Id && x.DeletedAt == null);
            if (user == null)
            {
                throw new EntityNotFoundException(typeof(User), search);
            }

            return new UserDTO {
                Id = user.Id,
                FirstName = user.FirstName,
            LastName=user.LastName,
            Email=user.Email,
            Username=user.Username,
            Role=user.Role.Name,
            PostsNumber=userPosts.Count(),
            CommentsNumber=user.Comments.Count(),
            CommentsFromThisUser=user.Comments.Select(x=> new CommentDTO
                 {
                    Id=x.Id,
                     Comment=x.Comment,
                     Rate=x.Rate,
                     PostId = x.PostId,
                     TitlePost = x.Post.Title,
                     UserId=x.UserId,
                     User=user.Username
                     
                     
                 }),
                  LikesFromThisUseer=user.Likes.Select(x=>  new LikeDTO {
                      User=x.User.Username,
                      PostId=x.PostId
                      
                  }),
                  Posts=userPosts.Select(post=>  new PostDetailsDTO
                  {
                     
                     Id = post.Id,
                     Title = post.Title,
                     Text = post.Text,
                     User=post.User.Username,
                     CoverImg = post.MainPic,
                     CreatedAt = post.CreatedAt,
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
                         PostId=x.PostId,
                         User = x.User.Username
                     }),
                     Comments = post.Comments.Select(x => new CommentDTO
                     {
                         Id=x.Id,
                         Comment = x.Comment,
                         UserId=x.UserId,
                         User = x.User.Username,
                         Rate = x.Rate,
                         PostId = x.PostId,
                         TitlePost = x.Post.Title
                     }),
                     AvgRate = post.Comments.Select(x => x.Rate).DefaultIfEmpty().Average()
                 })
                
            };

        }
    }
}
