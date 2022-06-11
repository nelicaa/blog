using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.Searches
{
  public  class PostSearchDTO : PageSearch
    {
        public DateTime? CreatedAtFrom { get; set; }
        public DateTime? CreatedAtTo { get; set; }
        public int? NumberOfLikesGreater { get; set; }
        public int? NumberOfLikesLower { get; set; }
        public IEnumerable<int> CategoriesList { get; set; } = new List<int>();
        public IEnumerable<int> TagsList { get; set; } = new List<int>();
    }
}
