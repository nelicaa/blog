using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.UseCases
{
    public interface IUseCase
    {
        public int Id { get; }
        string Name { get; }
    }
}
