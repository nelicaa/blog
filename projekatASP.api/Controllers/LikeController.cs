using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekatASP.application.UseCases.Commands.Likes;
using projekatASP.application.UseCases.DTO;
using projekatASP.implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projekatASP.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {

            private readonly UseCaseHandler _handler;

            public LikeController(UseCaseHandler handler)
            {
                _handler = handler;
            }

        // POST api/Like

        /// <summary>
        /// Creates new like. Only authorized can insert like.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Like
        ///     {
        ///        "postId": "post id from database",
        ///        "userId":"user id from database"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        [Authorize]

        public IActionResult Post([FromBody] LikeDTO dto, [FromServices] ICreateLike command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // DELETE api/Like/5

        /// <summary>
        /// Delete choosen like. Only authorized can update.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Comment
        ///     {
        ///        "postId": "post id from database",
        ///        "userId":"user id from database"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successful delete.</response>
        /// <response code="404">Not found.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>


        [HttpDelete]
        [Authorize]
        public IActionResult Delete([FromBody] LikeDTO dto, [FromServices] IDeleteLike command)
        {
            _handler.HandleCommand(command, dto);
            return NoContent();
        }
    }
}
