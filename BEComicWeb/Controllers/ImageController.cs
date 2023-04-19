using BEComicWeb.Model.Vultr;   
using BEComicWeb.Interface.Vultr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Vultr.API;
using BEComicWeb.Interface.ImageInterface;

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
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, [FromForm] string storage)
        {
            /* var imageId = await _vultrRepository.UploadImageAsync(file, imageName);*/
            var imageId = await _imageRespository.UploadImageAsync(file, storage);
            return Ok(new { ImageId = imageId });
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
