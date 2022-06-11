using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekatASP.application.Searches;
using projekatASP.application.UseCases.Commands.Tags;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries.Tags;
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
    public class TagController : ControllerBase
    {

        private readonly UseCaseHandler _handler;

        public TagController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/Tag


        /// <summary>
        /// Get all tags or filter on : keyword - name of tag.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Successfull show tag.</response>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] TagSearchDTO search, [FromServices] IGetTags query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/Tag/5

        /// <summary>
        /// Get one tag from id in url.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Successfull show tag.</response>
        /// <response code="404">Not found.</response>
        [HttpGet("{id}")]
        [AllowAnonymous]

        public IActionResult Get(int id, [FromServices] IGetTag query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/Tag

        /// <summary>
        /// Creates new tag. Only authorized can insert new tag.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Tag
        ///     {
        ///        "name": "New tag"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="409">Conflict if tag with this name is already in database.</response>
        /// <response code="500">Unexpected server error.</response>

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] TagDTO dto, [FromServices] ICreateTag command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/Tag/5


        /// <summary>
        /// Edit choosen tag. Only authorized can update.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Role
        ///     {
        ///        "name": "New name"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull update.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="404">Not found category with this id.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="409">Conflict if tag with this name is already in database.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPut("{id}")]
        [Authorize]

        public IActionResult Put(int id, [FromBody] TagDTO dto, [FromServices] IEditTag command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/Tag/5
        /// <summary>
        /// Delete tag. Only authorized can delete.
        /// </summary>
        /// <response code="204">Successful delete.</response>
        /// <response code="404">Not found.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="409">Conflict if tag is linked with some posts.</response>
        /// <response code="500">Unexpected server error.</response>

        [HttpDelete("{id}")]
        [Authorize]

        public IActionResult Delete(int id, [FromServices] IDeleteTag command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
