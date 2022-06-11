using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekatASP.application.Searches;
using projekatASP.application.UseCases.Commands.Categories;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries.Categories;
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
    public class CategoryController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public CategoryController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/Category

        /// <summary>
        /// Get all categories or filter on : keyword - name of category.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Successfull show category.</response>

        [HttpGet]
        public IActionResult Get([FromQuery] CategorySearchDto search, [FromServices] IGetCategories query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }
        // GET api/Category/5
        /// <summary>
        /// Get one category from id in url.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Successfull show category.</response>
        /// <response code="404">Not found.</response>

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetCategory query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }


        // POST api/Category

        /// <summary>
        /// Creates new category. Only authorized can insert new category.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Category
        ///     {
        ///        "name": "New Category"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="409">Conflict if category with this value is already in database.</response>
        /// <response code="500">Unexpected server error.</response>

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CategoryDTO dto,[FromServices] ICreateCategory command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/Category/5

        /// <summary>
        /// Edit choosen category. Only authorized can update.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Category
        ///     {
        ///        "name": "New name"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull update.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="404">Not found category with this id.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="409">Conflict if category with this value is already in database.</response>
        /// <response code="500">Unexpected server error.</response>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDTO dto, [FromServices] IEditCategory command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/Category/5

        /// <summary>
        /// Delete category. Only authorized can delete.
        /// </summary>
        /// <response code="204">Successful delete.</response>
        /// <response code="404">Not found.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="409">Conflict if category is linked with some posts.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteCategory command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
