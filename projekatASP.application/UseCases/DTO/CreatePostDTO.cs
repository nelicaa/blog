using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.UseCases.DTO
{
   public class CreatePostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string MainPic { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }


        public IEnumerable<string> Images { get; set; } = new List<string>();
        public IEnumerable<int> PostTag { get; set; }=  new List<int>();

    }
}
