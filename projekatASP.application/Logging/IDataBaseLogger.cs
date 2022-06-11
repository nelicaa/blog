using projekatASP.application.UseCases;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.Logging
{
    public interface IDataBaseLogger
    {
        void Log(IUseCase useCase, IApplicationUser actor, object useCaseData);
    }
}
