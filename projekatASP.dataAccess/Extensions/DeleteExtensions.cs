using projekatASP.application.Exceptions;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.dataAccess.Extensions
{
  public  static class DeleteExtensions
    {
        public static void Deactivate<T>(this projekatDbContext context, int id)
           where T : Entity
        {
            var itemToDeactivate = context.Set<T>().Find(id);

            if (itemToDeactivate == null)
            {
                throw new EntityNotFoundException(typeof(T), id);
            }

           itemToDeactivate.DeletedAt = DateTime.UtcNow;
        }

        public static void Deactivate<T>(this projekatDbContext context, IEnumerable<int> ids)
            where T : Entity
        {
            var toDeactivate = context.Set<T>().Where(x => ids.Contains(x.Id));

            foreach (var d in toDeactivate)
            {
                d.DeletedAt = DateTime.UtcNow;
            }

        }
    }
}
