using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projekatASP.application.UseCases.Commands.Images;
using projekatASP.implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekatASP.api.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public ImagesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // DELETE api/Images/5

        /// <summary>
        /// Delete image. Only authorized can delete.
        /// </summary>
        /// <response code="204">Successful delete.</response>
        /// <response code="404">Not found.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteImages command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
