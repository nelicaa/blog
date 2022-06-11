using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.UseCases.DTO
{
   public class LikeDTO
    {
        public string User { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
