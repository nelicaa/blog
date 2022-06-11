using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.UseCases.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public string TitlePost { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        public string User { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
    }
}
