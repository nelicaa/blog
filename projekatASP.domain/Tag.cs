using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.domain
{
    public class Tag:Entity
    {
        public string Name { get; set; }

        public virtual ICollection<PostTag> Tags { get; set; } =new List<PostTag>();

    }
}
