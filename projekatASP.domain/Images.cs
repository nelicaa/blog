﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.domain
{
  public  class Images  : Entity
    {
        public string Image { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

    }
}
