using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekatASP.api.Core
{
    public class JWTUser : IApplicationUser
    {
            public string Identity { get; set; }

            public int Id { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>();

        public string Email { get; set; }
    }

    public class AnonimousUser : IApplicationUser
    {
        public string Identity => "Anonymous";

        public int Id => 0;

        public IEnumerable<int> UseCaseIds => new List<int> { 1,2,27,7,8,3,4,5,6,9,10,24};

        public string Email => "anonimous@asp-api.com";
    }
}
