using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.domain
{
    public class Comments : Entity
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
