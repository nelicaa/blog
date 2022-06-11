using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.Commands.Images;
using projekatASP.application.UseCases.DTO;
using projekatASP.dataAccess;
using projekatASP.dataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.implementation.UseCases.Commands.Images
{
    public class EfDeleteImages : IDeleteImages
    {
        public int Id => 28;

        public string Name => "Delete one image for post";

        private readonly projekatDbContext _context;

        public EfDeleteImages(projekatDbContext context)
        {
            _context = context;
        }

        public void Execute(int id)
        {
            var images = _context.Images
                       .Find(id);

            if (images == null)
            {
                throw new EntityNotFoundException(typeof(projekatASP.domain.Images), id);
            }


            _context.Deactivate<projekatASP.domain.Images>(images.Id);

            _context.SaveChanges();
        }
    }
}
