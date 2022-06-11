﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekatASP.api.Core
{
    public class JWTSettings
    {
        public int Minutes { get; set; }
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
    }
}
