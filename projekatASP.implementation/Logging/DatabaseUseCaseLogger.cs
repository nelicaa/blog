using Newtonsoft.Json;
using projekatASP.application.Logging;
using projekatASP.application.UseCases;
using projekatASP.dataAccess;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.Logging
{

   public class DatabaseUseCaseLogger   : IDataBaseLogger
    {
        private readonly projekatDbContext _context;

        public DatabaseUseCaseLogger(projekatDbContext context)
        {
            _context = context;
        }


        public void Log(IUseCase useCase, IApplicationUser user, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLogs
            {
                CreatedAt = DateTime.Now,
                UseCaseName = useCase.Name,
                Data = JsonConvert.SerializeObject(useCaseData),
                Identity=user.Identity


            });

            _context.SaveChanges();
        }
    }
}
