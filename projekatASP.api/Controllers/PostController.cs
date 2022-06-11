using ASPNedelja3Vezbe.Api.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekatASP.application.Searches;
using projekatASP.application.UseCases.Commands.Images;
using projekatASP.application.UseCases.Commands.Posts;
using projekatASP.application.UseCases.DTO;
using projekatASP.application.UseCases.Queries.Posts;
using projekatASP.implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projekatASP.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {


        private readonly UseCaseHandler _handler;

        public PostController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/Post

        /// <summary>
        /// Get all posts or filter on : keyword - title, username, first name, last name, email from user; on categories; tags ; number of likes ; filter on date when post was created.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Successfull show posts.</response>
        [HttpGet]
        public IActionResult Get([FromQuery] PostSearchDTO search, [FromServices] IGetPosts query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/Post/5
        /// <summary>
        /// Get one post from id in url.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Successfull show category.</response>
        /// <response code="404">Not found.</response>


        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetPost query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/Post

        /// <summary>
        /// Creates new post. Only authorized can insert new post.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Post
        ///     {
        ///        "Title": "Title",
        ///        "Text":"Description",
        ///        "UserId":"user id from database",
        ///        "PostTag":[1,2,3],
        ///        "Image":"upload main picture from form",
        ///        "ImagesUpload":"upload pictures from form",
        ///        "CategoryId":"id category fromdatabase"
        ///        
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] InsertImage dto, [FromServices] ICreatePost command)
        {
            if (dto.Image != null)
            {
                var guid = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(dto.Image.FileName);

                if (extension != ".jpg" && extension != ".png" && extension != ".jpeg")
               {
                    throw new InvalidOperationException("Unsupported file type.");
                }

                var fileName = guid + extension;

                var filePath = Path.Combine("wwwroot", "images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                dto.Image.CopyTo(stream);


                dto.MainPic = fileName;
            }

            var newImages=new List<string>();
            if (dto.ImagesUpload !=null)
            {
                foreach (var image in dto.ImagesUpload)
                {
                    var guid = Guid.NewGuid().ToString();

                    var extension = Path.GetExtension(image.FileName);

                     if (extension != ".jpg" && extension != ".png" && extension != ".jpeg")
                     {
                         throw new InvalidOperationException("Unsupported file type.");
                     }

                    var fileName = guid + extension;

                    var filePath = Path.Combine("wwwroot", "images", fileName);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    image.CopyTo(stream);


                    newImages.Add(fileName);
                }
                dto.Images = newImages;
            }


            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/Post/5

        /// <summary>
        /// Edit choosen post. Only authorized can update.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Post
        ///     {
        ///        "Title": "Title",
        ///        "Text":"Description",
        ///        "PostTag":[1,2,3],
        ///        "Image":"upload main picture from form",
        ///        "ImagesUpload":"upload pictures from form",
        ///        "CategoryId":"id category fromdatabase"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull update.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="404">Not found post with this id.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromForm] InsertImage dto, [FromServices] IEditPost command)
        {
            dto.Id = id;
            if (dto.Image != null)
            {
                var guid = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(dto.Image.FileName);

                if (extension != ".jpg" && extension != ".png" && extension != ".jpeg")
                {
                    throw new InvalidOperationException("Unsupported file type.");
                }

                var fileName = guid + extension;

                var filePath = Path.Combine("wwwroot", "images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                dto.Image.CopyTo(stream);


                dto.MainPic = fileName;
            }

            var newImages = new List<string>();
            if (dto.ImagesUpload != null)
            {
                foreach (var image in dto.ImagesUpload)
                {
                    var guid = Guid.NewGuid().ToString();

                    var extension = Path.GetExtension(image.FileName);

                    if (extension != ".jpg" && extension != ".png" && extension != ".jpeg")
                    {
                        throw new InvalidOperationException("Unsupported file type.");
                    }

                    var fileName = guid + extension;

                    var filePath = Path.Combine("wwwroot", "images", fileName);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    image.CopyTo(stream);


                    newImages.Add(fileName);
                }
                dto.Images = newImages;
            }
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }


        // DELETE api/Post/5
        /// <summary>
        /// Delete post. Only authorized can delete.
        /// </summary>
        /// <response code="204">Successful delete.</response>
        /// <response code="404">Not found.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Unexpected server error.</response>

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeletePost command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }

        
    }
}
