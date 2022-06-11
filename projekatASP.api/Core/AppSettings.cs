using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekatASP.api.Core
{
    /* public class AppSettings
     {
         public string ConnString { get; set; }
         public JWTSettings JwtSettings { get; set; }
     }*/
    public class AppSettings
    {
        public string ConnString { get; set; }
        public JWTSettings JwtSettings { get; set; }
        public EmailOptions EmailOptions { get; set; }
    }

    public class EmailOptions
    {
        public string FromEmail { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
    }
}
