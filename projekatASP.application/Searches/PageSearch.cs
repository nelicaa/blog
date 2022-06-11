using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.Searches
{
    public abstract class PageSearch
    {
        public string Keyword { get; set; }
        public int PerPage { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
