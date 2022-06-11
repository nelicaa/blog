using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.domain
{
    public interface IApplicationUser
    {
        public int Id { get; }
        public string Identity { get; }
        public IEnumerable<int> UseCaseIds { get; }
        public string Email { get; }
    }
}
