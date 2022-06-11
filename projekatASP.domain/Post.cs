using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.domain
{
   public class Post:Entity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string MainPic { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<Images> Images { get; set; } = new List<Images>();
        public virtual ICollection<PostTag> Posts { get; set; } = new List<PostTag>();
        public virtual ICollection<Likes> Likes { get; set; } = new List<Likes>();
        public virtual ICollection<Comments> Comments { get; set; } = new List<Comments>();


    }
}
