using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projekatASP.api.Core;
using projekatASP.application.Exceptions;
using projekatASP.application.UseCases.DTO;
using projekatASP.implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projekatASP.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JWTManager _manager;

        public LoginController(JWTManager manager)
        {
            _manager = manager;
        }

        // POST api/Login

        /// <summary>
        /// Login for users.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Category
        ///     {
        ///        "email": "email from database",
        ///        "password":"password"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Logged in.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="404">Not found user.</response>
        /// <response code="500">Unexpected server error.</response>


        [HttpPost]
       
        public IActionResult Post([FromBody] LoginDTO request, [FromServices] CreateLoginValidator validator)
        {
            validator.ValidateAndThrow(request);
            try
            {
                var token = _manager.MakeToken(request.Email, request.Password);

                return Ok(new { token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

    