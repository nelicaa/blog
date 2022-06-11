using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.UseCases.Queries
{
    public class PageResponse<T> where T : class
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int LastPage => (int)Math.Ceiling((float)TotalCount / ItemsPerPage);
        public int ItemsPerPage { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
