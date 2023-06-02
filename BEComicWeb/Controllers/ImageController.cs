using BEComicWeb.Interface.ImageInterface;
using Microsoft.AspNetCore.Mvc;

namespace BEComicWeb.Controllers
{
    [Route("images")]
    public class ImageController : ControllerBase
    {
        /*private readonly IVultrRepository _vultrRepository;*/
        private readonly IImageRepository _imageRespository;
        /*public ImageController(IVultrRepository vultrRepository)
        {
            _vultrRepository = vultrRepository;
        }*/
        public ImageController(IImageRepository imageRespository)
        {
            _imageRespository = imageRespository;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, [FromForm] string? story_id, [FromForm] string? chapter_id=null)
        {
            /* var imageId = await _vultrRepository.UploadImageAsync(file, imageName);*/
            var imagePath = await _imageRespository.UploadImageAsync(file, story_id, chapter_id);
            return Ok(new { ImagePath = imagePath });
        }

        [HttpGet("{imageId}")]
        public async Task<IActionResult> GetImage(string imageId)
        {
            var stream = await _imageRespository.GetImageAsync(imageId);

            if (stream == null)
            {
                return NotFound();
            }

            return File(stream, "image/jpeg");
        }
    }
}
