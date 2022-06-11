using projekatASP.application.Searches;
using projekatASP.application.UseCases;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries;
using projekatASP.application.UseCases.Queries.Roles;
using projekatASP.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Queries.Roles
{
    public class EfGetRoles : IUseCase, IGetRoles
    {
        public int Id => 4;

        public string Name => "Get roles";

        private readonly projekatDbContext _context;

        public EfGetRoles(projekatDbContext context)
        {
            _context = context;
        }


        public PageResponse<RoleDTO> Execute(RoleSearchDTO search)
        {
            var query = _context.Roles.Where(x => x.DeletedAt == null);

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            return new PageResponse<RoleDTO>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = query.Skip(skipCount).Take(search.PerPage).Select(x => new RoleDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };
        
        }
    }
}
