using BEComicWeb.Model.Vultr;
using BEComicWeb.Interface.Vultr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Vultr.API;

namespace BEComicWeb.Controllers
{
    [Route("images")]
    public class ImageController : ControllerBase
    {
        private readonly IVultrRepository _vultrRepository;

        public ImageController(IVultrRepository vultrRepository)
        {
            _vultrRepository = vultrRepository;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, [FromForm] string imageName)
        {
            var imageId = await _vultrRepository.UploadImageAsync(file, imageName);

            return Ok(new { ImageId = imageId });
        }

        [HttpGet("{imageId}")]
        public async Task<IActionResult> GetImage(string imageId)
        {
            var stream = await _vultrRepository.GetImageAsync(imageId);

            if (stream == null)
            {
                return NotFound();
            }

            return File(stream, "image/jpeg");
        }
    }
}
