using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Model.ChapterModel;
using BEComicWeb.Responsitory.StoryResponsitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Controllers
{
    [Route("chapter")]
    [ApiController]
    public class ChapterController : Controller
    {
        private readonly IChapterRepository _IChapterRepository;

        public ChapterController(IChapterRepository IChapterRep)
        {
            _IChapterRepository = IChapterRep;
        }

        [HttpGet("{story_id}/newest-chapter")]
        public async Task<ActionResult<Chapters>> GetNewestChapterOfStory(string story_id)  
        {
            return await Task.FromResult(_IChapterRepository.GetNewestChapterOfStory(story_id));
        }

        [HttpGet("{story_id}/all-chapters")]
        public async Task<ActionResult<IEnumerable<Chapters>>> GetAllChaptersOfStory(string story_id)
        {
            return await Task.FromResult(_IChapterRepository.GetAllChaptersOfStory(story_id));
        }


        // Get Chapter by Id
        // GET Chapter/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ChapterData>> GetChapter(string id)
        {
            var chapterData = await Task.FromResult(_IChapterRepository.GetChapter(id));
            if (chapterData == null)
            {
                return NotFound();
            }
            return chapterData;
        }

        // Create new Chapter
        // POST Chapter
        [HttpPost("new")]
        public async Task<ActionResult<ChapterData>> Post(ChapterData chapterData)
        {
            return await Task.FromResult(_IChapterRepository.CreateNewChapter(chapterData));
        }

        // Update Chapter if this Chapter is existed.

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ChapterData>> Put(ChapterData chapterData)
        {
            try
            {

                _IChapterRepository.UpdateChapter(chapterData);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return await Task.FromResult(chapterData);
        }

        // Delete Chapter
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ChapterData>> Delete(string id)
        {
            var Chapter = _IChapterRepository.DeleteChapter(id);
            return await Task.FromResult(Chapter);
        }
    }
}
