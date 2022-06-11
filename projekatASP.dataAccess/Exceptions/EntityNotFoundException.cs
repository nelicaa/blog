using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type type, int id)
            : base($"Entity of type {type.Name} with an id of {id} was not found.")
        {
        }
    }
}
