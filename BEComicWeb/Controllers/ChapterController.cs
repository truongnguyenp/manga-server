using BEComicWeb.Interface.ImageInterface;
using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model;
using BEComicWeb.Model.ImageModel;
using BEComicWeb.Model.StoryModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Controllers
{
    [Route("chapter")]
    [ApiController]
    public class ChapterController : Controller
    {
        private readonly IChapterRepository _IChapterRepository;
        private readonly IChapterImagesRepository _IChapterImagesRepository;

        public ChapterController(IChapterRepository IChapterRes, IChapterImagesRepository IChapterImageRep)
        {
            _IChapterRepository = IChapterRes;
            _IChapterImagesRepository = IChapterImageRep;

        }

        [HttpGet("{story_id}/newest-chapter")]
        public async Task<ActionResult<Chapters>> GetNewestChapterOfStory(string story_id)
        {
            return await Task.FromResult(_IChapterRepository.GetNewestChapterOfStory(story_id));
        }


        // Get Chapter by Id
        // GET Chapter/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> Get(string id)
        {
            var Chapter = await Task.FromResult(_IChapterRepository.GetChapter(id));
            if (Chapter == null)
            {
                return NotFound();
            }
            var ChapterImages = _IChapterImagesRepository.GetChapterImages(id);
            return new { Chapter, ChapterImages };
        }

        // Create new Chapter
        // POST Chapter
        [HttpPost("new")]
        public async Task<ActionResult<Chapters>> Post(ChapterData chapterData)
        {
            Chapters chapter = chapterData.Chapter;
            List<ChapterImages> chapterImages = chapterData.ChapterImages;
            foreach (var chapterImage in chapterImages)
            {

                _IChapterImagesRepository.AddChapterImage(chapterImage);

            }
            return await Task.FromResult(_IChapterRepository.AddChapter(chapter));
        }

        // Update Chapter if this Chapter is existed.

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Chapters>> Put(string id, ChapterData chapterData)
        {
            Chapters chapter = chapterData.Chapter;
            List<ChapterImages> chapterImages = chapterData.ChapterImages;
            if (id != chapter.Id)
            {
                return BadRequest();
            }
            try
            {

                _IChapterRepository.UpdateChapter(chapter);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChapterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(chapter);
        }

        // Delete Chapter
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Chapters>> Delete(string id)
        {
            var Chapter = _IChapterRepository.DeleteChapter(id);
            return await Task.FromResult(Chapter);
        }
        private bool ChapterExists(string id)
        {
            return _IChapterRepository.CheckChapterExists(id);
        }
    }
}
