﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.domain
{
    public class Role : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();

    }
}
