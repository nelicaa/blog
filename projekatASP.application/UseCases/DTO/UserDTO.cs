using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.UseCases.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public int PostsNumber { get; set; }
        public IEnumerable<PostDTO> Posts { get; set; } = new List<PostDTO>();
        public int CommentsNumber { get; set; }

        public IEnumerable<CommentDTO> CommentsFromThisUser { get; set; } = new List<CommentDTO>();

        public IEnumerable<LikeDTO> LikesFromThisUseer { get; set; } = new List<LikeDTO>();

    }

    /*public class PostsDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string CreatedAt { get; set; }
        public int NumberOfLikes { get; set; }
        public double AvgRate { get; set; }
        public string Comments { get; set; }

        }*/
}
