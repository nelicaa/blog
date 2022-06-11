using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.UseCases.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string CoverImg { get; set; }
        public string User { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedAt {get;set;}
        public string Category { get; set; }
        public double? AvgRate { get; set; }

      

    }

    public class PostDetailsDTO:PostDTO
    {
        public IEnumerable<CommentDTO> Comments { get; set; } = new List<CommentDTO>();
        public IEnumerable<ImageDTO> Images { get; set; } = new List<ImageDTO>();

        public IEnumerable<TagDTO> Tags { get; set; } = new List<TagDTO>();
        public IEnumerable<LikeDTO> UsersWhoLiked { get; set; } = new List<LikeDTO>();
    }
   


}
