using Microsoft.EntityFrameworkCore;
using projekatASP.application.Searches;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries;
using projekatASP.application.UseCases.Queries.Logs;
using projekatASP.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Logs
{
    public class EfGetLogs : IGetLogs
    {
        public int Id => 27;

        public string Name => "Get all or search logs";

        private readonly projekatDbContext _context;

        public EfGetLogs(projekatDbContext context)
        {
            _context = context;
        }

        public PageResponse<LogDTO> Execute(LogSearchDTO search)
        {
            var logs = _context.UseCaseLogs
              .AsQueryable();




            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                logs = logs.Where(x => x.UseCaseName.ToLower().Contains(search.Keyword.ToLower())
                || x.Identity.ToLower().Contains(search.Keyword.ToLower())
                );
            }

            if (search.CreatedAtFrom.HasValue)
            {
                logs = logs.Where(x => x.CreatedAt >= search.CreatedAtFrom);
            }
            if (search.CreatedAtTo.HasValue)
            {
                logs = logs.Where(x => x.CreatedAt <= search.CreatedAtTo);
            }
            



            var skipCount = search.PerPage * (search.Page - 1);

            return new PageResponse<LogDTO>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = logs.Count(),
                Data = logs.Skip(skipCount).Take(search.PerPage).Select(log =>
                new LogDTO
                {
                    Id=log.Id,
                    CreatedAt=log.CreatedAt,
                    Email=log.Identity,
                    Data=log.Data,
                    UseCaseName=log.UseCaseName

                })
            };
                }
    }
}
