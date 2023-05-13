using BEComicWeb.Interface.ImageInterface;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.ImageModel;
using BEComicWeb.Model.StoryModel;
using BEComicWeb.Responsitory.ImageRepository;
using Microsoft.AspNetCore.Mvc;

namespace BEComicWeb.Controllers
{
    [Route("chapter-image")]
    public class ChapterImageController : Controller
    {
        private readonly IChapterImagesRepository? _IChapterImagesRepository;

        public ChapterImageController(IChapterImagesRepository? IStoryRes)
        {
            _IChapterImagesRepository = IStoryRes;
        }
        [HttpGet("{chapter_id}")]
        public async Task<ActionResult<IEnumerable<ChapterImages>>> Get(string chapter_id)
        {
            var _ChapterImages = await Task.FromResult(_IChapterImagesRepository.GetChapterImages(chapter_id));
            if (_ChapterImages == null)
            {
                return NotFound();
            }
            return _ChapterImages;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ChapterImages>> Post(ChapterImages chapter_image)
        {
            _IChapterImagesRepository.AddChapterImage(chapter_image);
            return await Task.FromResult(chapter_image);
        }

        [HttpDelete("delete/{chapter_id}")]
        public async Task<ActionResult<IEnumerable<ChapterImages>>> Delete(string? chapter_id)
        {
            return await Task.FromResult(_IChapterImagesRepository.DeleteChapterImages(chapter_id));
        }
    }
}
