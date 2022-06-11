using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projekatASP.application.Searches;
using projekatASP.application.UseCases.Queries.Logs;
using projekatASP.implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekatASP.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public LogController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Get all logs or filter on : keyword - name of use case, date from - date to.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Successfull show category.</response>

        // GET: api/Log

        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] LogSearchDTO search, [FromServices] IGetLogs query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }
    }
}
