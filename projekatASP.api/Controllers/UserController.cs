using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekatASP.application.Searches;
using projekatASP.application.UseCases.Commands.Users;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries.Users;
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
    public class UserController : ControllerBase
    {


        private readonly UseCaseHandler _handler;

        public UserController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/User


        /// <summary>
        /// Get all users or filter on : keyword - username, first name, last name, email.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Successfull show users.</response>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearchDTO search, [FromServices] IGetUsers query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/User/5

        /// <summary>
        /// Get one user.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Successfull show user.</response>
        /// <response code="404">Not founduser.</response>
        [HttpGet("{id}")]

        public IActionResult Get(int id, [FromServices] IGetUser query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/User

        /// <summary>
        /// Creates new user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/User
        ///     {
     ///  "FirstName":"Name",
    ///"LastName":"Last name",
   /// "Email":"email@adress.com",
   /// "Username":"username123",
    ///"Password":"Password12*",
    ///"RoleId":"2"
        ///        
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]

        public IActionResult Post([FromBody] InsertUserDTO dto, [FromServices] ICreateUser command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
        // PUT api/User/5

        /// <summary>
        /// Edit choosen user. Only authorized can update.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/User
        ///   
        /// "FirstName":"Name",
        ///"LastName":"Last name",
        /// "Email":"email@adress.com",
        /// "Username":"username123",
        ///"Password":"Password12*",
        ///"RoleId":"2"
        ///
        /// </remarks>
        /// <response code="204">Successfull update.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="404">Not found user with this id.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="409">Conflict if new user have same email or username like someone else in database, or try to update password but value is like old password.</response>
        /// <response code="500">Unexpected server error.</response>
        /// 
        [HttpPut("{id}")]
        [Authorize]

        public IActionResult Put(int id, [FromBody] InsertUserDTO dto, [FromServices] IEditUser command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }
        // DELETE api/User/5

        /// <summary>
        /// Delete user. Only authorized can delete.
        /// </summary>
        /// <response code="204">Successful delete.</response>
        /// <response code="404">Not found.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteUser command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
