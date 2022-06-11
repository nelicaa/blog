using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekatASP.application.UseCases.Commands.Comments;
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
    public class CommentController : ControllerBase
    {

        private readonly UseCaseHandler _handler;

        public CommentController(UseCaseHandler handler)
        {
            _handler = handler;
        }



        // POST api/Comment

        /// <summary>
        /// Creates new comment. Only authorized can insert comment.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Comment
        ///     {
        ///        "comment": "Some text here",
        ///        "postId": "post id from database",
        ///        "userId":"user id from database",
        ///        "Rate":"number between 1-5"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CommentDTO dto, [FromServices] ICreateComment command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/Comment/5

        /// <summary>
        /// Edit choosen comment. Only authorized can update.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Comment
        ///     {
        ///        "comment": "New comment",
        ///        "Rate":"number between 1-5"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull update.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="404">Not found category with this id.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] CommentDTO dto, [FromServices] IEditComment command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/Comment/5

        /// <summary>
        /// Delete comment. Only authorized can delete.
        /// </summary>
        /// <response code="204">Successful delete.</response>
        /// <response code="404">Not found.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>
        
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteComment command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
