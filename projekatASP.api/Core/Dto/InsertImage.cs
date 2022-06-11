using Microsoft.AspNetCore.Http;
using projekatASP.application.UseCases.DTO;

namespace ASPNedelja3Vezbe.Api.Core.Dto
{
    public class InsertImage : CreatePostDTO
    {
        public IFormFile Image { get; set; }

        public IFormFileCollection? ImagesUpload { get; set; }
    }
}
