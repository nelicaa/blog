using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekatASP.application.Searches;
using projekatASP.application.UseCases.Commands.Roles;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries.Categories;
using projekatASP.application.UseCases.Queries.Roles;
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
    public class RoleController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public RoleController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/Role


        /// <summary>
        /// Get all roles or filter on : keyword - name of role.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Successfull show role.</response>
        [HttpGet]
        public IActionResult Get([FromQuery] RoleSearchDTO search, [FromServices] IGetRoles query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/Role/5

        /// <summary>
        /// Get one role from id in url.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Successfull show role.</response>
        /// <response code="404">Not found.</response>
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetRole query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/Role
        // POST api/Category

        /// <summary>
        /// Creates new role. Only authorized can insert new category.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Role
        ///     {
        ///        "name": "New role"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="409">Conflict if role with this name is already in database.</response>
        /// <response code="500">Unexpected server error.</response>

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] RoleDTO dto, [FromServices] ICreateRole command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/Role/5
        /// <summary>
        /// Edit choosen role. Only authorized can update.
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
        /// <response code="409">Conflict if role with this name is already in database.</response>
        /// <response code="500">Unexpected server error.</response>


        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] RoleDTO dto, [FromServices] IEditRole command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/Role/5

        /// <summary>
        /// Delete role. Only authorized can delete.
        /// </summary>
        /// <response code="204">Successful delete.</response>
        /// <response code="404">Not found.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="409">Conflict if role is linked with some users.</response>
        /// <response code="500">Unexpected server error.</response>

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteRole command)
        {

            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
