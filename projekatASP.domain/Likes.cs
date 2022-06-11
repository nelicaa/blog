using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.domain
{
   public class Likes
    {
        public int PostId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
