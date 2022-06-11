using projekatASP.application.Searches;
using projekatASP.application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.UseCases.Queries.Tags
{
   public interface IGetTags : IQuery<TagSearchDTO, PageResponse<TagDTO>>
    {
    }
}
